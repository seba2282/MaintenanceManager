using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceManager.Models
{
    public class MaintenanceTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime ScheduledDate { get; set; }

        [ForeignKey("Machine")]
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
