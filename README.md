# Architecture Diagram Generator 🏗️

Generate professional SVG architecture diagrams from simple configurations. Cross-platform tool that creates comprehensive architecture documentation including business context, user personas, technology stack, and implementation roadmaps.

## ✅ Features

- **Interactive Mode**: Guided prompts for easy customization
- **Template-Based**: Pre-built templates for common scenarios
- **Command Line**: Full automation support
- **Cross-Platform**: Works on Linux, Windows, macOS
- **High Quality**: SVG output that scales perfectly
- **Comprehensive**: 6-page detailed architecture documentation

## 🚀 Quick Start

### Method 1: Interactive (Recommended for first use)
```bash
dotnet run
```
Follow the prompts to customize your diagram.

### Method 2: Quick Script
```bash
./generate.sh quick
```

### Method 3: Template-Based
```bash
# Use predefined templates
dotnet run --template ecommerce --project-name "My Store" --company "My Company"

# Available templates: ecommerce, enterprise, saas, startup
```

### Method 4: Command Line
```bash
dotnet run --project-name "My App" --company "My Company" --author "Me" --version "2.0"
```

## 📋 Available Templates

| Template | Description | Best For |
|----------|-------------|----------|
| `ecommerce` | Online store with payments, inventory, customer portal | E-commerce platforms, retail |
| `enterprise` | Corporate app with compliance, integration, RBAC | Large organizations, regulated industries |
| `saas` | Multi-tenant with subscriptions, analytics, scaling | SaaS products, cloud services |
| `startup` | MVP focused on rapid development, cost efficiency | Startups, proof-of-concepts |

## 🔧 Advanced Customization

1. **Generate initial diagram** using any method above
2. **Edit `architecture-config.json`** for detailed customization:
   - Business context and drivers
   - User personas and goals
   - Technology stack details
   - Implementation phases
   - Risk assessments
3. **Re-run** `dotnet run` to regenerate

## 📁 Output

- **Format**: SVG (Scalable Vector Graphics)
- **Location**: Desktop (customizable with `--output`)
- **Compatibility**: Opens in any web browser
- **Quality**: Vector graphics, infinite zoom without quality loss
- **Integration**: Import into PowerPoint, documentation tools

## 🎯 Generated Content

Your architecture diagram includes:

1. **Architecture Overview**: Business context, principles, scope, stakeholders
2. **Users & Personas**: User types, goals, pain points, behavior patterns
3. **Channels & Business Units**: Digital channels, organizational structure
4. **Data Architecture**: Data types, governance, security, compliance
5. **Technology Stack**: Frontend, backend, database, infrastructure layers
6. **Implementation Roadmap**: Phases, timeline, risks, governance

## 🛠️ Command Line Options

```bash
dotnet run [options]

Options:
  -n, --project-name <name>    Set the project name
  -c, --company <company>      Set the company name  
  -a, --author <author>        Set the author name
  -v, --version <version>      Set the project version
  -o, --output <path>          Set the output file path
  -t, --template <template>    Apply predefined template
  -ni, --non-interactive       Run without user prompts
  -h, --help                   Show help message
```

## 💡 Examples

```bash
# Interactive mode
dotnet run

# E-commerce platform
dotnet run --template ecommerce --project-name "Online Store" --company "Retail Corp"

# Enterprise application  
dotnet run --template enterprise --project-name "ERP System" --company "BigCorp Inc"

# SaaS application
dotnet run --template saas --project-name "Analytics Platform" --company "Data Inc"

# Custom output location
dotnet run --project-name "My App" --output "./diagrams/my-architecture.svg"

# Automated build (CI/CD)
dotnet run --project-name "API Gateway" --company "Tech Co" --non-interactive
```

## 🔍 Viewing Your Diagrams

1. **Web Browser**: Double-click the `.svg` file or drag into browser
2. **VS Code**: Install SVG preview extension
3. **Presentations**: Import SVG into PowerPoint, Google Slides
4. **Documentation**: Embed in Markdown, wikis, documentation sites

## 🛠️ Development

### Requirements
- .NET 8.0 or later
- Linux, Windows, or macOS

### Build
```bash
dotnet build
```

### Test
```bash
dotnet run --help
```

## 📄 Configuration File Structure

The `architecture-config.json` file contains:

```json
{
  "project": {
    "name": "Your Project",
    "version": "1.0", 
    "company": "Your Company",
    "description": "Project description"
  },
  "business": {
    "executiveSummary": ["Key points..."],
    "businessDrivers": ["Driver 1", "Driver 2"],
    "successCriteria": ["Criteria 1", "Criteria 2"]
  },
  "personas": [
    {
      "name": "User Name",
      "role": "User Type",
      "goals": ["Goal 1", "Goal 2"],
      "painPoints": ["Pain 1", "Pain 2"]
    }
  ],
  "technology": {
    "frontend": [...],
    "backend": [...],
    "database": [...],
    "infrastructure": [...]
  }
}
```

## 🆘 Troubleshooting

- **Build errors**: Ensure .NET 8+ is installed
- **SVG won't open**: Check for XML validation errors
- **Missing content**: Verify JSON syntax in config file
- **Permission errors**: Ensure write access to output directory

## 📝 License

Open source - modify and distribute as needed.

---

**Ready to create your architecture diagram?** Run `dotnet run` and follow the prompts! 🚀