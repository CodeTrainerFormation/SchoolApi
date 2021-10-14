using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Teacher")]
    public class Teacher : Person
    {
        public string Discipline { get; set; }

        public DateTime HiringDate { get; set; }

        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }

    }
}
