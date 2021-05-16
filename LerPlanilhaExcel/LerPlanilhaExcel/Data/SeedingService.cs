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
            if (_context.People.Any())
            {
                return;
            }

            var xls = new XLWorkbook(@"C:\Users\James\Desktop\excel-para-sqlserve-aspnet\ExemploExcel.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");
            var totalLinhas = planilha.Rows().Count();

            // primeira linha é o cabecalho
            for (int l = 2; l <= totalLinhas; l++)
            {
                string nome = planilha.Cell($"A{l}").Value.ToString();
                string apelido = planilha.Cell($"B{l}").Value.ToString();

                Department department = _context.Departments.FirstOrDefault();

                Person person = new Person(nome, apelido, "", Models.Enums.PaymentStatus.Pago, department);

                _context.People.Add(person);

                Department ortorrinolaringologista = new Department();

            }
            _context.SaveChanges();
        }
    }
}
