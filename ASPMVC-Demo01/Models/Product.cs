namespace ASPMVC_Demo01.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public bool IsAvailable()
        {
            return Quantity > 0;
        }
    }
}
