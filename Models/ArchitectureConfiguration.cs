using System;
using System.Collections.Generic;

namespace VisioArchitectureGenerator.Models
{
    // Main configuration container for Dynamics 365 and Power Platform solutions
    public class PowerPlatformConfiguration
    {
        public ProjectInfo Project { get; set; } = new();
        public BusinessContext Business { get; set; } = new();
        public List<UserPersona> Personas { get; set; } = new();
        public PowerPlatformComponents PowerPlatform { get; set; } = new();
        public Dynamics365Applications Dynamics365 { get; set; } = new();
        public DataverseConfiguration Dataverse { get; set; } = new();
        public IntegrationArchitecture Integrations { get; set; } = new();
        public SecurityModel Security { get; set; } = new();
        public EnvironmentStrategy Environments { get; set; } = new();
        public ImplementationPlan Implementation { get; set; } = new();
    }

    // Project information
    public class ProjectInfo
    {
        public string Name { get; set; } = "Power Platform Solution";
        public string Version { get; set; } = "1.0";
        public string Company { get; set; } = "Your Organization";
        public string Description { get; set; } = "Dynamics 365 and Power Platform solution";
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string Author { get; set; } = "Solution Architecture Team";
        public string Status { get; set; } = "Draft";
    }

    // Business context and scope for Dynamics/Power Platform solutions
    public class BusinessContext
    {
        public List<string> ExecutiveSummary { get; set; } = new();
        public List<string> BusinessDrivers { get; set; } = new();
        public List<string> SuccessCriteria { get; set; } = new();
        public List<string> Principles { get; set; } = new();
        public SystemScope Scope { get; set; } = new();
        public List<Stakeholder> Stakeholders { get; set; } = new();
        public List<BusinessProcess> BusinessProcesses { get; set; } = new();
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

    // User personas and behavior for Dynamics/Power Platform solutions
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
        public List<string> Dynamics365Access { get; set; } = new(); // Which D365 apps they use
        public List<string> PowerPlatformAccess { get; set; } = new(); // Which Power Platform components they use
        public List<string> SecurityRoles { get; set; } = new(); // Dataverse security roles
    }

    public class UserBehavior
    {
        public string UsageFrequency { get; set; } = "Daily";
        public string PeakUsageTime { get; set; } = "9AM-5PM";
        public string DevicePreference { get; set; } = "Desktop";
        public List<string> TaskComplexity { get; set; } = new();
    }

    // Business processes for Dynamics/Power Platform solutions
    public class BusinessProcess
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Core"; // Core, Supporting
        public string Description { get; set; } = "";
        public List<string> Steps { get; set; } = new();
        public List<string> Stakeholders { get; set; } = new();
        public List<string> SystemsInvolved { get; set; } = new();
        public List<string> DataEntities { get; set; } = new();
        public List<string> AutomationOpportunities { get; set; } = new();
        public string CurrentState { get; set; } = "Manual"; // Manual, Partially Automated, Fully Automated
        public string FutureState { get; set; } = "Automated";
    }

    // Power Platform Components
    public class PowerPlatformComponents
    {
        public List<PowerApp> PowerApps { get; set; } = new();
        public List<PowerAutomateFlow> PowerAutomate { get; set; } = new();
        public List<PowerBIReport> PowerBI { get; set; } = new();
        public List<PowerVirtualAgent> PowerVirtualAgents { get; set; } = new();
        public List<PowerPagesSite> PowerPages { get; set; } = new();
        public List<Connector> Connectors { get; set; } = new();
    }

    public class PowerApp
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Canvas"; // Canvas, Model-driven
        public string Description { get; set; } = "";
        public List<string> DataSources { get; set; } = new();
        public List<string> TargetUsers { get; set; } = new();
        public List<string> KeyFeatures { get; set; } = new();
        public string Environment { get; set; } = "Development";
        public List<string> SecurityRoles { get; set; } = new();
    }

    public class PowerAutomateFlow
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Automated"; // Automated, Instant, Scheduled, Business Process
        public string Description { get; set; } = "";
        public string Trigger { get; set; } = "";
        public List<string> Actions { get; set; } = new();
        public List<string> ConnectorsUsed { get; set; } = new();
        public string Environment { get; set; } = "Development";
        public string BusinessProcess { get; set; } = "";
    }

    public class PowerBIReport
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Report"; // Report, Dashboard, Dataset
        public string Description { get; set; } = "";
        public List<string> DataSources { get; set; } = new();
        public List<string> TargetAudience { get; set; } = new();
        public string RefreshFrequency { get; set; } = "Daily";
        public string Workspace { get; set; } = "";
    }

    public class PowerVirtualAgent
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Topics { get; set; } = new();
        public List<string> Channels { get; set; } = new();
        public string Environment { get; set; } = "Development";
    }

    public class PowerPagesSite
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string URL { get; set; } = "";
        public List<string> TargetAudience { get; set; } = new();
        public List<string> DataSources { get; set; } = new();
        public string Environment { get; set; } = "Development";
    }

    public class Connector
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Standard"; // Standard, Premium, Custom
        public string Description { get; set; } = "";
        public List<string> UsedBy { get; set; } = new(); // Which apps/flows use this connector
        public List<string> DataOperations { get; set; } = new(); // Create, Read, Update, Delete
    }

    // Dynamics 365 Applications
    public class Dynamics365Applications
    {
        public List<D365App> EnabledApps { get; set; } = new();
        public D365Configuration Configuration { get; set; } = new();
        public List<D365CustomEntity> CustomEntities { get; set; } = new();
        public List<D365Workflow> Workflows { get; set; } = new();
        public List<D365Plugin> Plugins { get; set; } = new();
    }

    public class D365App
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Customer Engagement"; // Customer Engagement, Finance & Operations, Commerce
        public string Description { get; set; } = "";
        public List<string> Modules { get; set; } = new();
        public List<string> Users { get; set; } = new();
        public List<string> BusinessProcesses { get; set; } = new();
        public string Environment { get; set; } = "Development";
        public List<string> Dependencies { get; set; } = new();
    }

    public class D365Configuration
    {
        public string OrganizationName { get; set; } = "";
        public string Region { get; set; } = "North America";
        public string DatabaseVersion { get; set; } = "";
        public List<string> Languages { get; set; } = new();
        public List<string> Currencies { get; set; } = new();
        public string TimeZone { get; set; } = "";
    }

    public class D365CustomEntity
    {
        public string Name { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Fields { get; set; } = new();
        public List<string> Relationships { get; set; } = new();
        public List<string> BusinessRules { get; set; } = new();
        public string OwnershipType { get; set; } = "User or Team"; // User or Team, Organization, Business Unit
    }

    public class D365Workflow
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Background"; // Background, Real-time, Action
        public string Description { get; set; } = "";
        public string TriggerEntity { get; set; } = "";
        public List<string> TriggerEvents { get; set; } = new();
        public List<string> Steps { get; set; } = new();
    }

    public class D365Plugin
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Entity { get; set; } = "";
        public string Message { get; set; } = "";
        public string Stage { get; set; } = "PostOperation"; // PreValidation, PreOperation, PostOperation
        public string ExecutionMode { get; set; } = "Synchronous"; // Synchronous, Asynchronous
    }

    // Dataverse Configuration
    public class DataverseConfiguration
    {
        public List<DataverseEntity> Entities { get; set; } = new();
        public List<DataverseRelationship> Relationships { get; set; } = new();
        public List<DataverseSecurityRole> SecurityRoles { get; set; } = new();
        public List<DataverseBusinessUnit> BusinessUnits { get; set; } = new();
        public DataverseSettings Settings { get; set; } = new();
    }

    public class DataverseEntity
    {
        public string Name { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public string Type { get; set; } = "Standard"; // Standard, Custom, Virtual
        public string Description { get; set; } = "";
        public List<string> Fields { get; set; } = new();
        public List<string> Views { get; set; } = new();
        public List<string> Forms { get; set; } = new();
        public string OwnershipType { get; set; } = "User or Team";
        public List<string> BusinessRules { get; set; } = new();
    }

    public class DataverseRelationship
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "One-to-Many"; // One-to-Many, Many-to-One, Many-to-Many
        public string PrimaryEntity { get; set; } = "";
        public string RelatedEntity { get; set; } = "";
        public string Description { get; set; } = "";
        public bool CascadeDelete { get; set; } = false;
    }

    public class DataverseSecurityRole
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Privileges { get; set; } = new();
        public List<string> AssignedUsers { get; set; } = new();
        public List<string> AssignedTeams { get; set; } = new();
        public string BusinessUnit { get; set; } = "";
    }

    public class DataverseBusinessUnit
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ParentBusinessUnit { get; set; } = "";
        public List<string> Users { get; set; } = new();
        public List<string> Teams { get; set; } = new();
        public List<string> SecurityRoles { get; set; } = new();
    }

    public class DataverseSettings
    {
        public string OrganizationName { get; set; } = "";
        public string Region { get; set; } = "";
        public string CurrencyCode { get; set; } = "USD";
        public string TimeZone { get; set; } = "";
        public List<string> Languages { get; set; } = new();
        public bool AuditingEnabled { get; set; } = true;
        public int RecordCreationLimit { get; set; } = 80;
    }

    // Integration Architecture
    public class IntegrationArchitecture
    {
        public List<SystemIntegration> SystemIntegrations { get; set; } = new();
        public List<DataIntegration> DataIntegrations { get; set; } = new();
        public List<APIEndpoint> APIEndpoints { get; set; } = new();
        public List<WebhookConfiguration> Webhooks { get; set; } = new();
        public IntegrationPatterns Patterns { get; set; } = new();
    }

    public class SystemIntegration
    {
        public string Name { get; set; } = "";
        public string SourceSystem { get; set; } = "";
        public string TargetSystem { get; set; } = "";
        public string IntegrationType { get; set; } = "Real-time"; // Real-time, Batch, Event-driven
        public string Method { get; set; } = "REST API"; // REST API, SOAP, File, Database
        public List<string> DataEntities { get; set; } = new();
        public string Frequency { get; set; } = "";
        public string Direction { get; set; } = "Bidirectional"; // Inbound, Outbound, Bidirectional
    }

    public class DataIntegration
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string SourceSystem { get; set; } = "";
        public string TargetSystem { get; set; } = "";
        public List<string> MappedFields { get; set; } = new();
        public List<string> TransformationRules { get; set; } = new();
        public string Schedule { get; set; } = "";
        public string ErrorHandling { get; set; } = "";
    }

    public class APIEndpoint
    {
        public string Name { get; set; } = "";
        public string URL { get; set; } = "";
        public string Method { get; set; } = "GET"; // GET, POST, PUT, DELETE, PATCH
        public string Description { get; set; } = "";
        public List<string> Parameters { get; set; } = new();
        public string Authentication { get; set; } = "OAuth 2.0";
        public List<string> UsedBy { get; set; } = new();
    }

    public class WebhookConfiguration
    {
        public string Name { get; set; } = "";
        public string TriggerEvent { get; set; } = "";
        public string TargetURL { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> PayloadFields { get; set; } = new();
        public string Authentication { get; set; } = "";
    }

    public class IntegrationPatterns
    {
        public string PrimaryPattern { get; set; } = "API-First";
        public List<string> SupportedPatterns { get; set; } = new();
        public string MessageFormat { get; set; } = "JSON";
        public string ErrorHandlingStrategy { get; set; } = "Retry with Exponential Backoff";
        public string MonitoringApproach { get; set; } = "Centralized Logging";
    }

    // Security Model
    public class SecurityModel
    {
        public List<SecurityRole> SecurityRoles { get; set; } = new();
        public List<SecurityGroup> SecurityGroups { get; set; } = new();
        public List<SharingRule> SharingRules { get; set; } = new();
        public SecuritySettings Settings { get; set; } = new();
        public List<ConditionalAccessPolicy> ConditionalAccess { get; set; } = new();
    }

    public class SecurityRole
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Privileges { get; set; } = new();
        public List<string> Users { get; set; } = new();
        public List<string> Teams { get; set; } = new();
        public string BusinessUnit { get; set; } = "";
        public List<string> AppliesTo { get; set; } = new(); // Entities this role applies to
    }

    public class SecurityGroup
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Security"; // Security, Distribution, Office 365
        public string Description { get; set; } = "";
        public List<string> Members { get; set; } = new();
        public List<string> Permissions { get; set; } = new();
        public string Scope { get; set; } = "Global";
    }

    public class SharingRule
    {
        public string Name { get; set; } = "";
        public string Entity { get; set; } = "";
        public string Description { get; set; } = "";
        public string ShareWith { get; set; } = ""; // User, Team, Business Unit
        public string AccessLevel { get; set; } = "Read"; // Read, Write, Delete, Assign, Share
        public List<string> Conditions { get; set; } = new();
    }

    public class SecuritySettings
    {
        public bool MultiFactorAuthRequired { get; set; } = true;
        public bool AuditingEnabled { get; set; } = true;
        public int SessionTimeout { get; set; } = 480; // in minutes
        public bool IPAddressRestrictions { get; set; } = false;
        public List<string> AllowedIPRanges { get; set; } = new();
        public string PasswordPolicy { get; set; } = "Strong";
    }

    public class ConditionalAccessPolicy
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> AppliesTo { get; set; } = new(); // Users, Groups, Applications
        public List<string> Conditions { get; set; } = new();
        public List<string> Controls { get; set; } = new();
        public string State { get; set; } = "Enabled"; // Enabled, Disabled, Report-only
    }

    // Environment Strategy
    public class EnvironmentStrategy
    {
        public List<PowerPlatformEnvironment> Environments { get; set; } = new();
        public EnvironmentGovernance Governance { get; set; } = new();
        public List<EnvironmentConnection> Connections { get; set; } = new();
        public ALMStrategy ALM { get; set; } = new();
    }

    public class PowerPlatformEnvironment
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Development"; // Development, Test, Production, Sandbox
        public string Description { get; set; } = "";
        public string Region { get; set; } = "";
        public List<string> Applications { get; set; } = new();
        public List<string> Flows { get; set; } = new();
        public List<string> Users { get; set; } = new();
        public List<string> SecurityGroups { get; set; } = new();
        public string DataLossPreventionPolicy { get; set; } = "";
        public bool DataverseEnabled { get; set; } = true;
    }

    public class EnvironmentGovernance
    {
        public string Strategy { get; set; } = "Centralized";
        public List<string> Policies { get; set; } = new();
        public List<string> ComplianceRequirements { get; set; } = new();
        public string BackupStrategy { get; set; } = "";
        public string DisasterRecovery { get; set; } = "";
        public List<string> MonitoringTools { get; set; } = new();
    }

    public class EnvironmentConnection
    {
        public string Name { get; set; } = "";
        public string SourceEnvironment { get; set; } = "";
        public string TargetEnvironment { get; set; } = "";
        public string ConnectionType { get; set; } = "Data Gateway";
        public string Description { get; set; } = "";
        public List<string> DataSources { get; set; } = new();
    }

    public class ALMStrategy
    {
        public string Strategy { get; set; } = "DevOps";
        public List<string> SourceControl { get; set; } = new();
        public List<string> DeploymentPipelines { get; set; } = new();
        public List<string> TestingApproach { get; set; } = new();
        public string ReleaseManagement { get; set; } = "";
        public List<string> Tools { get; set; } = new();
    }

    // Implementation planning models for Dynamics/Power Platform
    public class ImplementationPlan
    {
        public List<ImplementationPhase> Phases { get; set; } = new();
        public GovernanceStructure Governance { get; set; } = new();
        public List<Risk> Risks { get; set; } = new();
        public List<string> Dependencies { get; set; } = new();
        public DeploymentStrategy Deployment { get; set; } = new();
        public ChangeManagement ChangeManagement { get; set; } = new();
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
        public List<string> D365Components { get; set; } = new();
        public List<string> PowerPlatformComponents { get; set; } = new();
        public List<string> DataMigrationTasks { get; set; } = new();
    }

    public class GovernanceStructure
    {
        public List<string> DecisionMaking { get; set; } = new();
        public List<string> ReviewCycles { get; set; } = new();
        public List<string> QualityGates { get; set; } = new();
        public List<string> ComplianceChecks { get; set; } = new();
        public string CenterOfExcellence { get; set; } = "";
    }

    public class Risk
    {
        public string Description { get; set; } = "";
        public string Impact { get; set; } = "Medium"; // High, Medium, Low
        public string Probability { get; set; } = "Medium";
        public string Mitigation { get; set; } = "";
        public string Category { get; set; } = "Technical"; // Technical, Business, Security, Compliance
    }

    public class DeploymentStrategy
    {
        public string Approach { get; set; } = "Phased"; // Big Bang, Phased, Pilot
        public List<string> Environments { get; set; } = new();
        public List<string> RollbackProcedures { get; set; } = new();
        public List<string> TestingStrategy { get; set; } = new();
        public string DataMigrationApproach { get; set; } = "";
    }

    public class ChangeManagement
    {
        public List<string> StakeholderGroups { get; set; } = new();
        public List<string> CommunicationPlan { get; set; } = new();
        public List<string> TrainingPrograms { get; set; } = new();
        public List<string> SupportStructure { get; set; } = new();
        public List<string> AdoptionMetrics { get; set; } = new();
    }

    // Business units for Dynamics/Power Platform context
    public class BusinessUnit
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Core"; // Core, Supporting
        public string Description { get; set; } = "";
        public List<string> KeyFunctions { get; set; } = new();
        public List<string> PrimaryUsers { get; set; } = new();
        public List<string> MainProcesses { get; set; } = new();
        public List<string> SystemInteractions { get; set; } = new();
        public List<string> D365Access { get; set; } = new();
        public List<string> PowerPlatformAccess { get; set; } = new();
    }
}