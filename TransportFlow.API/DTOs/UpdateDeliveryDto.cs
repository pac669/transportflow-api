using System.ComponentModel.DataAnnotations;

namespace TransportFlow.API.DTOs
{
    public class UpdateDeliveryDto
    {
        [Required]
        [MinLength(1)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Address { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }

        public bool Completed { get; set; }
    }
}