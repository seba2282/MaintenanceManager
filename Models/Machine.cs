using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManager.Models
{
    public class Machine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<MaintenanceTask> MaintenanceTasks { get; set; }
    }
}
