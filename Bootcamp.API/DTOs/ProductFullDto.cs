namespace Bootcamp.API.DTOs
{
    public class ProductFullDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
    }
}
