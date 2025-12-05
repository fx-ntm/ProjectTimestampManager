using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimestampManager.Models
{
    /// <summary>
    /// Project - Model for table db.projects, represents a project with allocated hours
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id - Primary Key of the project
        /// </summary>
        public required int Id { get; set; }
        /// <summary>
        /// Name - Name of the project
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// AllocatedHours - The total allocated hours for the project
        /// </summary>
        public required int AllocatedHours { get; set; }
        /// <summary>
        /// Deadline - The date-time entry, after which no new project time entries can be added
        /// </summary>
        public required DateTime Deadline { get; set; }
    }
}
