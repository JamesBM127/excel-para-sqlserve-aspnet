using System;
using System.Linq;
using ClosedXML.Excel;

namespace ExcelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var xls = new XLWorkbook(@"C:\Users\James\Desktop\LerExcel\ExemploExcel.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Plan1");
            var totalLinhas = planilha.Rows().Count();
            // primeira linha é o cabecalho
            for (int l = 2; l <= totalLinhas; l++)
            {
                var codigo = int.Parse(planilha.Cell($"A{l}").Value.ToString());
                var descricao = planilha.Cell($"B{l}").Value.ToString();
                var preco = decimal.Parse(planilha.Cell($"C{l}").Value.ToString());
                Console.WriteLine($"{codigo} - {descricao} - {preco}");
            }
        }
    }
}
