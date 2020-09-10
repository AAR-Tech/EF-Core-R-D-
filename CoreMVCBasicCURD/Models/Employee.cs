using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCBasicCURD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column("FullName",TypeName = "nvarchar(250)")]
        [Required(ErrorMessage ="please enter employee full name..")]
        [DisplayName("Full Name")]
        public string FulllNmae { get; set; }

        [Column(TypeName = "varchar(10)")]
        [DisplayName("Employee UserName")]
        public string EmpCode { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Office Location")]
        public string OfficeLocation { get; set; }

    }
}
