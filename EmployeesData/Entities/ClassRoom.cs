using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesData.Entities
{
    public class ClassRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int ClassRoomId { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string? ClassName { get; set; }
        public Teacher teacher { get; set; }


    }
}
