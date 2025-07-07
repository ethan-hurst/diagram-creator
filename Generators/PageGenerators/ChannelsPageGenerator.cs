using Microsoft.Office.Interop.Visio;
using System;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class ChannelsPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, "Channels & Business Units", "Page 3 of 6", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // Create channels section (left side)
            CreateChannelsSection(page, config);
            
            // Create business units section (right side)
            CreateBusinessUnitsSection(page, config);
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreateChannelsSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 100, 190, 150, "Channel Architecture");
            
            double yPos = 220;
            
            // Digital channels
            ShapeHelpers.CreateColoredBox(page, 20, yPos, 90, 30, "Digital Channels", 
                string.Join("\n", config.Channels.Digital.Select(c => $"• {c.Name}")),
                "RGB(255,255,255)", "RGB(16,185,129)");
            
            // Traditional channels
            ShapeHelpers.CreateColoredBox(page, 110, yPos, 90, 30, "Traditional Channels", 
                string.Join("\n", config.Channels.Traditional.Select(c => $"• {c.Name}")),
                "RGB(255,255,255)", "RGB(245,158,11)");
            
            yPos -= 45;
            
            // Integration strategy
            ShapeHelpers.CreateColoredBox(page, 20, yPos, 180, 40, "Integration Strategy", 
                $"{config.Channels.Integration.Strategy}\n\nShared Services:\n" + 
                string.Join("\n", config.Channels.Integration.SharedServices.Take(3).Select(s => $"• {s}")),
                "RGB(255,255,255)", "RGB(0,120,212)");
        }

        private static void CreateBusinessUnitsSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 215, 100, 190, 150, "Business Units");
            
            double unitWidth = 85;
            double unitHeight = 40;
            double startX = 220;
            double startY = 190;
            
            // Create business unit boxes in 2x2 grid
            for (int i = 0; i < Math.Min(config.BusinessUnits.Count, 4); i++)
            {
                var unit = config.BusinessUnits[i];
                double x = startX + (i % 2) * (unitWidth + 10);
                double y = startY - (i / 2) * (unitHeight + 10);
                
                CreateBusinessUnitBox(page, x, y, unitWidth, unitHeight, unit);
            }
        }

        private static void CreateBusinessUnitBox(Page page, double x, double y, double width, double height, BusinessUnit unit)
        {
            const double mmToInch = 0.0393701;
            
            // Main box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            string bgColor = unit.Type == "Core" ? "RGB(255,255,255)" : "RGB(240,245,255)";
            box.CellsU["FillForegnd"].FormulaU = bgColor;
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Header with unit name and type
            double headerHeight = height * 0.3;
            Shape header = page.DrawRectangle(x * mmToInch, (y + height - headerHeight) * mmToInch, 
                                            (x + width) * mmToInch, (y + height) * mmToInch);
            header.Text = $"{unit.Name}\n({unit.Type})";
            header.CellsU["Char.Size"].FormulaU = "9pt";
            header.CellsU["Char.Style"].FormulaU = "1"; // Bold
            string headerColor = unit.Type == "Core" ? "RGB(0,120,212)" : "RGB(16,185,129)";
            header.CellsU["FillForegnd"].FormulaU = headerColor;
            header.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            header.CellsU["LinePattern"].FormulaU = "0";
            header.CellsU["Para.HorzAlign"].FormulaU = "1";
            
            // Content with description and key functions
            Shape content = page.DrawRectangle((x + 1) * mmToInch, (y + 1) * mmToInch, 
                                             (x + width - 1) * mmToInch, (y + height - headerHeight - 1) * mmToInch);
            content.Text = $"{unit.Description}\n\nKey Functions:\n" + 
                          string.Join("\n", unit.KeyFunctions.Take(2).Select(f => $"• {f}"));
            content.CellsU["Char.Size"].FormulaU = "7pt";
            content.CellsU["LinePattern"].FormulaU = "0";
        }
    }
}