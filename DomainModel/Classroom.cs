using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel
{
    [Table(nameof(Classroom))]
    public class Classroom
    {
        public int ClassroomId { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, 8)]
        public int Floor { get; set; }

        public string Corridor { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
