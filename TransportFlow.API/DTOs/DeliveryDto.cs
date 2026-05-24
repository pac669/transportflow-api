namespace TransportFlow.API.DTOs
{
    public class DeliveryDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }

        public bool Completed { get; set; }
    }
}