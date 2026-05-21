namespace TransportFlow.API.Models
{
    public class Delivery
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool Completed { get; set; }
    }
}