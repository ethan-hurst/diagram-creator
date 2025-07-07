using Microsoft.Office.Interop.Visio;
using System;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class TechnologyPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, "Technology Stack", "Page 5 of 6", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // Create technology stack diagram
            CreateTechnologyStackDiagram(page, config);
            
            // Create security framework section
            CreateSecurityFrameworkSection(page, config);
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreateTechnologyStackDiagram(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 120, 390, 130, "Technology Stack Architecture");
            
            double layerHeight = 25;
            double layerWidth = 370;
            double startX = 25;
            double startY = 210;
            
            // Frontend layer
            ShapeHelpers.CreateLayerBox(page, startX, startY, layerWidth, layerHeight,
                                      "Frontend Technologies", 
                                      string.Join(", ", config.Technology.Application.Frontend.Select(f => $"{f.Name} {f.Version}")),
                                      "RGB(99,102,241)");
            
            // Backend layer
            ShapeHelpers.CreateLayerBox(page, startX, startY - layerHeight - 3, layerWidth, layerHeight,
                                      "Backend Technologies", 
                                      string.Join(", ", config.Technology.Application.Backend.Select(b => $"{b.Name} {b.Version}")),
                                      "RGB(16,185,129)");
            
            // Database layer
            ShapeHelpers.CreateLayerBox(page, startX, startY - 2 * (layerHeight + 3), layerWidth, layerHeight,
                                      "Database Technologies", 
                                      string.Join(", ", config.Technology.Application.Database.Select(d => $"{d.Name} {d.Version}")),
                                      "RGB(245,158,11)");
            
            // Infrastructure layer
            ShapeHelpers.CreateLayerBox(page, startX, startY - 3 * (layerHeight + 3), layerWidth, layerHeight,
                                      "Cloud Infrastructure", 
                                      $"{config.Technology.Infrastructure.Cloud.Provider} - {config.Technology.Infrastructure.Cloud.Strategy}",
                                      "RGB(239,68,68)");
        }

        private static void CreateSecurityFrameworkSection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 30, 390, 80, "Security Framework");
            
            double boxWidth = 90;
            double boxHeight = 25;
            double startX = 25;
            double startY = 65;
            
            // Create security boxes in a row
            CreateSecurityBox(page, startX, startY, boxWidth, boxHeight,
                            "Identity Management", string.Join("\n", config.Technology.Security.IdentityManagement.Take(3).Select(i => $"• {i}")));
            
            CreateSecurityBox(page, startX + boxWidth + 10, startY, boxWidth, boxHeight,
                            "Network Security", string.Join("\n", config.Technology.Security.NetworkSecurity.Take(3).Select(n => $"• {n}")));
            
            CreateSecurityBox(page, startX + 2 * (boxWidth + 10), startY, boxWidth, boxHeight,
                            "Application Security", string.Join("\n", config.Technology.Security.ApplicationSecurity.Take(3).Select(a => $"• {a}")));
            
            CreateSecurityBox(page, startX + 3 * (boxWidth + 10), startY, boxWidth, boxHeight,
                            "Data Protection", string.Join("\n", config.Technology.Security.DataProtection.Take(3).Select(d => $"• {d}")));
            
            // Operations box spanning full width
            CreateSecurityBox(page, startX, startY - boxHeight - 5, boxWidth * 4 + 30, 20,
                            "Monitoring & Operations", 
                            $"Application: {string.Join(", ", config.Technology.Operations.ApplicationMonitoring.Take(2))}\n" +
                            $"Infrastructure: {string.Join(", ", config.Technology.Operations.InfrastructureMonitoring.Take(2))}");
        }

        private static void CreateSecurityBox(Page page, double x, double y, double width, double height, 
                                            string title, string content)
        {
            const double mmToInch = 0.0393701;
            
            // Main box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            box.CellsU["FillForegnd"].FormulaU = "RGB(255,255,255)";
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Title
            double titleHeight = height * 0.3;
            Shape titleShape = page.DrawRectangle(x * mmToInch, (y + height - titleHeight) * mmToInch, 
                                                 (x + width) * mmToInch, (y + height) * mmToInch);
            titleShape.Text = title;
            titleShape.CellsU["Char.Size"].FormulaU = "9pt";
            titleShape.CellsU["Char.Style"].FormulaU = "1";
            titleShape.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            titleShape.CellsU["FillForegnd"].FormulaU = "RGB(239,68,68)";
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