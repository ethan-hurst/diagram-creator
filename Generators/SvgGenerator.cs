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
        private PowerPlatformConfiguration? config;
        private StringBuilder svgContent;
        private const int PageWidth = 1200;
        private const int PageHeight = 850;

        public SvgGenerator()
        {
            svgContent = new StringBuilder();
        }

        public void CreateArchitectureDocument(PowerPlatformConfiguration configuration, string outputPath)
        {
            this.config = configuration;
            
            try
            {
                Console.WriteLine("🔧 Initializing Power Platform SVG generation...");
                
                GenerateAllPages();
                SaveDocument(outputPath);
                
                Console.WriteLine("✅ Power Platform architecture document generation completed successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"SVG Generation Error: {ex.Message}", ex);
            }
        }

        private void GenerateAllPages()
        {
            Console.WriteLine("🎨 Generating Power Platform SVG content...");
            
            if (config == null) throw new InvalidOperationException("Configuration is not initialized");
            
            StartSvgDocument();
            
            // Generate each page as a separate section
            Console.WriteLine("  📋 Creating solution overview page...");
            CreateSolutionOverviewPage(0);
            
            Console.WriteLine("  👥 Creating users & personas page...");
            CreatePersonaPage(PageHeight + 50);
            
            Console.WriteLine("  ⚡ Creating Power Platform components page...");
            CreatePowerPlatformPage(2 * (PageHeight + 50));
            
            Console.WriteLine("  🗄️ Creating Dynamics 365 & Dataverse page...");
            CreateDynamics365Page(3 * (PageHeight + 50));
            
            Console.WriteLine("  🔗 Creating integrations & security page...");
            CreateIntegrationsPage(4 * (PageHeight + 50));
            
            Console.WriteLine("  🗺️ Creating implementation roadmap page...");
            CreateImplementationPage(5 * (PageHeight + 50));
            
            EndSvgDocument();
            
            Console.WriteLine("✅ All Power Platform pages generated successfully.");
        }

        private void StartSvgDocument()
        {
            int totalHeight = 6 * (PageHeight + 50);
            
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

        private void CreateSolutionOverviewPage(int yOffset)
        {
            CreatePageBackground(yOffset, "1. Solution Overview");
            CreateHeader(yOffset, config!.Project.Name, $"Version {config.Project.Version}");
            
            // Business Context Quadrant
            CreateBusinessContextQuadrant(50, yOffset + 120);
            
            // Solution Scope Quadrant  
            CreateSolutionScopeQuadrant(650, yOffset + 120);
            
            // Business Processes Quadrant
            CreateBusinessProcessesQuadrant(50, yOffset + 400);
            
            // Stakeholder Matrix Quadrant
            CreateStakeholderMatrixQuadrant(650, yOffset + 400);
            
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

        private void CreatePowerPlatformPage(int yOffset)
        {
            CreatePageBackground(yOffset, "3. Power Platform Components");
            CreateHeader(yOffset, "Power Platform Components", "Page 3 of 6");
            
            // Power Apps section
            CreatePowerAppsSection(50, yOffset + 150);
            
            // Power Automate section
            CreatePowerAutomateSection(650, yOffset + 150);
            
            // Power BI and connectors section
            CreatePowerBISection(50, yOffset + 400);
            CreateConnectorsSection(650, yOffset + 400);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateDynamics365Page(int yOffset)
        {
            CreatePageBackground(yOffset, "4. Dynamics 365 & Dataverse");
            CreateHeader(yOffset, "Dynamics 365 & Dataverse", "Page 4 of 6");
            
            // Dynamics 365 Apps
            CreateDynamics365Section(50, yOffset + 150);
            
            // Dataverse configuration
            CreateDataverseSection(50, yOffset + 400);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateIntegrationsPage(int yOffset)
        {
            CreatePageBackground(yOffset, "5. Integrations & Security");
            CreateHeader(yOffset, "Integrations & Security", "Page 5 of 6");
            
            // Integrations section
            CreateIntegrationsSection(50, yOffset + 150);
            
            // Security section
            CreateSecuritySection(50, yOffset + 400);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        private void CreateImplementationPage(int yOffset)
        {
            CreatePageBackground(yOffset, "6. Implementation Roadmap");
            CreateHeader(yOffset, "Implementation Roadmap", "Page 6 of 6");
            
            // Environment strategy
            CreateEnvironmentStrategy(50, yOffset + 150);
            
            // Implementation timeline
            CreateImplementationTimeline(50, yOffset + 400);
            
            CreateFooter(yOffset + PageHeight - 40);
        }

        // Business Context section
        private void CreateBusinessContextQuadrant(int x, int y)
        {
            CreateContainer(x, y, 550, 250, "Business Context", "#0078D4");
            
            CreateContentBox(x + 20, y + 60, 250, 80, "Executive Summary", 
                string.Join("\n", config!.Business.ExecutiveSummary.Take(4)), "#10B981");
            
            CreateContentBox(x + 290, y + 60, 240, 80, "Business Drivers", 
                string.Join("\n", config.Business.BusinessDrivers.Take(4)), "#10B981");
            
            CreateContentBox(x + 20, y + 160, 510, 70, "Success Criteria", 
                string.Join("\n", config.Business.SuccessCriteria.Take(4)), "#10B981");
        }

        private void CreateSolutionScopeQuadrant(int x, int y)
        {
            CreateContainer(x, y, 500, 250, "Solution Scope", "#0078D4");
            
            CreateContentBox(x + 20, y + 60, 460, 80, "In Scope", 
                string.Join("\n", config!.Business.Scope.InScope.Take(5)), "#10B981");
            
            CreateContentBox(x + 20, y + 160, 460, 70, "Out of Scope", 
                string.Join("\n", config.Business.Scope.OutOfScope.Take(4)), "#EF4444");
        }

        private void CreateBusinessProcessesQuadrant(int x, int y)
        {
            CreateContainer(x, y, 550, 200, "Business Processes", "#0078D4");
            
            for (int i = 0; i < Math.Min(config!.Business.BusinessProcesses.Count, 2); i++)
            {
                var process = config.Business.BusinessProcesses[i];
                int processY = y + 60 + i * 60;
                
                CreateContentBox(x + 20, processY, 510, 50, 
                    $"{process.Name} ({process.CurrentState} → {process.FutureState})", 
                    $"{process.Description}\nAutomation: {string.Join(", ", process.AutomationOpportunities.Take(2))}", 
                    "#F59E0B");
            }
        }

        private void CreateStakeholderMatrixQuadrant(int x, int y)
        {
            CreateContainer(x, y, 500, 200, "Stakeholder Matrix", "#0078D4");
            
            var primaryStakeholders = config!.Business.Stakeholders.Where(s => s.Type == "Primary").Take(3);
            var secondaryStakeholders = config.Business.Stakeholders.Where(s => s.Type == "Secondary").Take(3);
            var totalUsers = config.Business.Stakeholders.Sum(s => s.UserCount);
            
            CreateContentBox(x + 20, y + 60, 220, 60, "Primary", 
                string.Join("\n", primaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")), "#10B981");
            
            CreateContentBox(x + 260, y + 60, 220, 60, "Secondary", 
                string.Join("\n", secondaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")), "#F59E0B");
            
            CreateContentBox(x + 20, y + 140, 460, 40, "Summary", 
                $"Total Users: {totalUsers:N0} | High Influence: {config.Business.Stakeholders.Count(s => s.Influence == "High")}", "#0078D4");
        }

        // Power Platform sections
        private void CreatePowerAppsSection(int x, int y)
        {
            CreateContainer(x, y, 550, 200, "Power Apps", "#742774");
            
            for (int i = 0; i < Math.Min(config!.PowerPlatform.PowerApps.Count, 2); i++)
            {
                var app = config.PowerPlatform.PowerApps[i];
                int appY = y + 60 + i * 60;
                
                CreateContentBox(x + 20, appY, 510, 50, 
                    $"{app.Name} ({app.Type})", 
                    $"{app.Description}\nUsers: {string.Join(", ", app.TargetUsers.Take(2))}", 
                    "#742774");
            }
        }

        private void CreatePowerAutomateSection(int x, int y)
        {
            CreateContainer(x, y, 500, 200, "Power Automate", "#0066FF");
            
            for (int i = 0; i < Math.Min(config!.PowerPlatform.PowerAutomate.Count, 2); i++)
            {
                var flow = config.PowerPlatform.PowerAutomate[i];
                int flowY = y + 60 + i * 60;
                
                CreateContentBox(x + 20, flowY, 460, 50, 
                    $"{flow.Name} ({flow.Type})", 
                    $"{flow.Description}\nTrigger: {flow.Trigger}", 
                    "#0066FF");
            }
        }

        private void CreatePowerBISection(int x, int y)
        {
            CreateContainer(x, y, 550, 150, "Power BI Reports", "#F2C811");
            
            for (int i = 0; i < Math.Min(config!.PowerPlatform.PowerBI.Count, 2); i++)
            {
                var report = config.PowerPlatform.PowerBI[i];
                int reportY = y + 60 + i * 40;
                
                CreateContentBox(x + 20, reportY, 510, 30, 
                    $"{report.Name} ({report.Type})", 
                    $"{report.Description} | Refresh: {report.RefreshFrequency}", 
                    "#F2C811");
            }
        }

        private void CreateConnectorsSection(int x, int y)
        {
            CreateContainer(x, y, 500, 150, "Connectors", "#00BCF2");
            
            var standardConnectors = config!.PowerPlatform.Connectors.Where(c => c.Type == "Standard").Take(3);
            var premiumConnectors = config.PowerPlatform.Connectors.Where(c => c.Type == "Premium").Take(2);
            
            CreateContentBox(x + 20, y + 60, 220, 70, "Standard", 
                string.Join("\n", standardConnectors.Select(c => $"• {c.Name}")), "#00BCF2");
            
            CreateContentBox(x + 260, y + 60, 220, 70, "Premium", 
                string.Join("\n", premiumConnectors.Select(c => $"• {c.Name}")), "#FF8C00");
        }

        // Dynamics 365 sections
        private void CreateDynamics365Section(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Dynamics 365 Applications", "#0078D4");
            
            for (int i = 0; i < Math.Min(config!.Dynamics365.EnabledApps.Count, 3); i++)
            {
                var app = config.Dynamics365.EnabledApps[i];
                int appX = x + 20 + i * 360;
                
                CreateContentBox(appX, y + 60, 340, 120, 
                    $"{app.Name} ({app.Type})", 
                    $"{app.Description}\n\nModules: {string.Join(", ", app.Modules.Take(3))}\nUsers: {string.Join(", ", app.Users.Take(2))}", 
                    "#0078D4");
            }
        }

        private void CreateDataverseSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Dataverse Configuration", "#6264A7");
            
            CreateContentBox(x + 20, y + 60, 350, 120, "Entities", 
                string.Join("\n", config!.Dataverse.Entities.Take(5).Select(e => $"• {e.DisplayName} ({e.Type})")), "#6264A7");
            
            CreateContentBox(x + 390, y + 60, 350, 120, "Security Roles", 
                string.Join("\n", config.Dataverse.SecurityRoles.Take(5).Select(r => $"• {r.Name}")), "#6264A7");
            
            CreateContentBox(x + 760, y + 60, 320, 120, "Business Units", 
                string.Join("\n", config.Dataverse.BusinessUnits.Take(4).Select(bu => $"• {bu.Name}")), "#6264A7");
        }

        // Integration and Security sections
        private void CreateIntegrationsSection(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "System Integrations", "#FF6900");
            
            for (int i = 0; i < Math.Min(config!.Integrations.SystemIntegrations.Count, 3); i++)
            {
                var integration = config.Integrations.SystemIntegrations[i];
                int intX = x + 20 + i * 360;
                
                CreateContentBox(intX, y + 60, 340, 120, 
                    $"{integration.Name}", 
                    $"{integration.SourceSystem} → {integration.TargetSystem}\nType: {integration.IntegrationType}\nMethod: {integration.Method}", 
                    "#FF6900");
            }
        }

        private void CreateSecuritySection(int x, int y)
        {
            CreateContainer(x, y, 1100, 150, "Security Model", "#D13438");
            
            var securityRoles = config!.Security.SecurityRoles.Take(4);
            
            CreateContentBox(x + 20, y + 60, 530, 70, "Security Roles", 
                string.Join("\n", securityRoles.Select(r => $"• {r.Name}: {string.Join(", ", r.Privileges.Take(2))}")), "#D13438");
            
            CreateContentBox(x + 570, y + 60, 510, 70, "Security Settings", 
                $"MFA Required: {config.Security.Settings.MultiFactorAuthRequired}\nAuditing: {config.Security.Settings.AuditingEnabled}\nSession Timeout: {config.Security.Settings.SessionTimeout} min", 
                "#D13438");
        }

        // Implementation sections
        private void CreateEnvironmentStrategy(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Environment Strategy", "#107C10");
            
            for (int i = 0; i < Math.Min(config!.Environments.Environments.Count, 4); i++)
            {
                var env = config.Environments.Environments[i];
                int envX = x + 20 + i * 270;
                
                CreateContentBox(envX, y + 60, 250, 120, 
                    $"{env.Name} ({env.Type})", 
                    $"{env.Description}\nRegion: {env.Region}\nDataverse: {(env.DataverseEnabled ? "Yes" : "No")}", 
                    "#107C10");
            }
        }

        private void CreateImplementationTimeline(int x, int y)
        {
            CreateContainer(x, y, 1100, 200, "Implementation Timeline", "#8764B8");
            
            string[] phaseColors = { "#6366F1", "#10B981", "#F59E0B", "#EF4444" };
            int phaseWidth = 1060 / Math.Max(config!.Implementation.Phases.Count, 1);
            
            for (int i = 0; i < config.Implementation.Phases.Count; i++)
            {
                var phase = config.Implementation.Phases[i];
                int phaseX = x + 20 + i * phaseWidth;
                string color = phaseColors[i % phaseColors.Length];
                
                CreateSimpleBox(phaseX, y + 60, phaseWidth - 10, 40, 
                    $"Phase {i + 1}: {phase.Name}", color);
                
                CreateContentBox(phaseX, y + 110, phaseWidth - 10, 70, 
                    $"{phase.StartDate:MMM yyyy} - {phase.EndDate:MMM yyyy}", 
                    $"{phase.Description}\nStatus: {phase.Status}", 
                    "white");
            }
        }

        // Persona card creation
        private void CreatePersonaCard(int x, int y, int width, int height, UserPersona persona)
        {
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""white"" stroke=""#6b7280"" stroke-width=""2""/>");
            
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""40"" fill=""#0078D4""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 25}"" text-anchor=""middle"" class=""content-title"">{EscapeXml(persona.Name)}</text>");
            
            int sectionHeight = (height - 40) / 5;
            int currentY = y + 40;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Role", 
                $"{persona.Role} - {persona.Department}");
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Goals", 
                string.Join(", ", persona.Goals.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "D365 Access", 
                string.Join(", ", persona.Dynamics365Access.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Power Platform", 
                string.Join(", ", persona.PowerPlatformAccess.Take(2)));
            currentY += sectionHeight;
            
            CreateTextSection(x + 10, currentY, width - 20, sectionHeight, "Security Roles", 
                string.Join(", ", persona.SecurityRoles.Take(2)));
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

        // Helper methods for SVG elements
        private void CreatePageBackground(int yOffset, string pageTitle)
        {
            svgContent.AppendLine($@"<rect x=""20"" y=""{yOffset + 20}"" width=""{PageWidth - 40}"" height=""{PageHeight - 40}"" 
                                    fill=""white"" stroke=""#ddd"" stroke-width=""2""/>");
            
            svgContent.AppendLine($@"<rect x=""20"" y=""{yOffset + 20}"" width=""{PageWidth - 40}"" height=""60"" 
                                    fill=""#0078D4""/>");
            
            svgContent.AppendLine($@"<text x=""{PageWidth / 2}"" y=""{yOffset + 55}"" text-anchor=""middle"" class=""page-title"">{EscapeXml(pageTitle)}</text>");
        }

        private void CreateHeader(int yOffset, string title, string subtitle)
        {
            svgContent.AppendLine($@"<rect x=""50"" y=""{yOffset + 90}"" width=""800"" height=""40"" 
                                    fill=""#0078D4""/>");
            svgContent.AppendLine($@"<text x=""450"" y=""{yOffset + 115}"" text-anchor=""middle"" class=""section-title"">{EscapeXml(title)}</text>");
            
            svgContent.AppendLine($@"<rect x=""850"" y=""{yOffset + 90}"" width=""300"" height=""40"" 
                                    fill=""#f8f9fa"" stroke=""#6b7280""/>");
            svgContent.AppendLine($@"<text x=""1000"" y=""{yOffset + 115}"" text-anchor=""middle"" class=""content-text"">{EscapeXml(subtitle)}</text>");
        }

        private void CreateContainer(int x, int y, int width, int height, string title, string titleColor)
        {
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""#f8f9fa"" stroke=""{titleColor}"" stroke-width=""2""/>");
            
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""40"" fill=""{titleColor}""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 25}"" text-anchor=""middle"" class=""section-title"">{EscapeXml(title)}</text>");
        }

        private void CreateContentBox(int x, int y, int width, int height, string title, string content, string titleColor)
        {
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""white"" stroke=""#6b7280"" stroke-width=""1""/>");
            
            int titleHeight = 25;
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{titleHeight}"" fill=""{titleColor}""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + 17}"" text-anchor=""middle"" class=""content-title"">{EscapeXml(title)}</text>");
            
            CreateTextBlock(x + 5, y + titleHeight + 5, width - 10, height - titleHeight - 10, content);
        }

        private void CreateSimpleBox(int x, int y, int width, int height, string text, string color)
        {
            svgContent.AppendLine($@"<rect x=""{x}"" y=""{y}"" width=""{width}"" height=""{height}"" 
                                    fill=""{color}"" stroke=""#6b7280"" stroke-width=""1""/>");
            svgContent.AppendLine($@"<text x=""{x + width/2}"" y=""{y + height/2 + 5}"" text-anchor=""middle"" class=""content-title"">{EscapeXml(text)}</text>");
        }

        private void CreateTextBlock(int x, int y, int width, int height, string text)
        {
            var lines = WrapText(text, width / 8);
            for (int i = 0; i < Math.Min(lines.Count, height / 14); i++)
            {
                svgContent.AppendLine($"<text x=\"{x}\" y=\"{y + 15 + i * 14}\" class=\"content-text\">{EscapeXml(lines[i])}</text>");
            }
        }

        private void CreateTextSection(int x, int y, int width, int height, string title, string content)
        {
            svgContent.AppendLine($"<text x=\"{x}\" y=\"{y + 15}\" class=\"small-text\" font-weight=\"bold\">{EscapeXml(title)}:</text>");
            var lines = WrapText(content, 40);
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
                                    Generated: {DateTime.Now:yyyy-MM-dd HH:mm} | {EscapeXml(config!.Project.Company)} | Version: {EscapeXml(config.Project.Version)} | Author: {EscapeXml(config.Project.Author)}</text>");
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
                        lines.Add(word);
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
            Console.WriteLine($"💾 Saving Power Platform SVG document to: {outputPath}");
            
            try
            {
                string? directory = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                
                if (!outputPath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                {
                    outputPath = Path.ChangeExtension(outputPath, ".svg");
                }
                
                File.WriteAllText(outputPath, svgContent.ToString());
                Console.WriteLine("✅ Power Platform SVG document saved successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save SVG document: {ex.Message}", ex);
            }
        }

        public void Cleanup()
        {
            Console.WriteLine("✅ Power Platform SVG generation cleanup completed.");
        }
    }
}