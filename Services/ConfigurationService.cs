using System;
using System.IO;
using System.Text.Json;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Services
{
    public class ConfigurationService
    {
        private const string ConfigFileName = "architecture-config.json";
        
        public ArchitectureConfiguration LoadOrCreateConfiguration()
        {
            if (File.Exists(ConfigFileName))
            {
                Console.WriteLine($"📖 Loading configuration from {ConfigFileName}");
                try
                {
                    string json = File.ReadAllText(ConfigFileName);
                    var config = JsonSerializer.Deserialize<ArchitectureConfiguration>(json, GetJsonOptions());
                    Console.WriteLine("✅ Configuration loaded successfully!");
                    return config ?? CreateSampleConfiguration();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️ Error loading configuration: {ex.Message}");
                    Console.WriteLine("Creating sample configuration...");
                }
            }
            
            Console.WriteLine($"📝 Creating sample configuration at {ConfigFileName}");
            var sampleConfig = CreateSampleConfiguration();
            
            try
            {
                SaveConfiguration(sampleConfig);
                Console.WriteLine("✅ Sample configuration created! Edit this file to customize your architecture.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Could not save configuration: {ex.Message}");
            }
            
            return sampleConfig;
        }

        public void SaveConfiguration(ArchitectureConfiguration config)
        {
            string json = JsonSerializer.Serialize(config, GetJsonOptions());
            File.WriteAllText(ConfigFileName, json);
        }

        private ArchitectureConfiguration CreateSampleConfiguration()
        {
            var sampleDataService = new SampleDataService();
            return sampleDataService.CreateSampleConfiguration();
        }

        private JsonSerializerOptions GetJsonOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }
    }
}