namespace TipsAPI.DataAccess.Entities
{
    public class Tip
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Source { get; set; }
    }
}
