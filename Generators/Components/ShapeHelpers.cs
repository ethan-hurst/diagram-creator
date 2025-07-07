using Microsoft.Office.Interop.Visio;
using System;

namespace VisioArchitectureGenerator.Generators.Components
{
    public static class ShapeHelpers
    {
        private const double MmToInch = 0.0393701;

        public static Shape CreateColoredBox(Page page, double x, double y, double width, double height, 
                                           string title, string content, string bgColor, string titleColor = "RGB(255,255,255)")
        {
            // Create main container
            Shape box = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            box.CellsU["FillForegnd"].FormulaU = bgColor;
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Create title section
            double titleHeight = height * 0.25;
            Shape titleShape = page.DrawRectangle(x * MmToInch, (y + height - titleHeight) * MmToInch, 
                                                 (x + width) * MmToInch, (y + height) * MmToInch);
            titleShape.Text = title;
            titleShape.CellsU["Char.Size"].FormulaU = "12pt";
            titleShape.CellsU["Char.Style"].FormulaU = "1"; // Bold
            titleShape.CellsU["Char.Color"].FormulaU = titleColor;
            titleShape.CellsU["FillForegnd"].FormulaU = "RGB(0,120,212)"; // Primary Blue
            titleShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            titleShape.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
            
            // Create content section
            Shape contentShape = page.DrawRectangle((x + 2) * MmToInch, (y + 2) * MmToInch, 
                                                   (x + width - 2) * MmToInch, (y + height - titleHeight - 2) * MmToInch);
            contentShape.Text = content;
            contentShape.CellsU["Char.Size"].FormulaU = "10pt";
            contentShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            contentShape.CellsU["Para.SpBefore"].FormulaU = "3pt";
            contentShape.CellsU["Para.SpAfter"].FormulaU = "3pt";
            
            return box;
        }

        public static Shape CreateSimpleBox(Page page, double x, double y, double width, double height, 
                                          string text, string bgColor = "RGB(255,255,255)")
        {
            Shape box = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            box.Text = text;
            box.CellsU["FillForegnd"].FormulaU = bgColor;
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            box.CellsU["Char.Size"].FormulaU = "10pt";
            box.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
            box.CellsU["Para.VertAlign"].FormulaU = "1"; // Middle align
            
            return box;
        }

        public static Shape CreateLayerBox(Page page, double x, double y, double width, double height,
                                         string layerName, string technologies, string color)
        {
            Shape layerBox = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            layerBox.CellsU["FillForegnd"].FormulaU = color;
            layerBox.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            layerBox.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Layer title (left 25% of box)
            double titleWidth = width * 0.25;
            Shape titleShape = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + titleWidth) * MmToInch, (y + height) * MmToInch);
            titleShape.Text = layerName;
            titleShape.CellsU["Char.Size"].FormulaU = "10pt";
            titleShape.CellsU["Char.Style"].FormulaU = "1"; // Bold
            titleShape.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            titleShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            titleShape.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
            titleShape.CellsU["Para.VertAlign"].FormulaU = "1"; // Middle align
            
            // Technologies (right 75% of box)
            Shape techShape = page.DrawRectangle((x + titleWidth) * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            techShape.Text = technologies;
            techShape.CellsU["Char.Size"].FormulaU = "9pt";
            techShape.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            techShape.CellsU["FillForegnd"].FormulaU = color;
            techShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            techShape.CellsU["Para.VertAlign"].FormulaU = "1"; // Middle align
            
            return layerBox;
        }

        public static Shape CreateContainer(Page page, double x, double y, double width, double height, 
                                          string title, string titleBgColor = "RGB(0,120,212)")
        {
            // Main container
            Shape container = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            container.CellsU["FillForegnd"].FormulaU = "RGB(248,249,250)"; // Light gray background
            container.CellsU["LineColor"].FormulaU = "RGB(107,114,128)"; // Border
            container.CellsU["LineWeight"].FormulaU = "2pt";
            
            // Title bar
            double titleHeight = 15; // Fixed height for title
            Shape titleBar = page.DrawRectangle(x * MmToInch, (y + height - titleHeight) * MmToInch, 
                                               (x + width) * MmToInch, (y + height) * MmToInch);
            titleBar.Text = title;
            titleBar.CellsU["Char.Size"].FormulaU = "14pt";
            titleBar.CellsU["Char.Style"].FormulaU = "1"; // Bold
            titleBar.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            titleBar.CellsU["FillForegnd"].FormulaU = titleBgColor;
            titleBar.CellsU["LinePattern"].FormulaU = "0"; // No border
            titleBar.CellsU["Para.HorzAlign"].FormulaU = "1"; // Center align
            
            return container;
        }

        public static void SetupA3Page(Page page)
        {
            // Set page to A3 size (420mm x 297mm)
            page.PageSheet.CellsU["PageWidth"].Formula = "420mm";
            page.PageSheet.CellsU["PageHeight"].Formula = "297mm";
            page.PageSheet.CellsU["PrintPageOrientation"].Formula = "2"; // Landscape
            
            // Set margins
            page.PageSheet.CellsU["PageLeftMargin"].Formula = "10mm";
            page.PageSheet.CellsU["PageRightMargin"].Formula = "10mm";
            page.PageSheet.CellsU["PageTopMargin"].Formula = "10mm";
            page.PageSheet.CellsU["PageBottomMargin"].Formula = "10mm";
            
            // Set drawing scale
            page.PageSheet.CellsU["DrawingScale"].Formula = "1";
            page.PageSheet.CellsU["PageScale"].Formula = "1";
        }

        public static double MmToInches(double mm)
        {
            return mm * MmToInch;
        }

        public static Shape CreateTextOnlyShape(Page page, double x, double y, double width, double height, 
                                              string text, string fontSize = "10pt")
        {
            Shape textShape = page.DrawRectangle(x * MmToInch, y * MmToInch, (x + width) * MmToInch, (y + height) * MmToInch);
            textShape.Text = text;
            textShape.CellsU["Char.Size"].FormulaU = fontSize;
            textShape.CellsU["LinePattern"].FormulaU = "0"; // No border
            textShape.CellsU["FillPattern"].FormulaU = "0"; // No fill
            
            return textShape;
        }
    }
}