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

        private static void ApplyCommandLineOverrides(PowerPlatformConfiguration config, CommandLineOptions options)
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

        private static void ApplyTemplate(PowerPlatformConfiguration config, string template)
        {
            Console.WriteLine($"📋 Applying template: {template}");
            
            switch (template.ToLower())
            {
                case "customerservice":
                    ApplyCustomerServiceTemplate(config);
                    break;
                case "sales":
                    ApplySalesTemplate(config);
                    break;
                case "fieldservice":
                    ApplyFieldServiceTemplate(config);
                    break;
                case "finance":
                    ApplyFinanceTemplate(config);
                    break;
                default:
                    Console.WriteLine($"⚠️ Unknown template: {template}. Available templates: customerservice, sales, fieldservice, finance");
                    break;
            }
        }

        private static void ApplyCustomerServiceTemplate(PowerPlatformConfiguration config)
        {
            config.Project.Description = "Customer service solution with Dynamics 365 Customer Service and Power Platform";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Reduce case resolution time by 40%",
                "Increase customer satisfaction to 95%+",
                "Enable 24/7 self-service capabilities",
                "Improve agent productivity through automation"
            });
        }

        private static void ApplySalesTemplate(PowerPlatformConfiguration config)
        {
            config.Project.Description = "Sales automation solution with Dynamics 365 Sales and Power Platform";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Increase sales productivity by 35%",
                "Improve lead conversion rates",
                "Enable mobile sales capabilities",
                "Provide real-time sales insights"
            });
        }

        private static void ApplyFieldServiceTemplate(PowerPlatformConfiguration config)
        {
            config.Project.Description = "Field service management with Dynamics 365 Field Service and Power Platform";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Optimize technician scheduling and routing",
                "Improve first-time fix rates to 90%+",
                "Enable mobile workforce capabilities",
                "Reduce service delivery costs by 25%"
            });
        }

        private static void ApplyFinanceTemplate(PowerPlatformConfiguration config)
        {
            config.Project.Description = "Finance and operations solution with Dynamics 365 Finance and Power Platform";
            config.Business.BusinessDrivers.Clear();
            config.Business.BusinessDrivers.AddRange(new[]
            {
                "Automate accounts payable processes",
                "Improve financial reporting accuracy",
                "Enable real-time financial insights",
                "Reduce month-end close time by 50%"
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
            Console.WriteLine("                               (customerservice, sales, fieldservice, finance)");
            Console.WriteLine("  -ni, --non-interactive       Run without user prompts");
            Console.WriteLine("  -h, --help                   Show this help message");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("  dotnet run --project-name \"My Solution\" --company \"My Company\"");
            Console.WriteLine("  dotnet run --template customerservice --output ./my-diagram.svg");
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
            Console.WriteLine("  1. customerservice - Customer Service with D365 Customer Service");
            Console.WriteLine("  2. sales          - Sales automation with D365 Sales");
            Console.WriteLine("  3. fieldservice   - Field Service management with D365 Field Service");
            Console.WriteLine("  4. finance        - Finance operations with D365 Finance");
            Console.WriteLine("  (press Enter to skip template)");
            Console.Write("Choose template (1-4 or name): ");
            var templateChoice = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(templateChoice))
            {
                switch (templateChoice.ToLower())
                {
                    case "1":
                    case "customerservice":
                        options.Template = "customerservice";
                        break;
                    case "2":
                    case "sales":
                        options.Template = "sales";
                        break;
                    case "3":
                    case "fieldservice":
                        options.Template = "fieldservice";
                        break;
                    case "4":
                    case "finance":
                        options.Template = "finance";
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