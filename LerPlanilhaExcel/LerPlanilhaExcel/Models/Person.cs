using LerPlanilhaExcel.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LerPlanilhaExcel.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Apelido")]
        public string Nickname { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} deve conter 11 dígitos! Exemplo: 69 9 1234-5678")]
        public string PhoneNumber { get; set; }
        public PaymentStatus Status { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Person()
        {
        }

        public Person(string name, string nickname, string phoneNumber, PaymentStatus status, Department department)
        {
            Name = name;
            Nickname = nickname;
            PhoneNumber = phoneNumber;
            Status = status;
            Department = department;
        }
    }
}
