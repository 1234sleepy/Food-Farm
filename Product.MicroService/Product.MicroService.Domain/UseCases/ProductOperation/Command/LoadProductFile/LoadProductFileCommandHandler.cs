using MediatR;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabel;
using Product.MicroService.Domain.UseCases.LabelOperation.Command.AddLabelToProduct;
using Product.MicroService.Domain.UseCases.ProductOperation.Base;
using System.Text.Json;

namespace Product.MicroService.Domain.UseCases.ProductOperation.Command.LoadProductFile;

public class LoadProductFileCommandHandler(ILoadProductFile loadProductFile, IAddLabelStorage addLabelStorage, IAddLabelToProductStorage addLabelToProductStorage) : IRequestHandler<LoadProductFileCommand>
{
    private readonly ILoadProductFile _loadProductFile = loadProductFile;
    private readonly IAddLabelStorage _addLabelStorage = addLabelStorage;
    private readonly IAddLabelToProductStorage _addLabelToProductStorage = addLabelToProductStorage;

    public async Task Handle(LoadProductFileCommand request, CancellationToken cancellationToken)
    {
        List<ProductModel> products = new List<ProductModel>();

        await foreach(var product in JsonSerializer.DeserializeAsyncEnumerable<ProductJsonModel>(request.file))
        {
            products.Add(new ProductModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                QuantityLimit = product.QuantityLimit,
                Characteristics = product.Characteristics
            });

            foreach(var label in product.Labels)
            {
                var labelModel = await _addLabelStorage.AddLabel(label.Name, label.Color, cancellationToken);

                await _addLabelToProductStorage.AddLabelToProduct(products.Last().Id, labelModel.Id, cancellationToken);
            }

            if (products.Count >= 1000)
            {
                //await _loadProductFile.AddProducts(products);
                products.Clear();
            }
        }

        //await _loadProductFile.AddProducts(products); if we have less than 1000 products, we need to add them to the database as well
    }
}

//add Label array to generated json list and check if it exists, if not add it to the database, if it exists add the id to the product label table, if not add the new label to the database and add the id to the product label table
//add table which file api received and its information.