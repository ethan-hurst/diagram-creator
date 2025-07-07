using System;
using System.Collections.Generic;

namespace VisioArchitectureGenerator.Models
{
    // Main configuration container
    public class ArchitectureConfiguration
    {
        public ProjectInfo Project { get; set; } = new();
        public BusinessContext Business { get; set; } = new();
        public List<UserPersona> Personas { get; set; } = new();
        public ChannelArchitecture Channels { get; set; } = new();
        public List<BusinessUnit> BusinessUnits { get; set; } = new();
        public DataArchitecture Data { get; set; } = new();
        public TechnologyStack Technology { get; set; } = new();
        public ImplementationPlan Implementation { get; set; } = new();
    }

    // Project information
    public class ProjectInfo
    {
        public string Name { get; set; } = "Solution Architecture";
        public string Version { get; set; } = "1.0";
        public string Company { get; set; } = "Your Organization";
        public string Description { get; set; } = "Enterprise solution architecture";
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string Author { get; set; } = "Architecture Team";
        public string Status { get; set; } = "Draft";
    }

    // Business context and scope
    public class BusinessContext
    {
        public List<string> ExecutiveSummary { get; set; } = new();
        public List<string> BusinessDrivers { get; set; } = new();
        public List<string> SuccessCriteria { get; set; } = new();
        public List<string> Principles { get; set; } = new();
        public SystemScope Scope { get; set; } = new();
        public List<Stakeholder> Stakeholders { get; set; } = new();
    }

    public class SystemScope
    {
        public List<string> InScope { get; set; } = new();
        public List<string> OutOfScope { get; set; } = new();
        public List<string> Dependencies { get; set; } = new();
        public List<string> Assumptions { get; set; } = new();
    }

    public class Stakeholder
    {
        public string Name { get; set; } = "";
        public string Role { get; set; } = "";
        public string Type { get; set; } = "Primary"; // Primary, Secondary
        public int UserCount { get; set; } = 0;
        public string Influence { get; set; } = "Medium"; // High, Medium, Low
    }

    // User personas and behavior
    public class UserPersona
    {
        public string Name { get; set; } = "";
        public string Role { get; set; } = "";
        public string Department { get; set; } = "";
        public List<string> Background { get; set; } = new();
        public List<string> Goals { get; set; } = new();
        public List<string> PainPoints { get; set; } = new();
        public List<string> Motivations { get; set; } = new();
        public string TechSkillLevel { get; set; } = "Intermediate"; // Beginner, Intermediate, Advanced
        public List<string> PreferredChannels { get; set; } = new();
        public UserBehavior Behavior { get; set; } = new();
    }

    public class UserBehavior
    {
        public string UsageFrequency { get; set; } = "Daily";
        public string PeakUsageTime { get; set; } = "9AM-5PM";
        public string DevicePreference { get; set; } = "Desktop";
        public List<string> TaskComplexity { get; set; } = new();
    }

    // Business units
    public class BusinessUnit
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Core"; // Core, Supporting
        public string Description { get; set; } = "";
        public List<string> KeyFunctions { get; set; } = new();
        public List<string> PrimaryUsers { get; set; } = new();
        public List<string> MainProcesses { get; set; } = new();
        public List<string> SystemInteractions { get; set; } = new();
    }

    // Channel architecture
    public class ChannelArchitecture
    {
        public List<DigitalChannel> Digital { get; set; } = new();
        public List<TraditionalChannel> Traditional { get; set; } = new();
        public ChannelIntegration Integration { get; set; } = new();
    }

    public class DigitalChannel
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = ""; // Web, Mobile, API
        public string Description { get; set; } = "";
        public List<string> Features { get; set; } = new();
        public List<string> Technologies { get; set; } = new();
        public string UserBase { get; set; } = "";
    }

    public class TraditionalChannel
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = ""; // Phone, Email, Physical
        public string Description { get; set; } = "";
        public string Integration { get; set; } = "";
    }

    public class ChannelIntegration
    {
        public string Strategy { get; set; } = "Omnichannel";
        public List<string> SharedServices { get; set; } = new();
        public List<string> DataSynchronization { get; set; } = new();
    }

    // Technology stack models
    public class TechnologyStack
    {
        public Infrastructure Infrastructure { get; set; } = new();
        public ApplicationTier Application { get; set; } = new();
        public SecurityFramework Security { get; set; } = new();
        public MonitoringOperations Operations { get; set; } = new();
    }

    public class Infrastructure
    {
        public CloudPlatform Cloud { get; set; } = new();
        public List<ComputeResource> Compute { get; set; } = new();
        public NetworkArchitecture Network { get; set; } = new();
    }

    public class CloudPlatform
    {
        public string Provider { get; set; } = "AWS"; // AWS, Azure, GCP
        public string Strategy { get; set; } = "Cloud-First"; // Cloud-First, Hybrid, Multi-Cloud
        public List<string> Services { get; set; } = new();
        public List<string> Regions { get; set; } = new();
    }

    public class ComputeResource
    {
        public string Type { get; set; } = ""; // Servers, Containers, Serverless
        public string Technology { get; set; } = "";
        public string Purpose { get; set; } = "";
        public string Scaling { get; set; } = "";
    }

    public class NetworkArchitecture
    {
        public List<string> Topology { get; set; } = new();
        public List<string> SecurityZones { get; set; } = new();
        public List<string> Protocols { get; set; } = new();
    }

    public class ApplicationTier
    {
        public List<TechnologyComponent> Frontend { get; set; } = new();
        public List<TechnologyComponent> Backend { get; set; } = new();
        public List<TechnologyComponent> Database { get; set; } = new();
        public List<TechnologyComponent> Integration { get; set; } = new();
    }

    public class TechnologyComponent
    {
        public string Name { get; set; } = "";
        public string Version { get; set; } = "";
        public string Purpose { get; set; } = "";
        public string Justification { get; set; } = "";
    }

    public class SecurityFramework
    {
        public List<string> IdentityManagement { get; set; } = new();
        public List<string> NetworkSecurity { get; set; } = new();
        public List<string> ApplicationSecurity { get; set; } = new();
        public List<string> DataProtection { get; set; } = new();
    }

    public class MonitoringOperations
    {
        public List<string> ApplicationMonitoring { get; set; } = new();
        public List<string> InfrastructureMonitoring { get; set; } = new();
        public List<string> LogManagement { get; set; } = new();
        public List<string> AlertingStrategy { get; set; } = new();
    }

    // Data architecture models
    public class DataArchitecture
    {
        public List<DataType> DataTypes { get; set; } = new();
        public List<DataStore> DataStores { get; set; } = new();
        public DataFlow Flow { get; set; } = new();
        public DataGovernance Governance { get; set; } = new();
    }

    public class DataType
    {
        public string Name { get; set; } = "";
        public string Category { get; set; } = ""; // Transactional, Master, Analytical, Metadata
        public string Description { get; set; } = "";
        public string Volume { get; set; } = "";
        public string UpdateFrequency { get; set; } = "";
    }

    public class DataStore
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = ""; // Database, Warehouse, Lake, Cache
        public string Technology { get; set; } = "";
        public string Purpose { get; set; } = "";
        public List<string> DataTypes { get; set; } = new();
    }

    public class DataFlow
    {
        public List<string> IngestionMethods { get; set; } = new();
        public List<string> ProcessingSteps { get; set; } = new();
        public List<string> DistributionChannels { get; set; } = new();
    }

    public class DataGovernance
    {
        public List<string> QualityMeasures { get; set; } = new();
        public List<string> SecurityControls { get; set; } = new();
        public List<string> RetentionPolicies { get; set; } = new();
        public List<string> ComplianceRequirements { get; set; } = new();
    }

    // Implementation planning models
    public class ImplementationPlan
    {
        public List<ImplementationPhase> Phases { get; set; } = new();
        public GovernanceStructure Governance { get; set; } = new();
        public List<Risk> Risks { get; set; } = new();
        public List<string> Dependencies { get; set; } = new();
    }

    public class ImplementationPhase
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Deliverables { get; set; } = new();
        public List<string> Dependencies { get; set; } = new();
        public string Status { get; set; } = "Planned";
    }

    public class GovernanceStructure
    {
        public List<string> DecisionMaking { get; set; } = new();
        public List<string> ReviewCycles { get; set; } = new();
        public List<string> QualityGates { get; set; } = new();
    }

    public class Risk
    {
        public string Description { get; set; } = "";
        public string Impact { get; set; } = "Medium"; // High, Medium, Low
        public string Probability { get; set; } = "Medium";
        public string Mitigation { get; set; } = "";
    }
}