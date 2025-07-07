# Architecture Diagram Customization Guide

## Overview
The Architecture Document Generator creates SVG diagrams based on a JSON configuration file. You can customize every aspect of your architecture by editing the `architecture-config.json` file.

## Configuration Sections

### 1. Project Information
```json
{
  "project": {
    "name": "Your Project Name",
    "version": "1.0",
    "company": "Your Company",
    "description": "Project description",
    "author": "Your Name",
    "status": "Draft|In Development|Production"
  }
}
```

### 2. Business Context
```json
{
  "business": {
    "executiveSummary": ["Key point 1", "Key point 2"],
    "businessDrivers": ["Driver 1", "Driver 2"],
    "successCriteria": ["Criteria 1", "Criteria 2"],
    "principles": ["Principle 1", "Principle 2"]
  }
}
```

### 3. User Personas
```json
{
  "personas": [
    {
      "name": "John Doe",
      "role": "End User",
      "department": "Sales",
      "goals": ["Goal 1", "Goal 2"],
      "painPoints": ["Pain 1", "Pain 2"],
      "techSkillLevel": "Beginner|Intermediate|Advanced"
    }
  ]
}
```

### 4. Technology Stack
```json
{
  "technology": {
    "frontend": [
      {
        "name": "React",
        "category": "Framework",
        "purpose": "UI Development",
        "version": "18.x"
      }
    ],
    "backend": [...],
    "database": [...],
    "infrastructure": [...]
  }
}
```

## Quick Customization Methods

### Method 1: Command Line Parameters
Run the application with custom parameters:
```bash
dotnet run --project-name "My Project" --company "My Company"
```

### Method 2: Interactive Mode
Run in interactive mode to be prompted for key information:
```bash
dotnet run --interactive
```

### Method 3: Template Selection
Choose from predefined templates:
```bash
dotnet run --template ecommerce|enterprise|startup|saas
```

### Method 4: Direct JSON Editing
Edit the `architecture-config.json` file directly and re-run the application.

## Common Customization Scenarios

### E-commerce Platform
- Focus on customer journey, payment processing, inventory management
- Include mobile apps, web portal, admin dashboard
- Emphasize security, scalability, and integration

### Enterprise Application
- Multiple user roles and permissions
- Integration with existing enterprise systems
- Compliance and security requirements
- Scalability and performance considerations

### SaaS Application
- Multi-tenant architecture
- API-first design
- Subscription management
- Analytics and monitoring

## Tips for Effective Customization

1. **Start with the sample**: Modify the existing sample rather than starting from scratch
2. **Focus on your audience**: Tailor the level of detail to your stakeholders
3. **Include real data**: Use actual user counts, performance requirements, etc.
4. **Keep it current**: Update the configuration as your architecture evolves
5. **Validate your JSON**: Ensure the JSON syntax is correct before running

## Output Customization

The SVG output can be customized by modifying:
- Colors and styling in the SvgGenerator.cs
- Page layouts and content organization
- Adding custom sections or removing unused ones

## Next Steps

1. Edit `architecture-config.json` with your project details
2. Run `dotnet run` to generate your custom diagram
3. Open the generated SVG file in a web browser
4. Iterate and refine based on feedback
