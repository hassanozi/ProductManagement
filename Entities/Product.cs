namespace ProductManagement.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private decimal price;
        public decimal Price
        {
            get
            {
                { return this.price; }
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price should be positive!");
                }
                else
                {
                    this.price = value;
                }
            }
        }
        private decimal stock;
        public decimal Stock
        {
            get
            {
                { return this.stock; }
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The stock should be positive!");
                }
                else
                {
                    this.stock = value;
                }
            }
        }

        public Order order { get; set; }
        public int OrderId { get; set; }
    }
}
