using System;
using System.IO;
using System.Linq;
using VisioArchitectureGenerator.Generators;
using VisioArchitectureGenerator.Services;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Architecture Document Generator (SVG) ===");
            Console.WriteLine($"Starting at: {DateTime.Now}");
            Console.WriteLine();

            // Parse command line arguments
            var options = ParseArguments(args);
            
            // If no arguments provided and not non-interactive, prompt for basic info
            if (args.Length == 0 && !options.NonInteractive)
            {
                options = PromptForBasicInfo();
            }
            
            // Load or create configuration
            var configService = new ConfigurationService();
            var config = configService.LoadOrCreateConfiguration();
            
            // Apply command line overrides
            ApplyCommandLineOverrides(config, options);
            
            try
            {
                string outputPath = options.OutputPath ?? Path.Combine(
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
                
                if (!options.NonInteractive)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
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
                
                if (!options.NonInteractive)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }

        private static CommandLineOptions ParseArguments(string[] args)
        {
            var options = new CommandLineOptions();
            
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "--help":
                    case "-h":
                        ShowHelp();
                        Environment.Exit(0);
                        break;
                    case "--project-name":
                    case "-n":
                        if (i + 1 < args.Length) options.ProjectName = args[++i];
                        break;
                    case "--company":
                    case "-c":
                        if (i + 1 < args.Length) options.Company = args[++i];
                        break;
                    case "--author":
                    case "-a":
                        if (i + 1 < args.Length) options.Author = args[++i];
                        break;
                    case "--version":
                    case "-v":
                        if (i + 1 < args.Length) options.Version = args[++i];
                        break;
                    case "--output":
                    case "-o":
                        if (i + 1 < args.Length) options.OutputPath = args[++i];
                        break;
                    case "--non-interactive":
                    case "-ni":
                        options.NonInteractive = true;
                        break;
                    case "--template":
                    case "-t":
                        if (i + 1 < args.Length) options.Template = args[++i];
                        break;
                }
            }
            
            return options;
        }

        private static void ApplyCommandLineOverrides(ArchitectureConfiguration config, CommandLineOptions options)
        {
            if (!string.IsNullOrEmpty(options.ProjectName))
            {
                config.Project.Name = options.ProjectName;
                Console.WriteLine($"🔧 Project name set to: {options.ProjectName}");
            }
            
            if (!string.IsNullOrEmpty(options.Company))
            {
                config.Project.Company = options.Company;
                Console.WriteLine($"🏢 Company set to: {options.Company}");
            }
            
            if (!string.IsNullOrEmpty(options.Author))
            {
                config.Project.Author = options.Author;
                Console.WriteLine($"👤 Author set to: {options.Author}");
            }
            
            if (!string.IsNullOrEmpty(options.Version))
            {
                config.Project.Version = options.Version;
                Console.WriteLine($"📦 Version set to: {options.Version}");
            }
            
            // Apply template if specified
            if (!string.IsNullOrEmpty(options.Template))
            {
                ApplyTemplate(config, options.Template);
            }
        }

        private static void ApplyTemplate(ArchitectureConfiguration config, string template)
        {
            Console.WriteLine($"📋 Applying template: {template}");
            
            switch (template.ToLower())
            {
                case "ecommerce":
                    ApplyEcommerceTemplate(config);
                    break;
                case "enterprise":
                    ApplyEnterpriseTemplate(config);
                    break;
                case "saas":
                    ApplySaasTemplate(config);
                    break;
                case "startup":
                    ApplyStartupTemplate(config);
                    break;
                default:
                    Console.WriteLine($"⚠️ Unknown template: {template}. Available templates: ecommerce, enterprise, saas, startup");
                    break;
            }
        }

        private static void ApplyEcommerceTemplate(ArchitectureConfiguration config)
        {
            config.Project.Description = "E-commerce platform with customer portal, payment processing, and inventory management";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Increase online sales conversion",
                "Reduce cart abandonment",
                "Improve customer experience",
                "Scale for peak shopping periods"
            });
        }

        private static void ApplyEnterpriseTemplate(ArchitectureConfiguration config)
        {
            config.Project.Description = "Enterprise application with role-based access, compliance, and integration";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Improve operational efficiency",
                "Ensure compliance and security",
                "Enable scalable growth",
                "Reduce IT maintenance costs"
            });
        }

        private static void ApplySaasTemplate(ArchitectureConfiguration config)
        {
            config.Project.Description = "Multi-tenant SaaS application with subscription management and analytics";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Enable rapid customer onboarding",
                "Provide scalable multi-tenant architecture",
                "Implement usage-based pricing",
                "Deliver comprehensive analytics"
            });
        }

        private static void ApplyStartupTemplate(ArchitectureConfiguration config)
        {
            config.Project.Description = "MVP application with focus on rapid development and validation";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Validate product-market fit",
                "Minimize time to market",
                "Enable rapid iteration",
                "Optimize for cost efficiency"
            });
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Architecture Document Generator - Help");
            Console.WriteLine("=====================================");
            Console.WriteLine();
            Console.WriteLine("Usage: dotnet run [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  -n, --project-name <name>    Set the project name");
            Console.WriteLine("  -c, --company <company>      Set the company name");
            Console.WriteLine("  -a, --author <author>        Set the author name");
            Console.WriteLine("  -v, --version <version>      Set the project version");
            Console.WriteLine("  -o, --output <path>          Set the output file path");
            Console.WriteLine("  -t, --template <template>    Apply a predefined template");
            Console.WriteLine("                               (ecommerce, enterprise, saas, startup)");
            Console.WriteLine("  -ni, --non-interactive       Run without user prompts");
            Console.WriteLine("  -h, --help                   Show this help message");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  dotnet run --project-name \"My App\" --company \"My Company\"");
            Console.WriteLine("  dotnet run --template ecommerce --output ./my-diagram.svg");
            Console.WriteLine("  dotnet run --non-interactive");
            Console.WriteLine();
            Console.WriteLine("Configuration:");
            Console.WriteLine("  Edit architecture-config.json for detailed customization");
            Console.WriteLine("  Run without arguments to create a sample configuration");
        }

        private static CommandLineOptions PromptForBasicInfo()
        {
            var options = new CommandLineOptions();
            
            Console.WriteLine("🚀 Interactive Mode - Let's customize your architecture diagram!");
            Console.WriteLine("(Press Enter to use defaults or provide your own values)");
            Console.WriteLine();
            
            Console.Write("Project Name (default: My Project): ");
            var projectName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(projectName))
                options.ProjectName = projectName;
            
            Console.Write("Company Name (default: My Company): ");
            var companyName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(companyName))
                options.Company = companyName;
            
            Console.Write("Author Name (default: Architecture Team): ");
            var authorName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(authorName))
                options.Author = authorName;
            
            Console.Write("Version (default: 1.0): ");
            var version = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(version))
                options.Version = version;
            
            Console.WriteLine();
            Console.WriteLine("Would you like to use a template? Available templates:");
            Console.WriteLine("  1. ecommerce  - E-commerce platform");
            Console.WriteLine("  2. enterprise - Enterprise application");
            Console.WriteLine("  3. saas       - SaaS application");
            Console.WriteLine("  4. startup    - Startup MVP");
            Console.WriteLine("  (press Enter to skip template)");
            Console.Write("Choose template (1-4 or name): ");
            var templateChoice = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(templateChoice))
            {
                switch (templateChoice.ToLower())
                {
                    case "1":
                    case "ecommerce":
                        options.Template = "ecommerce";
                        break;
                    case "2":
                    case "enterprise":
                        options.Template = "enterprise";
                        break;
                    case "3":
                    case "saas":
                        options.Template = "saas";
                        break;
                    case "4":
                    case "startup":
                        options.Template = "startup";
                        break;
                    default:
                        Console.WriteLine($"⚠️ Unknown template '{templateChoice}', skipping...");
                        break;
                }
            }
            
            Console.WriteLine();
            return options;
        }

    }

    public class CommandLineOptions
    {
        public string? ProjectName { get; set; }
        public string? Company { get; set; }
        public string? Author { get; set; }
        public string? Version { get; set; }
        public string? OutputPath { get; set; }
        public string? Template { get; set; }
        public bool NonInteractive { get; set; }
    }
}