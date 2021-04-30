using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using LerPlanilhaExcel.Models;

namespace LerPlanilhaExcel.Data
{
    public class SeedingService
    {
        private TesteContext _context;

        public SeedingService(TesteContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Products.Any())
            {
                return;
            }

            var xls = new XLWorkbook(@"C:\Users\James\Desktop\LerExcel\ExemploExcel.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Plan1");
            var totalLinhas = planilha.Rows().Count();

            // primeira linha é o cabecalho
            for (int l = 2; l <= totalLinhas; l++)
            {

                    int codigo = int.Parse(planilha.Cell($"A{l}").Value.ToString());
                    string descricao = planilha.Cell($"B{l}").Value.ToString();
                    double preco = double.Parse(planilha.Cell($"C{l}").Value.ToString());
                    Products products = new Products(codigo, descricao, preco);
                    _context.Products.Add(products);


            }
            _context.SaveChanges();
        }
    }
}
