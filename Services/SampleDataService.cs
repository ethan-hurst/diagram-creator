using System;
using System.Collections.Generic;
using VisioArchitectureGenerator.Models;

namespace VisioArchitectureGenerator.Services
{
    public class SampleDataService
    {
        public ArchitectureConfiguration CreateSampleConfiguration()
        {
            return new ArchitectureConfiguration
            {
                Project = new ProjectInfo
                {
                    Name = "Enterprise Customer Portal",
                    Version = "2.0",
                    Company = "Acme Corporation",
                    Description = "Next-generation customer self-service portal with mobile-first design",
                    Author = "Solution Architecture Team",
                    Status = "In Development"
                },
                Business = new BusinessContext
                {
                    ExecutiveSummary = new List<string>
                    {
                        "Modern, scalable customer portal",
                        "Mobile-first responsive design",
                        "Integration with existing CRM and billing systems",
                        "Enhanced self-service capabilities"
                    },
                    BusinessDrivers = new List<string>
                    {
                        "Reduce customer service costs by 30%",
                        "Improve customer satisfaction scores",
                        "Enable 24/7 self-service capabilities",
                        "Support business growth and scalability"
                    },
                    SuccessCriteria = new List<string>
                    {
                        "99.9% system uptime",
                        "< 2 second page load times",
                        "Support 50,000 concurrent users",
                        "Mobile usage > 60% of total traffic"
                    },
                    Principles = new List<string>
                    {
                        "Mobile-first design approach",
                        "API-driven architecture",
                        "Cloud-native deployment",
                        "Security by design"
                    },
                    Scope = new SystemScope
                    {
                        InScope = new List<string>
                        {
                            "Customer registration and profile management",
                            "Account management and billing inquiry",
                            "Service request submission and tracking",
                            "Document management and downloads",
                            "Mobile applications (iOS/Android)"
                        },
                        OutOfScope = new List<string>
                        {
                            "Legacy system migration",
                            "Payment processing integration",
                            "Call center systems",
                            "Marketing automation platform"
                        }
                    },
                    Stakeholders = new List<Stakeholder>
                    {
                        new Stakeholder { Name = "Customers", Type = "Primary", UserCount = 45000, Influence = "High" },
                        new Stakeholder { Name = "Customer Service Reps", Type = "Primary", UserCount = 150, Influence = "High" },
                        new Stakeholder { Name = "Account Managers", Type = "Secondary", UserCount = 25, Influence = "Medium" },
                        new Stakeholder { Name = "System Administrators", Type = "Secondary", UserCount = 8, Influence = "Medium" }
                    }
                },
                Personas = new List<UserPersona>
                {
                    new UserPersona
                    {
                        Name = "Sarah Chen",
                        Role = "Business Customer",
                        Department = "Operations Manager at Tech Startup",
                        Background = new List<string>
                        {
                            "5 years experience managing vendor relationships",
                            "Manages multiple service accounts",
                            "Prefers self-service options",
                            "Technology-savvy early adopter"
                        },
                        Goals = new List<string>
                        {
                            "Quickly access account information",
                            "Submit and track service requests",
                            "Download invoices and reports",
                            "Manage team access permissions"
                        },
                        PainPoints = new List<string>
                        {
                            "Complex navigation in current system",
                            "Limited mobile functionality",
                            "Slow response times during peak hours",
                            "Difficulty finding specific documents"
                        },
                        TechSkillLevel = "Advanced",
                        PreferredChannels = new List<string> { "Mobile App", "Web Portal", "API Integration" },
                        Behavior = new UserBehavior
                        {
                            UsageFrequency = "Daily",
                            PeakUsageTime = "9AM-11AM, 2PM-4PM",
                            DevicePreference = "Mobile-first, Desktop for complex tasks"
                        }
                    },
                    new UserPersona
                    {
                        Name = "Mike Rodriguez",
                        Role = "Individual Consumer",
                        Department = "Personal Account Holder",
                        Background = new List<string>
                        {
                            "Occasional technology user",
                            "Prefers simple, intuitive interfaces",
                            "Values quick problem resolution",
                            "Limited time for complex processes"
                        },
                        Goals = new List<string>
                        {
                            "Pay bills and view statements",
                            "Update personal information",
                            "Report service issues",
                            "Access help and support resources"
                        },
                        PainPoints = new List<string>
                        {
                            "Too many steps to complete simple tasks",
                            "Confusing technical terminology",
                            "Difficulty accessing on mobile devices",
                            "Long wait times for customer service"
                        },
                        TechSkillLevel = "Beginner",
                        PreferredChannels = new List<string> { "Web Portal", "Phone Support", "Email" },
                        Behavior = new UserBehavior
                        {
                            UsageFrequency = "Weekly",
                            PeakUsageTime = "Evenings and weekends",
                            DevicePreference = "Desktop, some mobile"
                        }
                    }
                },
                Channels = new ChannelArchitecture
                {
                    Digital = new List<DigitalChannel>
                    {
                        new DigitalChannel
                        {
                            Name = "Customer Web Portal",
                            Type = "Web",
                            Description = "Responsive web application for all customer self-service needs",
                            Features = new List<string> { "Account management", "Billing", "Support tickets", "Document access" },
                            Technologies = new List<string> { "React", "Node.js", "Progressive Web App" },
                            UserBase = "All customer segments"
                        },
                        new DigitalChannel
                        {
                            Name = "Mobile Applications",
                            Type = "Mobile",
                            Description = "Native iOS and Android apps for on-the-go access",
                            Features = new List<string> { "Quick account overview", "Push notifications", "Mobile payments", "Location services" },
                            Technologies = new List<string> { "React Native", "Firebase", "Biometric authentication" },
                            UserBase = "Mobile-first customers"
                        }
                    },
                    Traditional = new List<TraditionalChannel>
                    {
                        new TraditionalChannel { Name = "Phone Support", Type = "Voice", Description = "24/7 customer service hotline", Integration = "CRM integration for context" },
                        new TraditionalChannel { Name = "Email Support", Type = "Email", Description = "Automated and manual email responses", Integration = "Ticket system integration" }
                    },
                    Integration = new ChannelIntegration
                    {
                        Strategy = "Omnichannel customer experience",
                        SharedServices = new List<string> { "Single sign-on", "Unified customer profile", "Consistent branding" },
                        DataSynchronization = new List<string> { "Real-time customer data sync", "Activity tracking across channels" }
                    }
                },
                BusinessUnits = new List<BusinessUnit>
                {
                    new BusinessUnit
                    {
                        Name = "Customer Experience",
                        Type = "Core",
                        Description = "Manages all customer-facing interactions and experience design",
                        KeyFunctions = new List<string> { "Customer journey mapping", "Experience optimization", "Feedback collection" },
                        PrimaryUsers = new List<string> { "CX Managers", "UX Designers", "Customer Success Reps" },
                        MainProcesses = new List<string> { "Customer onboarding", "Support case management", "Satisfaction surveys" }
                    },
                    new BusinessUnit
                    {
                        Name = "IT Operations",
                        Type = "Supporting",
                        Description = "Maintains and operates all technical infrastructure",
                        KeyFunctions = new List<string> { "System monitoring", "Incident response", "Performance optimization" },
                        PrimaryUsers = new List<string> { "System Administrators", "DevOps Engineers", "Security Analysts" },
                        MainProcesses = new List<string> { "24/7 monitoring", "Deployment management", "Security patching" }
                    }
                },
                Data = new DataArchitecture
                {
                    DataTypes = new List<DataType>
                    {
                        new DataType { Name = "Customer Data", Category = "Master", Description = "Core customer profile and account information", Volume = "45,000 records", UpdateFrequency = "Real-time" },
                        new DataType { Name = "Transaction Data", Category = "Transactional", Description = "All customer transactions and interactions", Volume = "2M records/month", UpdateFrequency = "Real-time" }
                    },
                    DataStores = new List<DataStore>
                    {
                        new DataStore { Name = "Customer Database", Type = "Database", Technology = "PostgreSQL", Purpose = "Primary customer and account data" },
                        new DataStore { Name = "Session Cache", Type = "Cache", Technology = "Redis", Purpose = "High-performance session management" }
                    },
                    Flow = new DataFlow
                    {
                        IngestionMethods = new List<string> { "Real-time API calls", "Nightly batch ETL", "Event streaming" },
                        ProcessingSteps = new List<string> { "Data validation", "Business rule application", "Enrichment and transformation" },
                        DistributionChannels = new List<string> { "REST APIs", "GraphQL endpoints", "Real-time dashboards" }
                    },
                    Governance = new DataGovernance
                    {
                        QualityMeasures = new List<string> { "Automated data validation", "Data lineage tracking", "Quality scorecards" },
                        SecurityControls = new List<string> { "Role-based access control", "Data encryption at rest and transit", "Audit logging" },
                        RetentionPolicies = new List<string> { "Customer data: 7 years", "Transaction logs: 3 years", "Analytics data: 5 years" },
                        ComplianceRequirements = new List<string> { "GDPR compliance", "SOX financial controls", "PCI DSS for payment data" }
                    }
                },
                Technology = new TechnologyStack
                {
                    Infrastructure = new Infrastructure
                    {
                        Cloud = new CloudPlatform
                        {
                            Provider = "AWS",
                            Strategy = "Cloud-first with hybrid connectivity",
                            Services = new List<string> { "EC2", "RDS", "S3", "CloudFront", "API Gateway", "Lambda" },
                            Regions = new List<string> { "us-east-1 (primary)", "us-west-2 (DR)" }
                        },
                        Compute = new List<ComputeResource>
                        {
                            new ComputeResource { Type = "Container Orchestration", Technology = "Amazon EKS", Purpose = "Application hosting", Scaling = "Auto-scaling based on demand" },
                            new ComputeResource { Type = "Serverless Functions", Technology = "AWS Lambda", Purpose = "Event processing", Scaling = "Event-driven scaling" }
                        }
                    },
                    Application = new ApplicationTier
                    {
                        Frontend = new List<TechnologyComponent>
                        {
                            new TechnologyComponent { Name = "React", Version = "18.x", Purpose = "Web UI framework", Justification = "Component-based, excellent ecosystem" },
                            new TechnologyComponent { Name = "React Native", Version = "0.72.x", Purpose = "Mobile app development", Justification = "Code reuse across platforms" }
                        },
                        Backend = new List<TechnologyComponent>
                        {
                            new TechnologyComponent { Name = "Node.js", Version = "18 LTS", Purpose = "API and business logic", Justification = "JavaScript consistency, excellent performance" },
                            new TechnologyComponent { Name = "Express.js", Version = "4.x", Purpose = "Web framework", Justification = "Lightweight, flexible, well-documented" }
                        },
                        Database = new List<TechnologyComponent>
                        {
                            new TechnologyComponent { Name = "PostgreSQL", Version = "15.x", Purpose = "Primary database", Justification = "ACID compliance, JSON support, mature" },
                            new TechnologyComponent { Name = "Redis", Version = "7.x", Purpose = "Caching and sessions", Justification = "High performance, data structure support" }
                        }
                    },
                    Security = new SecurityFramework
                    {
                        IdentityManagement = new List<string> { "OAuth 2.0 / OpenID Connect", "Multi-factor authentication", "Single sign-on (SSO)" },
                        NetworkSecurity = new List<string> { "WAF (Web Application Firewall)", "DDoS protection", "VPC with private subnets" },
                        ApplicationSecurity = new List<string> { "Code security scanning", "Dependency vulnerability scanning", "Secure coding practices" },
                        DataProtection = new List<string> { "Encryption at rest (AES-256)", "Encryption in transit (TLS 1.3)", "Key management service" }
                    },
                    Operations = new MonitoringOperations
                    {
                        ApplicationMonitoring = new List<string> { "Application performance monitoring (APM)", "Real user monitoring (RUM)", "Synthetic monitoring" },
                        InfrastructureMonitoring = new List<string> { "Server and container monitoring", "Database performance monitoring", "Network monitoring" },
                        LogManagement = new List<string> { "Centralized logging", "Log analysis and search", "Security event correlation" },
                        AlertingStrategy = new List<string> { "Tiered alerting (P1-P4)", "Intelligent alert grouping", "Escalation procedures" }
                    }
                },
                Implementation = new ImplementationPlan
                {
                    Phases = new List<ImplementationPhase>
                    {
                        new ImplementationPhase
                        {
                            Name = "Foundation & Core Services",
                            Description = "Basic infrastructure, authentication, and core APIs",
                            StartDate = DateTime.Now.AddMonths(1),
                            EndDate = DateTime.Now.AddMonths(4),
                            Deliverables = new List<string> { "Cloud infrastructure", "User authentication", "Core customer APIs", "Basic web portal" },
                            Status = "Planning"
                        },
                        new ImplementationPhase
                        {
                            Name = "Enhanced Portal & Mobile",
                            Description = "Full-featured web portal and mobile applications",
                            StartDate = DateTime.Now.AddMonths(4),
                            EndDate = DateTime.Now.AddMonths(7),
                            Deliverables = new List<string> { "Complete web portal", "iOS/Android apps", "Advanced self-service features" },
                            Status = "Planned"
                        }
                    },
                    Governance = new GovernanceStructure
                    {
                        DecisionMaking = new List<string> { "Architecture Review Board", "Technical Steering Committee", "Product Owner approval" },
                        ReviewCycles = new List<string> { "Weekly sprint reviews", "Monthly architecture reviews", "Quarterly strategy alignment" },
                        QualityGates = new List<string> { "Code review requirements", "Automated testing thresholds", "Security vulnerability limits" }
                    },
                    Risks = new List<Risk>
                    {
                        new Risk { Description = "Legacy system integration complexity", Impact = "High", Probability = "Medium", Mitigation = "Phased integration approach with fallback plans" },
                        new Risk { Description = "High user adoption resistance", Impact = "Medium", Probability = "Low", Mitigation = "Comprehensive training program and change management" }
                    }
                }
            };
        }
    }
}