using System.ComponentModel.DataAnnotations;

namespace Miramar.Domain.Entities
{
    public class Timesheet : Common
    {
        public int Id { get; set; }

        [Required]
        public string? Building { get; set; } 
        public string? Unit {  get; set; }  
        public decimal Hours {  get; set; } 
        public string? MaterialCost { get; set; }    
        public string? OtherCharges { get; set; }    
        public DateTime Date { get; set; }
        public string? Description {  get; set; }    
        public string? WorkOrder {  get; set; }
    }
}
