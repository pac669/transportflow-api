using System.ComponentModel.DataAnnotations;
namespace TransportFlow.API.DTOs
{
    public class DeliveryDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Address { get; set; } = string.Empty;

        public DateTime DeliveryDate { get; set; }

        public bool Completed { get; set; }
    }
}