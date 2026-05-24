namespace TransportFlow.API.DTOs
{
    public class CreateDeliveryDto
    {
        public string CustomerName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }
    }
}