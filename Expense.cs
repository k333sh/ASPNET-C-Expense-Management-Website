using System.ComponentModel.DataAnnotations;

namespace SpndSMRT.Models
{
    public class Expense
    {
        public int Id { get; set; }
        
        public decimal Value { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
