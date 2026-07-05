using MediatR;
using Product.MicroService.Domain.Services.Transaction;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using Product.MicroService.Domain.UseCases.ProductOperation.Command.AddProduct;
using System.Text.Json;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.LoadProductFile;

public class LoadProductFileCommandHandler(ITransactionService transactionService, ILoadProductFile loadProductFile, IAddProductStorage addProductStorage, IAddLabelStorage addLabelStorage, IAddLabelToProductStorage addLabelToProductStorage) : IRequestHandler<LoadProductFileCommand>
{
    private readonly ITransactionService _transactionService = transactionService;
    private readonly ILoadProductFile _loadProductFile = loadProductFile;
    private readonly IAddProductStorage _addProductStorage = addProductStorage;
    private readonly IAddLabelStorage _addLabelStorage = addLabelStorage;
    private readonly IAddLabelToProductStorage _addLabelToProductStorage = addLabelToProductStorage;

    Dictionary<string, Guid> labelDictionary = new Dictionary<string, Guid>();
    public async Task Handle(LoadProductFileCommand request, CancellationToken cancellationToken)
    {
        List<ProductModel> products = new List<ProductModel>();
        await foreach (var product in JsonSerializer.DeserializeAsyncEnumerable<ProductJsonModel>(request.file))
        {

            using (_transactionService.Begin(cancellationToken))
            {
                try
                {
                    //products.Add(new ProductModel
                    //{
                    //    Name = product.Name,
                    //    Description = product.Description,
                    //    Price = product.Price,
                    //    DiscountPrice = product.DiscountPrice,
                    //    QuantityLimit = product.QuantityLimit,
                    //    Characteristics = product.Characteristics
                    //});

                    var productModel = await _addProductStorage.AddProduct(product.Name, product.Price, product.QuantityLimit, product.Description, product.DiscountPrice, cancellationToken);

                    foreach (var label in product.Labels)
                    {
                        Guid labelId = await GetOrAddLabelIdAsync(label, cancellationToken);

                        await _addLabelToProductStorage.AddLabelToProduct(productModel.Id, labelId, cancellationToken);
                    }

                    //if (products.Count >= 1000)
                    //{
                    //    await _loadProductFile.AddProducts(products);
                    //    products.Clear();
                    //}

                    await _transactionService.Commit(cancellationToken);
                }
                catch
                {
                    await _transactionService.RollBack(cancellationToken);
                    throw;
                }
            }

        }
        //if (products != null)
        //{
        //    await _loadProductFile.AddProducts(products);
        //} 
    }

    private async Task<Guid> GetOrAddLabelIdAsync(LabelJsonModel label, CancellationToken cancellationToken)
    {
        if (!labelDictionary.TryGetValue(label.Name, out var labelId))
        {
            if (!await _addLabelStorage.IsExist(label.Name, label.Color, cancellationToken))
            {
                var labelModel = await _addLabelStorage.AddLabel(label.Name, label.Color, cancellationToken);
                labelId = labelModel.Id;
            }
            else
            {
                labelId = await _addLabelStorage.GetId(label.Name, cancellationToken);
            }

            labelDictionary.Add(label.Name, labelId);
        }

        return labelId;
    }
}



//add Label array to generated json list and check if it exists, if not add it to the database, if it exists add the id to the product label table, if not add the new label to the database and add the id to the product label table
//add table which file api received and its information.