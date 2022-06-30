using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesData.Entities
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int TeacherId { get; set; }

        [Column(TypeName = "Varchar(50)")]
        public string? TeacherName { get; set; }
        public long ? TeacherMobNumber { get; set; }
        public ICollection<ClassRoom>? ClassRoomList { get; set; }

    }
}
