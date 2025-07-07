using Microsoft.Office.Interop.Visio;
using System;
using System.Runtime.InteropServices;
using VisioArchitectureGenerator.Generators.Components;
using VisioArchitectureGenerator.Generators.PageGenerators;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Generators
{
    public class VisioGenerator
    {
        private Microsoft.Office.Interop.Visio.Application? visioApp;
        private Document? document;
        private ArchitectureConfiguration? config;

        public void CreateArchitectureDocument(ArchitectureConfiguration configuration, string outputPath)
        {
            this.config = configuration;
            
            try
            {
                InitializeVisio();
                CreateDocumentStructure();
                GenerateAllPages();
                SaveDocument(outputPath);
                
                Console.WriteLine("✅ Architecture document generation completed successfully!");
            }
            catch (COMException comEx)
            {
                throw new Exception($"COM Error: {comEx.Message} (Error Code: 0x{comEx.ErrorCode:X8})", comEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"General Error: {ex.Message}", ex);
            }
        }

        private void InitializeVisio()
        {
            Console.WriteLine("🔧 Initializing Visio application...");
            
            try
            {
                visioApp = new Microsoft.Office.Interop.Visio.Application();
                visioApp.Visible = true;
                document = visioApp.Documents.Add("");
                
                Console.WriteLine("✅ Visio application initialized successfully.");
            }
            catch (COMException ex)
            {
                throw new Exception($"Failed to initialize Visio. Make sure Visio is installed and properly registered. Error: {ex.Message}", ex);
            }
        }

        private void CreateDocumentStructure()
        {
            Console.WriteLine("📄 Setting up document structure...");
            
            if (document == null || config == null) 
                throw new InvalidOperationException("Document or configuration is not initialized");
            
            // Set up first page (Overview)
            var overviewPage = document.Pages[1];
            ShapeHelpers.SetupA3Page(overviewPage);
            overviewPage.Name = "1. Architecture Overview";
            
            // Add additional pages
            var userPersonaPage = document.Pages.Add();
            ShapeHelpers.SetupA3Page(userPersonaPage);
            userPersonaPage.Name = "2. Users & Personas";
            
            var channelsPage = document.Pages.Add();
            ShapeHelpers.SetupA3Page(channelsPage);
            channelsPage.Name = "3. Channels & Business Units";
            
            var dataPage = document.Pages.Add();
            ShapeHelpers.SetupA3Page(dataPage);
            dataPage.Name = "4. Data Architecture";
            
            var technologyPage = document.Pages.Add();
            ShapeHelpers.SetupA3Page(technologyPage);
            technologyPage.Name = "5. Technology Stack";
            
            var implementationPage = document.Pages.Add();
            ShapeHelpers.SetupA3Page(implementationPage);
            implementationPage.Name = "6. Implementation Roadmap";
            
            Console.WriteLine("✅ Document structure created (6 pages).");
        }

        private void GenerateAllPages()
        {
            Console.WriteLine("🎨 Generating page content...");
            
            if (document == null || config == null) 
                throw new InvalidOperationException("Document or configuration is not initialized");
            
            // Generate each page using dedicated generators
            Console.WriteLine("  📋 Creating overview page...");
            OverviewPageGenerator.CreatePage(document.Pages["1. Architecture Overview"], config);
            
            Console.WriteLine("  👥 Creating users & personas page...");
            PersonaPageGenerator.CreatePage(document.Pages["2. Users & Personas"], config);
            
            Console.WriteLine("  🏢 Creating channels & business units page...");
            ChannelsPageGenerator.CreatePage(document.Pages["3. Channels & Business Units"], config);
            
            Console.WriteLine("  🗄️ Creating data architecture page...");
            DataPageGenerator.CreatePage(document.Pages["4. Data Architecture"], config);
            
            Console.WriteLine("  💻 Creating technology stack page...");
            TechnologyPageGenerator.CreatePage(document.Pages["5. Technology Stack"], config);
            
            Console.WriteLine("  🗺️ Creating implementation roadmap page...");
            ImplementationPageGenerator.CreatePage(document.Pages["6. Implementation Roadmap"], config);
            
            Console.WriteLine("✅ All pages generated successfully.");
        }

        private void SaveDocument(string outputPath)
        {
            if (document == null) throw new InvalidOperationException("Document is not initialized");
            
            Console.WriteLine($"💾 Saving document to: {outputPath}");
            
            try
            {
                string? directory = System.IO.Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(directory) && !System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
                
                document.SaveAs(outputPath);
                Console.WriteLine("✅ Document saved successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save document: {ex.Message}", ex);
            }
        }

        public void Cleanup()
        {
            Console.WriteLine("🧹 Cleaning up resources...");
            
            try
            {
                if (document != null)
                {
                    document.Close();
                    Marshal.ReleaseComObject(document);
                    document = null;
                }
                
                if (visioApp != null)
                {
                    visioApp.Quit();
                    Marshal.ReleaseComObject(visioApp);
                    visioApp = null;
                }
                
                GC.Collect();
                GC.WaitForPendingFinalizers();
                
                Console.WriteLine("✅ Cleanup completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Warning during cleanup: {ex.Message}");
            }
        }
    }
}