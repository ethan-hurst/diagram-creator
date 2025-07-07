#!/bin/bash

# Quick setup script for Architecture Generator

echo "🚀 Setting up Architecture Generator..."

# Create directories
mkdir -p Models
mkdir -p Services  
mkdir -p Generators

echo "📁 Directory structure created"

# Create the project file
cat > VisioArchitectureGenerator.csproj << 'EOF'
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="System.Drawing.Common" Version="7.0.0" />
  </ItemGroup>

</Project>
EOF

echo "📦 Project file created"

# Build and run instructions
echo ""
echo "✅ Setup complete!"
echo ""
echo "Next steps:"
echo "1. Copy the Models/ArchitectureConfiguration.cs file"
echo "2. Copy the Services/ConfigurationService.cs file"  
echo "3. Copy the Services/SampleDataService.cs file"
echo "4. Copy the Generators/SvgGenerator.cs file"
echo "5. Copy the Program.cs file"
echo "6. Run: dotnet restore && dotnet build && dotnet run"
echo ""
echo "🎯 The app will generate an SVG architecture diagram!"