using Microsoft.Office.Interop.Visio;
using System;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class ImplementationPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, "Implementation Roadmap", "Page 6 of 6", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // Create implementation timeline
            CreateImplementationTimeline(page, config);
            
            // Create risks and governance section
            CreateRisksAndGovernance(page, config);
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreateImplementationTimeline(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 150, 390, 100, "Implementation Timeline");
            
            double phaseHeight = 20;
            double phaseWidth = 370 / Math.Max(config.Implementation.Phases.Count, 1);
            double startX = 25;
            double startY = 210;
            
            // Create phase boxes
            for (int i = 0; i < config.Implementation.Phases.Count; i++)
            {
                var phase = config.Implementation.Phases[i];
                double x = startX + (i * phaseWidth);
                
                CreatePhaseBox(page, x, startY, phaseWidth, phaseHeight, phase, i + 1);
                CreatePhaseDetails(page, x, startY - 35, phaseWidth, 30, phase);
            }
        }

        private static void CreatePhaseBox(Page page, double x, double y, double width, double height, 
                                         ImplementationPhase phase, int phaseNumber)
        {
            const double mmToInch = 0.0393701;
            
            string[] colors = { "RGB(99,102,241)", "RGB(16,185,129)", "RGB(245,158,11)", "RGB(239,68,68)" };
            string color = colors[(phaseNumber - 1) % colors.Length];
            
            // Main phase box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            box.CellsU["FillForegnd"].FormulaU = color;
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Phase text
            Shape text = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            text.Text = $"Phase {phaseNumber}: {phase.Name}\n{phase.StartDate:MMM yyyy} - {phase.EndDate:MMM yyyy}";
            text.CellsU["Char.Size"].FormulaU = "8pt";
            text.CellsU["Char.Style"].FormulaU = "1";
            text.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            text.CellsU["LinePattern"].FormulaU = "0";
            text.CellsU["Para.HorzAlign"].FormulaU = "1";
            text.CellsU["Para.VertAlign"].FormulaU = "1";
        }

        private static void CreatePhaseDetails(Page page, double x, double y, double width, double height, 
                                             ImplementationPhase phase)
        {
            const double mmToInch = 0.0393701;
            
            // Details box
            Shape box = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            box.CellsU["FillForegnd"].FormulaU = "RGB(255,255,255)";
            box.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            box.CellsU["LineWeight"].FormulaU = "1pt";
            
            // Content
            Shape content = page.DrawRectangle((x + 1) * mmToInch, (y + 1) * mmToInch, 
                                             (x + width - 1) * mmToInch, (y + height - 1) * mmToInch);
            content.Text = $"{phase.Description}\n\nKey Deliverables:\n" + 
                          string.Join("\n", phase.Deliverables.Take(3).Select(d => $"• {d}")) +
                          $"\n\nStatus: {phase.Status}";
            content.CellsU["Char.Size"].FormulaU = "7pt";
            content.CellsU["LinePattern"].FormulaU = "0";
        }

        private static void CreateRisksAndGovernance(Page page, ArchitectureConfiguration config)
        {
            // Risks section (left side)
            ShapeHelpers.CreateContainer(page, 15, 30, 185, 110, "Key Risks & Mitigation");
            
            string risksText = string.Join("\n\n", config.Implementation.Risks.Take(3).Select(r => 
                $"• {r.Description}\n  Impact: {r.Impact} | Probability: {r.Probability}\n  Mitigation: {r.Mitigation}"));
            
            ShapeHelpers.CreateTextOnlyShape(page, 20, 35, 175, 85, risksText, "8pt");
            
            // Governance section (right side)
            ShapeHelpers.CreateContainer(page, 220, 30, 185, 110, "Governance Structure");
            
            string governanceText = $"Decision Making:\n{string.Join("\n", config.Implementation.Governance.DecisionMaking.Take(3).Select(d => $"• {d}"))}\n\n" +
                                   $"Review Cycles:\n{string.Join("\n", config.Implementation.Governance.ReviewCycles.Take(3).Select(r => $"• {r}"))}\n\n" +
                                   $"Quality Gates:\n{string.Join("\n", config.Implementation.Governance.QualityGates.Take(2).Select(q => $"• {q}"))}";
            
            ShapeHelpers.CreateTextOnlyShape(page, 225, 35, 175, 85, governanceText, "8pt");
        }
    }
}