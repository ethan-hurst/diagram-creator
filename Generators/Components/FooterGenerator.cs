using Microsoft.Office.Interop.Visio;
using System;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.Components
{
    public static class FooterGenerator
    {
        public static void CreateFooter(Page page, ArchitectureConfiguration config)
        {
            const double mmToInch = 0.0393701;
            
            Shape footer = page.DrawRectangle(10 * mmToInch, 10 * mmToInch, 410 * mmToInch, 25 * mmToInch);
            footer.Text = $"Generated: {DateTime.Now:yyyy-MM-dd HH:mm} | {config.Project.Company} | Version: {config.Project.Version} | Author: {config.Project.Author}";
            footer.CellsU["Char.Size"].FormulaU = "9pt";
            footer.CellsU["FillForegnd"].FormulaU = "RGB(248,249,250)";
            footer.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            footer.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
        }
    }
}