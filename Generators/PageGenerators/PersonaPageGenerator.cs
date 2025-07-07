using Microsoft.Office.Interop.Visio;
using System;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class PersonaPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, "Users & Personas", "Page 2 of 6", DateTime.Now.ToString("yyyy-MM-dd"));
            
            // Create persona cards
            CreatePersonaCards(page, config);
            
            // Create user summary section if we have stakeholders
            if (config.Business.Stakeholders.Any())
            {
                CreateUserSummarySection(page, config);
            }
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreatePersonaCards(Page page, ArchitectureConfiguration config)
        {
            double cardWidth = 120;
            double cardHeight = 80;
            double startX = 15;
            double startY = 200;
            double spacing = 10;

            // Create up to 3 persona cards
            for (int i = 0; i < Math.Min(config.Personas.Count, 3); i++)
            {
                var persona = config.Personas[i];
                double x = startX + (i * (cardWidth + spacing));
                CreatePersonaCard(page, x, startY, cardWidth, cardHeight, persona);
            }
        }

        private static void CreatePersonaCard(Page page, double x, double y, double width, double height, UserPersona persona)
        {
            const double mmToInch = 0.0393701;

            // Card container
            Shape card = page.DrawRectangle(x * mmToInch, y * mmToInch, (x + width) * mmToInch, (y + height) * mmToInch);
            card.CellsU["FillForegnd"].FormulaU = "RGB(255,255,255)";
            card.CellsU["LineColor"].FormulaU = "RGB(107,114,128)";
            card.CellsU["LineWeight"].FormulaU = "2pt";
            
            // Header with name and role
            double headerHeight = height * 0.15;
            Shape header = page.DrawRectangle(x * mmToInch, (y + height - headerHeight) * mmToInch, 
                                            (x + width) * mmToInch, (y + height) * mmToInch);
            header.Text = $"{persona.Name}\n{persona.Role}";
            header.CellsU["Char.Size"].FormulaU = "11pt";
            header.CellsU["Char.Style"].FormulaU = "1"; // Bold
            header.CellsU["Char.Color"].FormulaU = "RGB(255,255,255)";
            header.CellsU["FillForegnd"].FormulaU = "RGB(0,120,212)";
            header.CellsU["LinePattern"].FormulaU = "0";
            header.CellsU["Para.HorzAlign"].FormulaU = "1";
            
            // Content sections
            double sectionHeight = (height - headerHeight) / 4;
            double currentY = y + height - headerHeight;
            
            CreatePersonaSection(page, x, currentY - sectionHeight, width, sectionHeight, 
                               "Background", string.Join(", ", persona.Background.Take(2)));
            currentY -= sectionHeight;
            
            CreatePersonaSection(page, x, currentY - sectionHeight, width, sectionHeight, 
                               "Goals", string.Join(", ", persona.Goals.Take(2)));
            currentY -= sectionHeight;
            
            CreatePersonaSection(page, x, currentY - sectionHeight, width, sectionHeight, 
                               "Pain Points", string.Join(", ", persona.PainPoints.Take(2)));
            currentY -= sectionHeight;
            
            CreatePersonaSection(page, x, currentY - sectionHeight, width, sectionHeight, 
                               $"Tech Skills: {persona.TechSkillLevel}", 
                               $"Preferred: {string.Join(", ", persona.PreferredChannels.Take(2))}");
        }

        private static void CreatePersonaSection(Page page, double x, double y, double width, double height, 
                                               string title, string content)
        {
            const double mmToInch = 0.0393701;

            Shape section = page.DrawRectangle((x + 2) * mmToInch, (y + 1) * mmToInch, 
                                             (x + width - 2) * mmToInch, (y + height - 1) * mmToInch);
            section.Text = $"{title}:\n{content}";
            section.CellsU["Char.Size"].FormulaU = "8pt";
            section.CellsU["LinePattern"].FormulaU = "0";
            section.CellsU["Para.SpAfter"].FormulaU = "2pt";
        }

        private static void CreateUserSummarySection(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 15, 100, 390, 80, "User Base Summary");
            
            var totalUsers = config.Business.Stakeholders.Sum(s => s.UserCount);
            var primaryUsers = config.Business.Stakeholders.Where(s => s.Type == "Primary").Sum(s => s.UserCount);
            var secondaryUsers = config.Business.Stakeholders.Where(s => s.Type == "Secondary").Sum(s => s.UserCount);
            
            string summaryText = $"Total Users: {totalUsers:N0}\n" +
                               $"Primary Users: {primaryUsers:N0} ({(totalUsers > 0 ? primaryUsers * 100.0 / totalUsers : 0):F1}%)\n" +
                               $"Secondary Users: {secondaryUsers:N0} ({(totalUsers > 0 ? secondaryUsers * 100.0 / totalUsers : 0):F1}%)\n\n" +
                               $"Key Stakeholder Groups:\n" +
                               string.Join("\n", config.Business.Stakeholders.Take(4).Select(s => $"• {s.Name}: {s.UserCount:N0} users"));
            
            ShapeHelpers.CreateTextOnlyShape(page, 20, 105, 385, 60, summaryText, "10pt");
        }
    }
}