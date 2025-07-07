using Microsoft.Office.Interop.Visio;
using System.Linq;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators.PageGenerators
{
    public static class OverviewPageGenerator
    {
        public static void CreatePage(Page page, ArchitectureConfiguration config)
        {
            // Create header
            HeaderGenerator.CreateHeader(page, config.Project.Name, 
                                       $"Version {config.Project.Version}", 
                                       config.Project.LastUpdated.ToString("yyyy-MM-dd"));
            
            // Create main content quadrants
            CreateBusinessContextQuadrant(page, config);
            CreateArchitecturePrinciplesQuadrant(page, config);
            CreateSystemScopeQuadrant(page, config);
            CreateStakeholderMatrixQuadrant(page, config);
            
            // Create footer
            FooterGenerator.CreateFooter(page, config);
        }

        private static void CreateBusinessContextQuadrant(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 10, 200, 195, 75, "Business Context");
            
            // Create content boxes
            ShapeHelpers.CreateColoredBox(page, 15, 240, 85, 15, "Executive Summary", 
                string.Join("\n", config.Business.ExecutiveSummary.Take(4).Select(e => $"• {e}")),
                "RGB(255,255,255)", "RGB(16,185,129)");
            
            ShapeHelpers.CreateColoredBox(page, 105, 240, 95, 15, "Key Business Drivers", 
                string.Join("\n", config.Business.BusinessDrivers.Take(4).Select(d => $"• {d}")),
                "RGB(255,255,255)", "RGB(16,185,129)");
            
            ShapeHelpers.CreateColoredBox(page, 15, 205, 185, 30, "Success Criteria", 
                string.Join("\n", config.Business.SuccessCriteria.Take(4).Select(s => $"• {s}")),
                "RGB(255,255,255)", "RGB(16,185,129)");
        }

        private static void CreateArchitecturePrinciplesQuadrant(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 210, 200, 200, 75, "Architecture Principles");
            
            // Create principle boxes in 2x2 grid
            var principles = config.Business.Principles.Take(4).ToList();
            string[] icons = { "🔧", "🔒", "🔄", "🔗" };
            
            for (int i = 0; i < principles.Count && i < 4; i++)
            {
                double x = 215 + (i % 2) * 95;
                double y = 240 - (i / 2) * 25;
                
                ShapeHelpers.CreateSimpleBox(page, x, y, 90, 20, 
                    $"{icons[i]} {principles[i]}\nCore architectural guideline",
                    "RGB(255,255,255)");
            }
        }

        private static void CreateSystemScopeQuadrant(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 10, 100, 195, 95, "System Scope");
            
            // In Scope
            ShapeHelpers.CreateColoredBox(page, 15, 140, 185, 35, "In Scope", 
                string.Join("\n", config.Business.Scope.InScope.Take(5).Select(i => $"• {i}")),
                "RGB(255,255,255)", "RGB(16,185,129)");
            
            // Out of Scope
            ShapeHelpers.CreateColoredBox(page, 15, 105, 185, 30, "Out of Scope", 
                string.Join("\n", config.Business.Scope.OutOfScope.Take(4).Select(o => $"• {o}")),
                "RGB(255,255,255)", "RGB(239,68,68)");
        }

        private static void CreateStakeholderMatrixQuadrant(Page page, ArchitectureConfiguration config)
        {
            // Create container
            ShapeHelpers.CreateContainer(page, 210, 100, 200, 95, "Stakeholder Matrix");
            
            var primaryStakeholders = config.Business.Stakeholders.Where(s => s.Type == "Primary").Take(3);
            var secondaryStakeholders = config.Business.Stakeholders.Where(s => s.Type == "Secondary").Take(3);
            
            // Primary Stakeholders
            ShapeHelpers.CreateColoredBox(page, 215, 140, 95, 35, "Primary Stakeholders", 
                string.Join("\n", primaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")),
                "RGB(255,255,255)", "RGB(16,185,129)");
            
            // Secondary Stakeholders
            ShapeHelpers.CreateColoredBox(page, 315, 140, 90, 35, "Secondary Stakeholders", 
                string.Join("\n", secondaryStakeholders.Select(s => $"• {s.Name} ({s.UserCount:N0})")),
                "RGB(255,255,255)", "RGB(245,158,11)");
            
            // Summary
            var totalUsers = config.Business.Stakeholders.Sum(s => s.UserCount);
            ShapeHelpers.CreateColoredBox(page, 215, 105, 190, 30, "User Base Summary", 
                $"Total Users: {totalUsers:N0}\nHigh Influence: {config.Business.Stakeholders.Count(s => s.Influence == "High")}\nActive Engagement Required",
                "RGB(255,255,255)", "RGB(0,120,212)");
        }
    }
}