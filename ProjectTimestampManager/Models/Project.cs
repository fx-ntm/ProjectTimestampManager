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
    internal class Project
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
    }
}
