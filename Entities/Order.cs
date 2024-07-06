namespace ProductManagement.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateOnly OrderDate { get; set; }
        public int TotalAmount { get; set; }

    }
}
