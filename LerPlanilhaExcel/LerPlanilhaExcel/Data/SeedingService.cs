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

            var xls = new XLWorkbook(@"C:\Users\James\Documents\Cod. Fontes\C#\excel-para-sqlserve-aspnet\ExemploExcel.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Planilha1");
            var totalLinhas = planilha.Rows().Count();

            // primeira linha é o cabecalho
            for (int l = 2; l <= totalLinhas; l++)
            {
                string nome = planilha.Cell($"A{l}").Value.ToString();
                if (nome == "")
                    nome = null;
                string apelido = planilha.Cell($"B{l}").Value.ToString();
                if (apelido == "")
                    apelido = null;
                Department department = _context.Departments.FirstOrDefault();

                Person person = new Person(nome, apelido, null, Models.Enums.PaymentStatus.Pago, department);

                _context.People.Add(person);
            }
            _context.SaveChanges();
        }
    }
}
