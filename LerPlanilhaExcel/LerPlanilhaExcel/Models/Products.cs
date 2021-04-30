using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LerPlanilhaExcel.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public Products(int codigo, string descricao, double preco)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }
    }
}
