#!/bin/bash

# Quick Architecture Diagram Generator Script
# This script provides an easy way to generate custom architecture diagrams

echo "🏗️  Quick Architecture Diagram Generator"
echo "======================================="
echo

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "❌ .NET is not installed. Please install .NET 8 or later."
    exit 1
fi

# Function to show usage
show_usage() {
    echo "Usage: $0 [quick|custom|template|help]"
    echo
    echo "Commands:"
    echo "  quick     - Generate with minimal prompts (recommended for first use)"
    echo "  custom    - Interactive customization"
    echo "  template  - Choose from predefined templates"
    echo "  help      - Show detailed help"
    echo
    echo "Examples:"
    echo "  $0 quick"
    echo "  $0 template ecommerce"
    echo "  $0 custom"
}

# Function for quick generation
quick_generate() {
    echo "🚀 Quick Generation Mode"
    echo "This will create a diagram with minimal input."
    echo
    
    read -p "Project Name (default: My Project): " project_name
    project_name=${project_name:-"My Project"}
    
    read -p "Company Name (default: My Company): " company_name
    company_name=${company_name:-"My Company"}
    
    read -p "Your Name (default: Architecture Team): " author_name
    author_name=${author_name:-"Architecture Team"}
    
    echo
    echo "🎨 Generating your architecture diagram..."
    dotnet run --project-name "$project_name" --company "$company_name" --author "$author_name" --non-interactive
}

# Function for template selection
template_generate() {
    template_type=$1
    
    if [ -z "$template_type" ]; then
        echo "📋 Available Templates:"
        echo "  1. ecommerce  - E-commerce platform"
        echo "  2. enterprise - Enterprise application"
        echo "  3. saas       - SaaS application"
        echo "  4. startup    - Startup MVP"
        echo
        read -p "Choose a template (1-4 or name): " choice
        
        case $choice in
            1|ecommerce) template_type="ecommerce" ;;
            2|enterprise) template_type="enterprise" ;;
            3|saas) template_type="saas" ;;
            4|startup) template_type="startup" ;;
            *) echo "❌ Invalid choice"; exit 1 ;;
        esac
    fi
    
    read -p "Project Name: " project_name
    read -p "Company Name: " company_name
    
    echo
    echo "🎨 Generating $template_type architecture diagram..."
    dotnet run --template "$template_type" --project-name "$project_name" --company "$company_name" --non-interactive
}

# Function for custom interactive mode
custom_generate() {
    echo "🔧 Custom Interactive Mode"
    echo "This will walk you through detailed customization."
    echo
    
    echo "First, let's set up the basic project information:"
    read -p "Project Name: " project_name
    read -p "Company Name: " company_name
    read -p "Author Name: " author_name
    read -p "Version (default: 1.0): " version
    version=${version:-"1.0"}
    
    echo
    echo "Now generating with your settings..."
    dotnet run --project-name "$project_name" --company "$company_name" --author "$author_name" --version "$version" --non-interactive
    
    echo
    echo "📝 To further customize your diagram:"
    echo "  1. Edit the 'architecture-config.json' file that was created"
    echo "  2. Run 'dotnet run' again to regenerate with your changes"
    echo "  3. See CUSTOMIZATION_GUIDE.md for detailed instructions"
}

# Function to show detailed help
show_help() {
    echo "🏗️  Architecture Diagram Generator - Detailed Help"
    echo "================================================="
    echo
    echo "This tool generates SVG architecture diagrams based on your specifications."
    echo
    echo "🚀 QUICK START:"
    echo "  1. Run: $0 quick"
    echo "  2. Answer a few questions"
    echo "  3. Your diagram will be generated!"
    echo
    echo "📋 TEMPLATES:"
    echo "  Use predefined templates for common scenarios:"
    echo "  • ecommerce  - Online store, payments, inventory"
    echo "  • enterprise - Corporate app, compliance, integration"  
    echo "  • saas       - Multi-tenant, subscriptions, analytics"
    echo "  • startup    - MVP, rapid development, cost-effective"
    echo
    echo "🔧 ADVANCED CUSTOMIZATION:"
    echo "  1. Generate a basic diagram first"
    echo "  2. Edit 'architecture-config.json' file"
    echo "  3. Modify sections like:"
    echo "     - User personas and goals"
    echo "     - Technology stack"
    echo "     - Business requirements"
    echo "     - Implementation timeline"
    echo "  4. Re-run to generate updated diagram"
    echo
    echo "📁 OUTPUT:"
    echo "  • SVG file created on Desktop"
    echo "  • Open in any web browser to view"
    echo "  • Can be imported into presentations"
    echo
    echo "💡 TIPS:"
    echo "  • Start with a template closest to your needs"
    echo "  • Use 'quick' mode for first-time users"
    echo "  • JSON file allows unlimited customization"
    echo "  • Generated file name includes timestamp"
    echo
    echo "🆘 TROUBLESHOOTING:"
    echo "  • Ensure .NET 8+ is installed"
    echo "  • Check JSON syntax if editing manually"
    echo "  • Run 'dotnet build' to check for errors"
    echo
    dotnet run --help
}

# Main script logic
case "${1:-help}" in
    quick)
        quick_generate
        ;;
    custom)
        custom_generate
        ;;
    template)
        template_generate "$2"
        ;;
    help|--help|-h)
        show_help
        ;;
    *)
        show_usage
        ;;
esac
