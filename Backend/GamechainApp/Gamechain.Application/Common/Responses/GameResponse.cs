namespace Gamechain.Application.Common.Responses
{
    public class GameResponse
    {
        public Guid Id { get; set; }
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }

    }
}
