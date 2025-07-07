using System;
using System.IO;
using VisioArchitectureGenerator.Generators;
using VisioArchitectureGenerator.Services;

namespace VisioArchitectureGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Architecture Document Generator (SVG) ===");
            Console.WriteLine($"Starting at: {DateTime.Now}");
            Console.WriteLine();

            // Load or create configuration
            var configService = new ConfigurationService();
            var config = configService.LoadOrCreateConfiguration();
            
            try
            {
                string outputPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
                    $"{config.Project.Name.Replace(" ", "").Replace("/", "").Replace("\\", "")}_{DateTime.Now:yyyyMMdd_HHmmss}.svg"
                );
                
                Console.WriteLine($"Output path: {outputPath}");
                Console.WriteLine();
                
                // Generate SVG document
                var svgGenerator = new SvgGenerator();
                svgGenerator.CreateArchitectureDocument(config, outputPath);
                svgGenerator.Cleanup();
                
                Console.WriteLine();
                Console.WriteLine("✅ SVG document created successfully!");
                Console.WriteLine($"📁 Location: {outputPath}");
                Console.WriteLine();
                Console.WriteLine("💡 Tip: Open the SVG file in any web browser to view it!");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("❌ Error occurred:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Type: {ex.GetType().Name}");
                
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}