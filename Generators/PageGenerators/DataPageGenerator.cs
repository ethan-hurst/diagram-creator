using Microsoft.Office.Interop.Visio;
using System;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class DataPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, "Data Architecture", "Page 4 of 6", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // Create data types section
            CreateDataTypesSection(page, config);
            
            // Create data stores section
            CreateDataStoresSection(page, config);
            
            // Create data governance section
            CreateDataGovernanceSection(page, config);
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreateDataTypesSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 180, 390, 70, "Data Types & Architecture");
            
            double boxWidth = 120;
            double boxHeight = 45;
            double startX = 25;
            double startY = 185;
            
            // Create data type boxes
            for (int i = 0; i < Math.Min(config.Data.DataTypes.Count, 3); i++)
            {
                var dataType = config.Data.DataTypes[i];
                double x = startX + (i * (boxWidth + 10));
                
                CreateDataTypeBox(page, x, startY, boxWidth, boxHeight, dataType);
            }
        }

        private static void CreateDataTypeBox(Page page, double x, double y, double width, double height, DataType dataType)
        {
            const double mmToInch = 0.0393701;
            
            // Main box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            box.CellsU["FillForegnd"].FormulaU = "RGB(255,255,255)";
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Header
            double headerHeight = height * 0.25;
            Shape header = page.DrawRectangle(x * mmToInch, (y + height - headerHeight) * mmToInch, 
                                            (x + width) * mmToInch, (y + height) * mmToInch);
            header.Text = $"{dataType.Name}\n({dataType.Category})";
            header.CellsU["Char.Size"].FormulaU = "9pt";
            header.CellsU["Char.Style"].FormulaU = "1";
            header.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            header.CellsU["FillForegnd"].FormulaU = "RGB(16,185,129)";
            header.CellsU["LinePattern"].FormulaU = "0";
            header.CellsU["Para.HorzAlign"].FormulaU = "1";
            
            // Content
            Shape content = page.DrawRectangle((x + 1) * mmToInch, (y + 1) * mmToInch, 
                                             (x + width - 1) * mmToInch, (y + height - headerHeight - 1) * mmToInch);
            content.Text = $"{dataType.Description}\n\nVolume: {dataType.Volume}\nUpdate: {dataType.UpdateFrequency}";
            content.CellsU["Char.Size"].FormulaU = "8pt";
            content.CellsU["LinePattern"].FormulaU = "0";
        }

        private static void CreateDataStoresSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 100, 185, 75, "Data Stores");
            
            string dataStoresText = string.Join("\n\n", config.Data.DataStores.Take(3).Select(ds => 
                $"• {ds.Name}\n  Type: {ds.Type}\n  Tech: {ds.Technology}"));
            
            ShapeHelpers.CreateTextOnlyShape(page, 20, 105, 175, 55, dataStoresText, "8pt");
        }

        private static void CreateDataGovernanceSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 210, 100, 195, 75, "Data Governance");
            
            double sectionWidth = 90;
            double sectionHeight = 25;
            double startX = 215;
            double startY = 130;
            
            // Create governance boxes in 2x2 grid
            CreateGovernanceBox(page, startX, startY, sectionWidth, sectionHeight,
                              "Quality Measures", string.Join("\n", config.Data.Governance.QualityMeasures.Take(3).Select(q => $"• {q}")));
            
            CreateGovernanceBox(page, startX + sectionWidth + 5, startY, sectionWidth, sectionHeight,
                              "Security Controls", string.Join("\n", config.Data.Governance.SecurityControls.Take(3).Select(s => $"• {s}")));
            
            CreateGovernanceBox(page, startX, startY - sectionHeight - 5, sectionWidth, sectionHeight,
                              "Retention Policies", string.Join("\n", config.Data.Governance.RetentionPolicies.Take(3).Select(r => $"• {r}")));
            
            CreateGovernanceBox(page, startX + sectionWidth + 5, startY - sectionHeight - 5, sectionWidth, sectionHeight,
                              "Compliance", string.Join("\n", config.Data.Governance.ComplianceRequirements.Take(3).Select(c => $"• {c}")));
        }

        private static void CreateGovernanceBox(Page page, double x, double y, double width, double height, 
                                              string title, string content)
        {
            const double mmToInch = 0.0393701;
            
            // Main box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            box.CellsU["FillForegnd"].FormulaU = "RGB(255,255,255)";
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Title
            double titleHeight = height * 0.25;
            Shape titleShape = page.DrawRectangle(x * mmToInch, (y + height - titleHeight) * mmToInch, 
                                                 (x + width) * mmToInch, (y + height) * mmToInch);
            titleShape.Text = title;
            titleShape.CellsU["Char.Size"].FormulaU = "9pt";
            titleShape.CellsU["Char.Style"].FormulaU = "1";
            titleShape.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            titleShape.CellsU["FillForegnd"].FormulaU = "RGB(245,158,11)";
            titleShape.CellsU["LinePattern"].FormulaU = "0";
            titleShape.CellsU["Para.HorzAlign"].FormulaU = "1";
            
            // Content
            Shape contentShape = page.DrawRectangle((x + 1) * mmToInch, (y + 1) * mmToInch, 
                                                   (x + width - 1) * mmToInch, (y + height - titleHeight - 1) * mmToInch);
            contentShape.Text = content;
            contentShape.CellsU["Char.Size"].FormulaU = "7pt";
            contentShape.CellsU["LinePattern"].FormulaU = "0";
        }
    }
}