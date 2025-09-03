namespace Storage.Entities;

public class CommentModel
{
    public Guid Id { get; set; }
    public Guid? CommentId { get; set; }
    public Guid ProductId { get; set; }
    public List<CommentModel>? Comments { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public required string Text { get; set; }
    public int Rating { get; set; }
    public int Like { get; set; }
    public int Dislike { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
