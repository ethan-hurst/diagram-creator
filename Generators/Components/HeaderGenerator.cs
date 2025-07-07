using Microsoft.Office.Interop.Visio;
using System;

namespace VisioArchitectureGenerator.Generators.Components
{
    public static class HeaderGenerator
    {
        public static void CreateHeader(Page page, string title, string version, string date)
        {
            const double mmToInch = 0.0393701;
            
            // Main title rectangle
            Shape titleShape = page.DrawRectangle(10 * mmToInch, 280 * mmToInch, 300 * mmToInch, 297 * mmToInch);
            titleShape.Text = title;
            titleShape.CellsU["Char.Size"].FormulaU = "18pt";
            titleShape.CellsU["Char.Style"].FormulaU = "1"; // Bold
            titleShape.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)"; // White text
            titleShape.CellsU["FillForegnd"].FormulaU = "RGB(0,120,212)"; // Primary Blue
            titleShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            titleShape.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
            
            // Version/date info rectangle
            Shape infoShape = page.DrawRectangle(300 * mmToInch, 280 * mmToInch, 410 * mmToInch, 297 * mmToInch);
            infoShape.Text = $"{version}\n{date}";
            infoShape.CellsU["Char.Size"].FormulaU = "12pt";
            infoShape.CellsU["FillForegnd"].FormulaU = "RGB(248,249,250)"; // Light gray
            infoShape.CellsU["LineColor"].FormulaU = "RGB(107,114,128)"; // Border gray
            infoShape.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
        }
    }
}