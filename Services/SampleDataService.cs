using System;
using System.Collections.Generic;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Services
{
    public class SampleDataService
    {
        public PowerPlatformConfiguration CreateSampleConfiguration()
        {
            return new PowerPlatformConfiguration
            {
                Project = new ProjectInfo
                {
                    Name = "Customer Service Power Platform Solution",
                    Version = "1.0",
                    Company = "Contoso Corporation",
                    Description = "Comprehensive customer service solution using Dynamics 365 Customer Service and Power Platform",
                    Author = "Power Platform Architecture Team",
                    Status = "In Development"
                },
                Business = new BusinessContext
                {
                    ExecutiveSummary = new List<string>
                    {
                        "Unified customer service platform using Dynamics 365 and Power Platform",
                        "Automated case routing and resolution workflows",
                        "Self-service customer portal with Power Apps",
                        "Real-time dashboards and analytics with Power BI"
                    },
                    BusinessDrivers = new List<string>
                    {
                        "Reduce average case resolution time by 40%",
                        "Increase customer satisfaction scores to 95%+",
                        "Enable agent productivity through automation",
                        "Provide 360-degree customer view across all touchpoints"
                    },
                    SuccessCriteria = new List<string>
                    {
                        "Average case resolution time < 24 hours",
                        "Customer satisfaction score > 4.5/5",
                        "Agent productivity increase by 30%",
                        "Self-service adoption rate > 70%"
                    },
                    Principles = new List<string>
                    {
                        "Customer-centric design",
                        "Process automation first",
                        "Data-driven decision making",
                        "Scalable cloud architecture"
                    },
                    Scope = new SystemScope
                    {
                        InScope = new List<string>
                        {
                            "Dynamics 365 Customer Service implementation",
                            "Power Apps customer portal",
                            "Power Automate workflow automation",
                            "Power BI reporting and analytics",
                            "Knowledge base and self-service"
                        },
                        OutOfScope = new List<string>
                        {
                            "Dynamics 365 Sales module",
                            "Third-party telephony integration",
                            "Legacy CRM data migration",
                            "Advanced AI capabilities"
                        }
                    },
                    Stakeholders = new List<Stakeholder>
                    {
                        new Stakeholder { Name = "Customer Service Agents", Type = "Primary", UserCount = 120, Influence = "High" },
                        new Stakeholder { Name = "Customer Service Managers", Type = "Primary", UserCount = 15, Influence = "High" },
                        new Stakeholder { Name = "Customers", Type = "Primary", UserCount = 25000, Influence = "High" },
                        new Stakeholder { Name = "IT Administrators", Type = "Secondary", UserCount = 8, Influence = "Medium" }
                    },
                    BusinessProcesses = new List<BusinessProcess>
                    {
                        new BusinessProcess
                        {
                            Name = "Case Management",
                            Type = "Core",
                            Description = "End-to-end customer case lifecycle management",
                            Steps = new List<string> { "Case Creation", "Case Assignment", "Investigation", "Resolution", "Case Closure" },
                            CurrentState = "Manual",
                            FutureState = "Automated",
                            AutomationOpportunities = new List<string> { "Automatic case routing", "SLA monitoring", "Escalation workflows" }
                        },
                        new BusinessProcess
                        {
                            Name = "Knowledge Management",
                            Type = "Supporting",
                            Description = "Creation and maintenance of knowledge articles",
                            Steps = new List<string> { "Article Creation", "Review & Approval", "Publishing", "Usage Tracking", "Article Updates" },
                            CurrentState = "Manual",
                            FutureState = "Partially Automated",
                            AutomationOpportunities = new List<string> { "Auto-suggest articles", "Usage analytics", "Content approval workflow" }
                        }
                    }
                },
                Personas = new List<UserPersona>
                {
                    new UserPersona
                    {
                        Name = "Sarah Johnson",
                        Role = "Customer Service Agent",
                        Department = "Customer Support",
                        Background = new List<string>
                        {
                            "3 years customer service experience",
                            "Familiar with CRM systems",
                            "Handles 50-60 cases per day",
                            "Expert in product troubleshooting"
                        },
                        Goals = new List<string>
                        {
                            "Resolve customer issues quickly",
                            "Access complete customer history",
                            "Use knowledge base efficiently",
                            "Meet SLA targets consistently"
                        },
                        PainPoints = new List<string>
                        {
                            "Switching between multiple systems",
                            "Difficulty finding relevant knowledge articles",
                            "Manual case routing delays",
                            "Incomplete customer information"
                        },
                        TechSkillLevel = "Intermediate",
                        Dynamics365Access = new List<string> { "Customer Service Hub", "Knowledge Management" },
                        PowerPlatformAccess = new List<string> { "Case Management App", "Agent Dashboard" },
                        SecurityRoles = new List<string> { "Customer Service Representative", "Knowledge Manager" }
                    },
                    new UserPersona
                    {
                        Name = "Mike Chen",
                        Role = "Customer",
                        Department = "External Customer",
                        Background = new List<string>
                        {
                            "Technology-savvy business user",
                            "Prefers self-service options",
                            "Uses mobile devices frequently",
                            "Values quick problem resolution"
                        },
                        Goals = new List<string>
                        {
                            "Find solutions without calling support",
                            "Track case status in real-time",
                            "Access account information easily",
                            "Get quick responses to inquiries"
                        },
                        PainPoints = new List<string>
                        {
                            "Long wait times for support",
                            "Repeating information to different agents",
                            "Limited self-service options",
                            "Difficulty finding relevant help content"
                        },
                        TechSkillLevel = "Advanced",
                        PowerPlatformAccess = new List<string> { "Customer Portal", "Self-Service App" },
                        SecurityRoles = new List<string> { "Customer Portal User" }
                    }
                },
                PowerPlatform = new PowerPlatformComponents
                {
                    PowerApps = new List<PowerApp>
                    {
                        new PowerApp
                        {
                            Name = "Customer Portal",
                            Type = "Model-driven",
                            Description = "Self-service portal for customers to create and track cases",
                            DataSources = new List<string> { "Dataverse", "SharePoint" },
                            TargetUsers = new List<string> { "External Customers" },
                            KeyFeatures = new List<string> { "Case Creation", "Case Tracking", "Knowledge Search", "Account Information" },
                            Environment = "Production",
                            SecurityRoles = new List<string> { "Customer Portal User" }
                        },
                        new PowerApp
                        {
                            Name = "Agent Dashboard",
                            Type = "Canvas",
                            Description = "Quick access dashboard for customer service agents",
                            DataSources = new List<string> { "Dataverse", "Power BI" },
                            TargetUsers = new List<string> { "Customer Service Agents" },
                            KeyFeatures = new List<string> { "Case Summary", "Performance Metrics", "Quick Actions", "Knowledge Search" },
                            Environment = "Production",
                            SecurityRoles = new List<string> { "Customer Service Representative" }
                        }
                    },
                    PowerAutomate = new List<PowerAutomateFlow>
                    {
                        new PowerAutomateFlow
                        {
                            Name = "Case Auto-Assignment",
                            Type = "Automated",
                            Description = "Automatically assigns new cases to available agents based on skills and workload",
                            Trigger = "When a new case is created",
                            Actions = new List<string> { "Check agent availability", "Match skills to case type", "Assign case", "Send notification" },
                            ConnectorsUsed = new List<string> { "Dataverse", "Office 365 Outlook", "Teams" },
                            Environment = "Production",
                            BusinessProcess = "Case Management"
                        },
                        new PowerAutomateFlow
                        {
                            Name = "SLA Escalation",
                            Type = "Scheduled",
                            Description = "Monitors case SLAs and escalates overdue cases",
                            Trigger = "Daily schedule",
                            Actions = new List<string> { "Check case SLA status", "Identify overdue cases", "Escalate to manager", "Update case priority" },
                            ConnectorsUsed = new List<string> { "Dataverse", "Office 365 Outlook" },
                            Environment = "Production",
                            BusinessProcess = "Case Management"
                        }
                    },
                    PowerBI = new List<PowerBIReport>
                    {
                        new PowerBIReport
                        {
                            Name = "Customer Service Dashboard",
                            Type = "Dashboard",
                            Description = "Real-time overview of customer service metrics and KPIs",
                            DataSources = new List<string> { "Dataverse", "Office 365" },
                            TargetAudience = new List<string> { "Customer Service Managers", "Executives" },
                            RefreshFrequency = "Hourly",
                            Workspace = "Customer Service Workspace"
                        },
                        new PowerBIReport
                        {
                            Name = "Agent Performance Report",
                            Type = "Report",
                            Description = "Individual and team performance metrics for customer service agents",
                            DataSources = new List<string> { "Dataverse" },
                            TargetAudience = new List<string> { "Customer Service Managers", "HR" },
                            RefreshFrequency = "Daily",
                            Workspace = "Customer Service Workspace"
                        }
                    },
                    Connectors = new List<Connector>
                    {
                        new Connector
                        {
                            Name = "Dataverse",
                            Type = "Standard",
                            Description = "Primary data storage for customer service data",
                            UsedBy = new List<string> { "Customer Portal", "Agent Dashboard", "Auto-Assignment Flow" },
                            DataOperations = new List<string> { "Create", "Read", "Update", "Delete" }
                        },
                        new Connector
                        {
                            Name = "Office 365 Outlook",
                            Type = "Standard",
                            Description = "Email notifications and calendar integration",
                            UsedBy = new List<string> { "SLA Escalation Flow", "Case Auto-Assignment" },
                            DataOperations = new List<string> { "Create", "Read" }
                        }
                    }
                },
                Dynamics365 = new Dynamics365Applications
                {
                    EnabledApps = new List<D365App>
                    {
                        new D365App
                        {
                            Name = "Customer Service Hub",
                            Type = "Customer Engagement",
                            Description = "Core customer service application with case management capabilities",
                            Modules = new List<string> { "Cases", "Knowledge Management", "Entitlements", "SLA Management" },
                            Users = new List<string> { "Customer Service Agents", "Customer Service Managers" },
                            BusinessProcesses = new List<string> { "Case Management", "Knowledge Management" },
                            Environment = "Production"
                        }
                    },
                    Configuration = new D365Configuration
                    {
                        OrganizationName = "Contoso Customer Service",
                        Region = "North America",
                        Languages = new List<string> { "English", "Spanish", "French" },
                        Currencies = new List<string> { "USD", "CAD" },
                        TimeZone = "Eastern Standard Time"
                    },
                    CustomEntities = new List<D365CustomEntity>
                    {
                        new D365CustomEntity
                        {
                            Name = "Product Registration",
                            DisplayName = "Product Registration",
                            Description = "Customer product registration information for warranty and support",
                            Fields = new List<string> { "Product Model", "Serial Number", "Purchase Date", "Warranty Status" },
                            Relationships = new List<string> { "Customer (N:1)", "Product (N:1)" },
                            OwnershipType = "User or Team"
                        }
                    }
                },
                Dataverse = new DataverseConfiguration
                {
                    Entities = new List<DataverseEntity>
                    {
                        new DataverseEntity
                        {
                            Name = "Case",
                            DisplayName = "Case",
                            Type = "Standard",
                            Description = "Customer service cases and inquiries",
                            Fields = new List<string> { "Title", "Description", "Priority", "Status", "Customer", "Assigned Agent" },
                            Views = new List<string> { "Active Cases", "My Cases", "High Priority Cases" },
                            Forms = new List<string> { "Case Main Form", "Quick Create Form" }
                        },
                        new DataverseEntity
                        {
                            Name = "Knowledge Article",
                            DisplayName = "Knowledge Article",
                            Type = "Standard",
                            Description = "Self-service knowledge base articles",
                            Fields = new List<string> { "Title", "Content", "Keywords", "Category", "Status" },
                            Views = new List<string> { "Published Articles", "Draft Articles" },
                            Forms = new List<string> { "Article Main Form" }
                        }
                    },
                    SecurityRoles = new List<DataverseSecurityRole>
                    {
                        new DataverseSecurityRole
                        {
                            Name = "Customer Service Representative",
                            Description = "Full access to customer service functions",
                            Privileges = new List<string> { "Read/Write Cases", "Read Knowledge Articles", "Create Activities" },
                            BusinessUnit = "Customer Service"
                        },
                        new DataverseSecurityRole
                        {
                            Name = "Customer Portal User",
                            Description = "Limited access for external customers",
                            Privileges = new List<string> { "Read Own Cases", "Create Cases", "Read Knowledge Articles" },
                            BusinessUnit = "Customer Service"
                        }
                    },
                    BusinessUnits = new List<DataverseBusinessUnit>
                    {
                        new DataverseBusinessUnit
                        {
                            Name = "Customer Service",
                            Description = "Primary business unit for customer service operations",
                            Users = new List<string> { "Customer Service Agents", "Customer Service Managers" },
                            SecurityRoles = new List<string> { "Customer Service Representative", "Customer Service Manager" }
                        }
                    }
                },
                Integrations = new IntegrationArchitecture
                {
                    SystemIntegrations = new List<SystemIntegration>
                    {
                        new SystemIntegration
                        {
                            Name = "ERP Integration",
                            SourceSystem = "Dynamics 365 Customer Service",
                            TargetSystem = "SAP ERP",
                            IntegrationType = "Real-time",
                            Method = "REST API",
                            DataEntities = new List<string> { "Customer", "Product", "Orders" },
                            Direction = "Bidirectional"
                        }
                    },
                    APIEndpoints = new List<APIEndpoint>
                    {
                        new APIEndpoint
                        {
                            Name = "Case Management API",
                            URL = "https://api.contoso.com/cases",
                            Method = "GET",
                            Description = "Retrieve customer cases",
                            Authentication = "OAuth 2.0",
                            UsedBy = new List<string> { "Customer Portal", "Mobile App" }
                        }
                    }
                },
                Security = new SecurityModel
                {
                    SecurityRoles = new List<SecurityRole>
                    {
                        new SecurityRole
                        {
                            Name = "Customer Service Agent",
                            Description = "Standard agent permissions",
                            Privileges = new List<string> { "Read/Write Cases", "Read Knowledge Base", "Create Activities" },
                            BusinessUnit = "Customer Service",
                            AppliesTo = new List<string> { "Cases", "Knowledge Articles", "Activities" }
                        }
                    },
                    Settings = new SecuritySettings
                    {
                        MultiFactorAuthRequired = true,
                        AuditingEnabled = true,
                        SessionTimeout = 480,
                        PasswordPolicy = "Strong"
                    }
                },
                Environments = new EnvironmentStrategy
                {
                    Environments = new List<PowerPlatformEnvironment>
                    {
                        new PowerPlatformEnvironment
                        {
                            Name = "Development",
                            Type = "Development",
                            Description = "Development environment for solution building",
                            Region = "North America",
                            DataverseEnabled = true,
                            Applications = new List<string> { "Customer Portal (Dev)", "Agent Dashboard (Dev)" }
                        },
                        new PowerPlatformEnvironment
                        {
                            Name = "Production",
                            Type = "Production",
                            Description = "Live production environment",
                            Region = "North America",
                            DataverseEnabled = true,
                            Applications = new List<string> { "Customer Portal", "Agent Dashboard" }
                        }
                    },
                    ALM = new ALMStrategy
                    {
                        Strategy = "DevOps",
                        SourceControl = new List<string> { "Azure DevOps", "Git" },
                        DeploymentPipelines = new List<string> { "Build Pipeline", "Release Pipeline", "Solution Checker" },
                        Tools = new List<string> { "Power Platform CLI", "Azure Pipelines" }
                    }
                },
                Implementation = new ImplementationPlan
                {
                    Phases = new List<ImplementationPhase>
                    {
                        new ImplementationPhase
                        {
                            Name = "Foundation Setup",
                            Description = "Environment setup and core Dynamics 365 configuration",
                            StartDate = DateTime.Now.AddMonths(1),
                            EndDate = DateTime.Now.AddMonths(2),
                            Deliverables = new List<string> { "Environment Setup", "Security Configuration", "Base D365 Setup" },
                            Status = "Planned",
                            D365Components = new List<string> { "Customer Service Hub", "Case Management" },
                            PowerPlatformComponents = new List<string> { "Development Environment" }
                        },
                        new ImplementationPhase
                        {
                            Name = "Core Applications",
                            Description = "Build core Power Apps and automation flows",
                            StartDate = DateTime.Now.AddMonths(2),
                            EndDate = DateTime.Now.AddMonths(4),
                            Deliverables = new List<string> { "Customer Portal", "Agent Dashboard", "Core Flows" },
                            Status = "Planned",
                            PowerPlatformComponents = new List<string> { "Customer Portal", "Agent Dashboard", "Auto-Assignment Flow" }
                        }
                    },
                    Risks = new List<Risk>
                    {
                        new Risk
                        {
                            Description = "User adoption resistance to new system",
                            Impact = "Medium",
                            Probability = "Medium",
                            Category = "Business",
                            Mitigation = "Comprehensive training program and change management"
                        }
                    },
                    ChangeManagement = new ChangeManagement
                    {
                        StakeholderGroups = new List<string> { "Customer Service Agents", "Managers", "IT Team" },
                        TrainingPrograms = new List<string> { "Power Platform Basics", "D365 Customer Service", "New Process Training" },
                        AdoptionMetrics = new List<string> { "User Login Frequency", "Case Resolution Time", "Customer Satisfaction" }
                    }
                }
            };
        }
    }
}