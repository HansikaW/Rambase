using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class EmployeeDetail
    {
        [Key]
        public int EId { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(100)")]
        public string EmployeeName { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(10)")]
        public string PhoneNo { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(10)")]
        public string BDay { get; set; }
        [Required]
        [Column(TypeName = "Nvarchar(10)")]
        public string Nic { get; set; }
    }
}
