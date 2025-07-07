using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators
{
    public class SvgGenerator
    {
        private ArchitectureConfiguration? config;
        private StringBuilder svgContent;
        private const int PageWidth = 1200; // A3 equivalent in pixels at 72 DPI
        private const int PageHeight = 850;

        public SvgGenerator()
        {
            svgContent = new StringBuilder();
        }

        public void CreateArchitectureDocument(ArchitectureConfiguration configuration, string outputPath)
        {
            this.config = configuration;
            
            try
            {
                Console.WriteLine("🔧 Initializing SVG generation...");
                
                GenerateAllPages();
                SaveDocument(outputPath);
                
                Console.WriteLine("✅ SVG architecture document generation completed successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"SVG Generation Error: {ex.Message}", ex);
            }
        }

        private void GenerateAllPages()
        {
            Console.WriteLine("🎨 Generating SVG content...");
            
            if (config == null) throw new InvalidOperationException("Configuration is not initialized");
            
            StartSvgDocument();
            
            // Generate each page as a separate section
            Console.WriteLine("  📋 Creating overview page...");
            CreateOverviewPage(0);
            
            Console.WriteLine("  👥 Creating users & personas page...");
            CreatePersonaPage(PageHeight + 50);
            
            Console.WriteLine("  🏢 Creating channels & business units page...");
            CreateChannelsPage(2 * (PageHeight + 50));
            
            Console.WriteLine("  🗄️ Creating data architecture page...");
            CreateDataPage(3 * (PageHeight + 50));
            
            Console.WriteLine("  💻 Creating technology stack page...");
            CreateTechnologyPage(4 * (PageHeight + 50));
            
            Console.WriteLine("  🗺️ Creating implementation roadmap page...");
            CreateImplementationPage(5 * (PageHeight + 50));
            
            EndSvgDocument();
            
            Console.WriteLine("✅ All pages generated successfully.");
        }

        private void StartSvgDocument()
        {
            int totalHeight = 6 * (PageHeight + 50); // 6 pages with spacing
            
            svgContent.AppendLine($@"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""{PageWidth}"" height=""{totalHeight}"" xmlns=""http://www.w3.org/2000/svg"">
<defs>
    <style>
        .page-title {{ font-family: Arial, sans-serif; font-size: 24px; font-weight: bold; fill: white; }}
        .section-title {{ font-family: Arial, sans-serif; font-size: 18px; font-weight: bold; fill: white; }}
        .content-title {{ font-family: Arial, sans-serif; font-size: 14px; font-weight: bold; fill: white; }}
        .content-text {{ font-family: Arial, sans-serif; font-size: 12px; fill: #333; }}
        .small-text {{ font-family: Arial, sans-serif; font-size: 10px; fill: #333; }}
        .footer-text {{ font-family: Arial, sans-serif; font-size: 9px; fill: #666; }}
    </style>
</defs>");
        }

        private void EndSvgDocument()
        {
            svgContent.AppendLine("</svg>");
        }

        private void CreateOverviewPage(int yOffset)
        {
            // Page background
            CreatePageBackground(yOffset, "1. Architecture Overview");
            
            // Header
            CreateHeader(yOffset, config!.Project.Name, $"Version {config.Project.Version}");
            
            // Business Context Quadrant
            CreateBusinessContextQuadrant(50, yOffset + 120);
            
            // Architecture Principles Quadrant  
            CreateArchitecturePrinciplesQuadrant(650, yOffset + 120);
            
            // System Scope Quadrant
            CreateSystemScopeQuadrant(50, yOffset + 400);
            
            // Stakeholder Matrix Quadrant
            CreateStakeholderMatrixQuadrant(650, yOffset + 400);
            
            // Footer
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreatePersonaPage(int yOffset)
        {
            CreatePageBackground(yOffset, "2. Users & Personas");
            CreateHeader(yOffset, "Users & Personas", "Page 2 of 6");
            
            // Persona cards
            int cardWidth = 350;
            int cardHeight = 200;
            int startX = 50;
            int startY = yOffset + 150;
            
            for (int i = 0; i < Math.Min(config!.Personas.Count, 3); i++)
            {
                var persona = config.Personas[i];
                int x = startX + (i % 3) * (cardWidth + 50);
                int y = startY + (i / 3) * (cardHeight + 50);
                
                CreatePersonaCard(x, y, cardWidth, cardHeight, persona);
            }
            
            // User summary
            if (config.Business.Stakeholders.Any())
            {
                CreateUserSummary(50, yOffset + 400);
            }
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateChannelsPage(int yOffset)
        {
            CreatePageBackground(yOffset, "3. Channels & Business Units");
            CreateHeader(yOffset, "Channels & Business Units", "Page 3 of 6");
            
            // Channels section (left)
            CreateChannelsSection(50, yOffset + 150);
            
            // Business units section (right)
            CreateBusinessUnitsSection(650, yOffset + 150);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateDataPage(int yOffset)
        {
            CreatePageBackground(yOffset, "4. Data Architecture");
            CreateHeader(yOffset, "Data Architecture", "Page 4 of 6");
            
            // Data types
            CreateDataTypesSection(50, yOffset + 150);
            
            // Data governance
            CreateDataGovernanceSection(50, yOffset + 400);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateTechnologyPage(int yOffset)
        {
            CreatePageBackground(yOffset, "5. Technology Stack");
            CreateHeader(yOffset, "Technology Stack", "Page 5 of 6");
            
            // Technology stack layers
            CreateTechnologyStackSection(50, yOffset + 150);
            
            // Security framework
            CreateSecurityFrameworkSection(50, yOffset + 450);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateImplementationPage(int yOffset)
        {
            CreatePageBackground(yOffset, "6. Implementation Roadmap");
            CreateHeader(yOffset, "Implementation Roadmap", "Page 6 of 6");
            
            // Timeline
            CreateImplementationTimeline(50, yOffset + 150);
            
            // Risks and governance
            CreateRisksAndGovernance(50, yOffset + 450);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreatePageBackground(int yOffset, string pageTitle)
        {
            // Page border
            svgContent.AppendLine($@"<rect x=""20"" y=""{yOffset + 20}"" width=""{PageWidth - 40}"" height=""{PageHeight - 40}"" 
                                    fill=""white"" stroke=""#ddd"" stroke-width=""2""/>");
            
            // Page title background
            svgContent.AppendLine($@"<rect x=""20"" y=""{yOffset + 20}"" width=""{PageWidth - 40}"" height=""60"" 
                                    fill=""#0078D4""/>");
            
            // Page title text
            svgContent.AppendLine($@"<text x=""{PageWidth / 2}"" y=""{yOffset + 55}"" text-anchor=""middle"" class=""page-title"">{pageTitle}</text>");
        }

        private void CreateHeader(int yOffset, string title, string subtitle)
        {
            // Title section
            svgContent.AppendLine($@"<rect x=""50"" y=""{yOffset + 90}"" width=""800"" height=""40"" 
                                    fill=""#0078D4""/>");
            svgContent.AppendLine($@"<text x=""450"" y=""{yOffset + 115}"" text-anchor=""middle"" class=""section-title"">{title}</text>");
            
            // Subtitle section
            svgContent.AppendLine($@"<rect x=""850"" y=""{yOffset + 90}"" width=""300"" height=""40"" 
                                    fill=""#f8f9fa"" stroke=""#6b7280""/>");
            svgContent.AppendLine($@"<text x=""1000"" y=""{yOffset + 115}"" text-anchor=""middle"" class=""content-text"">{subtitle}</text>");
        }

        private void CreateBusinessContextQuadrant(int x, int y)
        {
            // Container
            CreateContainer(x, y, 550, 250, "Business Context", "#0078D4");
            
            // Executive Summary
            CreateContentBox(x + 20, y + 60, 250, 80, "Executive Summary", 
                string.Join("\n", config!.Business.ExecutiveSummary.Take(4)), "#10B981");
            
            // Business Drivers
            CreateContentBox(x + 290, y + 60, 240, 80, "Business Drivers", 
                string.Join("\n", config.Business.BusinessDrivers.Take(4)), "#10B981");
            
            // Success Criteria
            CreateContentBox(x + 20, y + 160, 510, 70, "Success Criteria", 
                string.Join("\n", config.Business.SuccessCriteria.Take(4)), "#10B981");
        }

        private void CreateArchitecturePrinciplesQuadrant(int x, int y)
        {
            CreateContainer(x, y, 500, 250, "Architecture Principles", "#0078D4");
            
            var principles = config!.Business.Principles.Take(4).ToList();
            string[] icons = { "🔧", "🔒", "🔄", "🔗" };
            
            for (int i = 0; i < principles.Count && i < 4; i++)
            {
                int boxX = x + 20 + (i % 2) * 240;
                int boxY = y + 60 + (i / 2) * 90;
                
                CreateSimpleBox(boxX, boxY, 220, 70, $"{icons[i]} {principles[i]}", "white");
            }
        }

        private void CreateSystemScopeQuadrant(int x, int y)
        {
            CreateContainer(x, y, 550, 200, "System Scope", "#0078D4");
            
            // In Scope
            CreateContentBox(x + 20, y + 60, 510, 60, "In Scope", 
                string.Join("\n", config!.Business.Scope.InScope.Take(5)), "#10B981");
            
            // Out of Scope
            CreateContentBox(x + 20, y + 140, 510, 40, "Out of Scope", 
                string.Join("\n", config.Business.Scope.OutOfScope.Take(4)), "#EF4444");
        }

        private void CreateStakeholderMatrixQuadrant(int x, int y)
        {
            CreateContainer(x, y, 500, 200, "Stakeholder Matrix", "#0078D4");
            
            var primaryStakeholders = config!.Business.Stakeholders.Where(s => s.Type == "Primary").Take(3);
            var secondaryStakeholders = config.Business.Stakeholders.Where(s => s.Type == "Secondary").Take(3);
            var totalUsers = config.Business.Stakeholders.Sum(s => s.UserCount);
            
            // Primary Stakeholders
            CreateContentBox(x + 20, y + 60, 220, 60, "Primary", 
                string.Join("\n", primaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")), "#10B981");
            
            // Secondary Stakeholders
            CreateContentBox(x + 260, y + 60, 220, 60, "Secondary", 
                string.Join("\n", secondaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")), "#F59E0B");
            
            // Summary
            CreateContentBox(x + 20, y + 140, 460, 40, "Summary", 
                $"Total Users: {totalUsers:N0} | High Influence: {config.Business.Stakeholders.Count(s => s.Influence == "High")}", "#0078D4");
        }

        private void CreatePersonaCard(int x, int y, int width, int height, UserPersona persona)
        {
            // Card background
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""white"" stroke=""#6b7280"" stroke-width=""2""/>");
            
            // Header
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""40"" fill=""#0078D4""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 25}"" text-anchor=""middle"" class=""content-title"">{persona.Name}</text>");
            
            // Content sections
            int sectionHeight = (height - 40) / 4;
            int currentY = y + 40;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Background", 
                string.Join(", ", persona.Background.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Goals", 
                string.Join(", ", persona.Goals.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Pain Points", 
                string.Join(", ", persona.PainPoints.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Tech Skills", 
                $"{persona.TechSkillLevel} | {string.Join(", ", persona.PreferredChannels.Take(2))}");
        }

        private void CreateChannelsSection(int x, int y)
        {
            CreateContainer(x, y, 550, 300, "Channel Architecture", "#0078D4");
            
            // Digital Channels
            CreateContentBox(x + 20, y + 60, 250, 100, "Digital Channels", 
                string.Join("\n", config!.Channels.Digital.Select(c => $"• {c.Name}")), "#10B981");
            
            // Traditional Channels
            CreateContentBox(x + 290, y + 60, 240, 100, "Traditional Channels", 
                string.Join("\n", config.Channels.Traditional.Select(c => $"• {c.Name}")), "#F59E0B");
            
            // Integration Strategy
            CreateContentBox(x + 20, y + 180, 510, 100, "Integration Strategy", 
                $"{config.Channels.Integration.Strategy}\n\nShared Services:\n" + 
                string.Join("\n", config.Channels.Integration.SharedServices.Take(3)), "#0078D4");
        }

        private void CreateBusinessUnitsSection(int x, int y)
        {
            CreateContainer(x, y, 500, 300, "Business Units", "#0078D4");
            
            for (int i = 0; i < Math.Min(config!.BusinessUnits.Count, 4); i++)
            {
                var unit = config.BusinessUnits[i];
                int unitX = x + 20 + (i % 2) * 240;
                int unitY = y + 60 + (i / 2) * 110;
                string color = unit.Type == "Core" ? "#0078D4" : "#10B981";
                
                CreateContentBox(unitX, unitY, 220, 90, $"{unit.Name} ({unit.Type})", 
                    $"{unit.Description}\n\nFunctions: {string.Join(", ", unit.KeyFunctions.Take(2))}", color);
            }
        }

        private void CreateUserSummary(int x, int y)
        {
            var totalUsers = config!.Business.Stakeholders.Sum(s => s.UserCount);
            var primaryUsers = config.Business.Stakeholders.Where(s => s.Type == "Primary").Sum(s => s.UserCount);
            
            CreateContainer(x, y, 1100, 120, "User Base Summary", "#0078D4");
            
            string summaryText = $"Total Users: {totalUsers:N0} | Primary: {primaryUsers:N0} ({(totalUsers > 0 ? primaryUsers * 100.0 / totalUsers : 0):F1}%)\n\n" +
                               $"Key Groups: {string.Join(" | ", config.Business.Stakeholders.Take(4).Select(s => $"{s.Name}: {s.UserCount:N0}"))}";
            
            CreateTextBlock(x + 20, y + 60, 1060, 40, summaryText);
        }

        private void CreateDataTypesSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Data Types & Architecture", "#0078D4");
            
            for (int i = 0; i < Math.Min(config!.Data.DataTypes.Count, 3); i++)
            {
                var dataType = config.Data.DataTypes[i];
                int typeX = x + 20 + i * 360;
                
                CreateContentBox(typeX, y + 60, 340, 120, $"{dataType.Name} ({dataType.Category})", 
                    $"{dataType.Description}\n\nVolume: {dataType.Volume}\nFrequency: {dataType.UpdateFrequency}", "#10B981");
            }
        }

        private void CreateDataGovernanceSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Data Governance", "#0078D4");
            
            // Quality & Security
            CreateContentBox(x + 20, y + 60, 530, 120, "Quality & Security", 
                $"Quality: {string.Join(", ", config!.Data.Governance.QualityMeasures.Take(3))}\n\n" +
                $"Security: {string.Join(", ", config.Data.Governance.SecurityControls.Take(3))}", "#F59E0B");
            
            // Retention & Compliance
            CreateContentBox(x + 570, y + 60, 510, 120, "Retention & Compliance", 
                $"Retention: {string.Join(", ", config.Data.Governance.RetentionPolicies.Take(2))}\n\n" +
                $"Compliance: {string.Join(", ", config.Data.Governance.ComplianceRequirements.Take(2))}", "#F59E0B");
        }

        private void CreateTechnologyStackSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 250, "Technology Stack", "#0078D4");
            
            string[] layerColors = { "#6366F1", "#10B981", "#F59E0B", "#EF4444" };
            string[] layerNames = { "Frontend", "Backend", "Database", "Infrastructure" };
            
            var techLayers = new[]
            {
                string.Join(", ", config!.Technology.Application.Frontend.Select(f => $"{f.Name} {f.Version}")),
                string.Join(", ", config.Technology.Application.Backend.Select(b => $"{b.Name} {b.Version}")),
                string.Join(", ", config.Technology.Application.Database.Select(d => $"{d.Name} {d.Version}")),
                $"{config.Technology.Infrastructure.Cloud.Provider} - {config.Technology.Infrastructure.Cloud.Strategy}"
            };
            
            for (int i = 0; i < 4; i++)
            {
                int layerY = y + 60 + i * 45;
                CreateLayerBox(x + 20, layerY, 1060, 35, layerNames[i], techLayers[i], layerColors[i]);
            }
        }

        private void CreateSecurityFrameworkSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 150, "Security Framework", "#0078D4");
            
            string[] securityAreas = { "Identity", "Network", "Application", "Data" };
            var securityContent = new[]
            {
                string.Join(", ", config!.Technology.Security.IdentityManagement.Take(2)),
                string.Join(", ", config.Technology.Security.NetworkSecurity.Take(2)),
                string.Join(", ", config.Technology.Security.ApplicationSecurity.Take(2)),
                string.Join(", ", config.Technology.Security.DataProtection.Take(2))
            };
            
            for (int i = 0; i < 4; i++)
            {
                int secX = x + 20 + i * 270;
                CreateContentBox(secX, y + 60, 250, 70, securityAreas[i], securityContent[i], "#EF4444");
            }
        }

        private void CreateImplementationTimeline(int x, int y)
        {
            CreateContainer(x, y, 1100, 250, "Implementation Timeline", "#0078D4");
            
            string[] phaseColors = { "#6366F1", "#10B981", "#F59E0B", "#EF4444" };
            int phaseWidth = 1060 / Math.Max(config!.Implementation.Phases.Count, 1);
            
            for (int i = 0; i < config.Implementation.Phases.Count; i++)
            {
                var phase = config.Implementation.Phases[i];
                int phaseX = x + 20 + i * phaseWidth;
                string color = phaseColors[i % phaseColors.Length];
                
                // Phase header
                CreateSimpleBox(phaseX, y + 60, phaseWidth - 10, 40, 
                    $"Phase {i + 1}: {phase.Name}", color);
                
                // Phase details
                CreateContentBox(phaseX, y + 110, phaseWidth - 10, 120, 
                    $"{phase.StartDate:MMM yyyy} - {phase.EndDate:MMM yyyy}", 
                    $"{phase.Description}\n\nDeliverables:\n{string.Join("\n", phase.Deliverables.Take(3))}\n\nStatus: {phase.Status}", 
                    "white");
            }
        }

        private void CreateRisksAndGovernance(int x, int y)
        {
            // Risks (left)
            CreateContainer(x, y, 530, 200, "Key Risks", "#EF4444");
            string risksText = string.Join("\n\n", config!.Implementation.Risks.Take(3).Select(r => 
                $"• {r.Description}\n  Impact: {r.Impact} | Probability: {r.Probability}"));
            CreateTextBlock(x + 20, y + 60, 490, 120, risksText);
            
            // Governance (right)
            CreateContainer(x + 550, y, 530, 200, "Governance", "#10B981");
            string govText = $"Decision Making:\n{string.Join(", ", config.Implementation.Governance.DecisionMaking.Take(3))}\n\n" +
                           $"Review Cycles:\n{string.Join(", ", config.Implementation.Governance.ReviewCycles.Take(3))}";
            CreateTextBlock(x + 570, y + 60, 490, 120, govText);
        }

        // Helper methods for SVG elements
        private void CreateContainer(int x, int y, int width, int height, string title, string titleColor)
        {
            // Container background
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""#f8f9fa"" stroke=""{titleColor}"" stroke-width=""2""/>");
            
            // Title bar
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""40"" fill=""{titleColor}""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 25}"" text-anchor=""middle"" class=""section-title"">{title}</text>");
        }

        private void CreateContentBox(int x, int y, int width, int height, string title, string content, string titleColor)
        {
            // Box background
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""white"" stroke=""#6b7280"" stroke-width=""1""/>");
            
            // Title bar
            int titleHeight = 25;
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{titleHeight}"" fill=""{titleColor}""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 17}"" text-anchor=""middle"" class=""content-title"">{title}</text>");
            
            // Content
            CreateTextBlock(x + 5, y + titleHeight + 5, width - 10, height - titleHeight - 10, content);
        }

        private void CreateSimpleBox(int x, int y, int width, int height, string text, string color)
        {
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""{color}"" stroke=""#6b7280"" stroke-width=""1""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + height/2 + 5}"" text-anchor=""middle"" class=""content-text"">{text}</text>");
        }

        private void CreateLayerBox(int x, int y, int width, int height, string layerName, string technologies, string color)
        {
            // Layer background
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""{color}"" stroke=""#6b7280"" stroke-width=""1""/>");
            
            // Layer name (left 25%)
            int nameWidth = width / 4;
            svgContent.AppendLine($@"<text x=""{x + nameWidth/2}"" y=""{y + height/2 + 5}"" text-anchor=""middle"" class=""content-title"">{layerName}</text>");
            
            // Technologies (right 75%)
            svgContent.AppendLine($@"<text x=""{x + nameWidth + 10}"" y=""{y + height/2 + 5}"" class=""content-title"">{technologies}</text>");
        }

        private void CreateTextBlock(int x, int y, int width, int height, string text)
        {
            var lines = WrapText(text, width / 8); // Approximate character limit based on width
            for (int i = 0; i < Math.Min(lines.Count, height / 14); i++)
            {
                svgContent.AppendLine($"<text x=\"{x}\" y=\"{y + 15 + i * 14}\" class=\"content-text\">{EscapeXml(lines[i])}</text>");
            }
        }

        private void CreateTextSection(int x, int y, int width, int height, string title, string content)
        {
            svgContent.AppendLine($"<text x=\"{x}\" y=\"{y + 15}\" class=\"small-text\" font-weight=\"bold\">{EscapeXml(title)}:</text>");
            var lines = WrapText(content, 40); // Approximate character limit per line
            for (int i = 0; i < Math.Min(lines.Count, 3); i++)
            {
                svgContent.AppendLine($"<text x=\"{x}\" y=\"{y + 30 + i * 12}\" class=\"small-text\">{EscapeXml(lines[i])}</text>");
            }
        }

        private string EscapeXml(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Replace("&", "&amp;")
                        .Replace("<", "&lt;")
                        .Replace(">", "&gt;")
                        .Replace("\"", "&quot;")
                        .Replace("'", "&apos;");
        }

        private void CreateFooter(int yOffset)
        {
            svgContent.AppendLine($@"<rect x=""50"" y=""{yOffset}"" width=""{PageWidth - 100}"" height=""30"" 
                                    fill=""#f8f9fa"" stroke=""#6b7280""/>");
            svgContent.AppendLine($@"<text x=""{PageWidth/2}"" y=""{yOffset + 20}"" text-anchor=""middle"" class=""footer-text"">
                                    Generated: {DateTime.Now:yyyy-MM-dd HH:mm} | {config!.Project.Company} | Version: {config.Project.Version} | Author: {config.Project.Author}</text>");
        }

        private List<string> WrapText(string text, int maxLength)
        {
            var lines = new List<string>();
            var words = text.Split(' ');
            var currentLine = "";
            
            foreach (var word in words)
            {
                if ((currentLine + " " + word).Length <= maxLength)
                {
                    currentLine += (currentLine.Length > 0 ? " " : "") + word;
                }
                else
                {
                    if (currentLine.Length > 0)
                    {
                        lines.Add(currentLine);
                        currentLine = word;
                    }
                    else
                    {
                        lines.Add(word); // Word is longer than max length
                    }
                }
            }
            
            if (currentLine.Length > 0)
            {
                lines.Add(currentLine);
            }
            
            return lines;
        }

        private void SaveDocument(string outputPath)
        {
            Console.WriteLine($"💾 Saving SVG document to: {outputPath}");
            
            try
            {
                string? directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                // Ensure .svg extension
                if (!outputPath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    outputPath = Path.ChangeExtension(outputPath, ".svg");
                }
                
                File.WriteAllText(outputPath, svgContent.ToString());
                Console.WriteLine("✅ SVG document saved successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save SVG document: {ex.Message}", ex);
            }
        }

        public void Cleanup()
        {
            // No cleanup needed for SVG generation
            Console.WriteLine("✅ SVG generation cleanup completed.");
        }
    }
}