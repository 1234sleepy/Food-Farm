using AutoMapper;
using Domain.UseCases.Comment.Command.AddComment;
using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Storages.CommentOperation;

public class AddCommentStorage(DataContext dataContext, IMapper mapper) : IAddCommentStorage
{
    public async Task<CommentModel> AddComment(Guid productId, string name, string phone, string text, int rating, CancellationToken cancellationToken)
    {
        Comment comment = new Comment()
        {
            ProductId = productId,
            Name = name,
            Phone = phone,
            Text = text,
            Rating = rating,
            CreatedAt = DateTimeOffset.UtcNow
        };

        

        var Product = await dataContext.Products.FirstAsync(p => p.Id == productId, cancellationToken);
        Product.TotalCommentsQuantity++;
        Product.TotalRating += rating;

        await dataContext.Comments.AddAsync(comment, cancellationToken);
        await dataContext.SaveChangesAsync(cancellationToken);
        return mapper.Map<CommentModel>(comment);
    }

    public async Task<bool> IsUserBoughtProduct(Guid productId, string phone, CancellationToken cancellationToken)
    {

        var res = await dataContext.Database.SqlQueryRaw<int>(
               """
               SELECT COUNT(*) FROM "Orders" JOIN "OrderItems" AS "oi" ON "Orders"."Id" = "oi"."OrderId"
               WHERE "Phone" = @phone and
               "ProductId" = @productId
               """, phone, productId
            ).FirstAsync();
   

        return res > 0;
    }
}
