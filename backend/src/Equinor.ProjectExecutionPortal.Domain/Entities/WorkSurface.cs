﻿using Equinor.ProjectExecutionPortal.Domain.Common;
using Equinor.ProjectExecutionPortal.Domain.Common.Audit;

namespace Equinor.ProjectExecutionPortal.Domain.Entities;

/// <summary>
/// The Work Surface functions as a container for all apps and related information about a specific phase
/// </summary>
public class WorkSurface : AuditableEntityBase, ICreationAuditable, IModificationAuditable
{
    public const int KeyLengthMax = 200;
    public const int NameLengthMax = 200;
    public const int ShortNameLengthMax = 50;
    public const int SubTextLengthMax = 200;
    public const int DescriptionLengthMax = 4000;

    private readonly List<WorkSurfaceApp> _apps = new();

    public WorkSurface(string key, string name, string shortName, string subText, string? description, int order, string icon)
    {
        Key = key;
        Name = name;
        ShortName = shortName;
        SubText = subText;
        Description = description;
        Order = order;
        Icon = icon;
    }

    public string Key { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string SubText { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }

    public Guid PortalId { get; set; }
    public Portal Portal { get; set; }

    public IReadOnlyCollection<WorkSurfaceApp> Apps => _apps.AsReadOnly();

    public void Update(string key, string name, string shortName, string subText, string? description, int order, string icon)
    {
        Key = key;
        Name = name;
        ShortName = shortName;
        SubText = subText;
        Description = description;
        Order = order;
        Icon = icon;
    }

    public void SetAsDefault()
    {
        IsDefault = true;
    }

    public void UnsetAsDefault()
    {
        IsDefault = false;
    }

    public void AddApp(WorkSurfaceApp app)
    {
        _apps.Add(app);
    }

    public List<WorkSurfaceApp> GlobalApps()
    {
        return _apps.Where(workSurfaceApp => workSurfaceApp.IsGlobal).ToList();
    }

    public List<WorkSurfaceApp> ContextualApps(Guid? onboardedContextId = null)
    {
        if (onboardedContextId == null)
        {
            return _apps.Where(workSurfaceApp => workSurfaceApp.IsContextual).ToList();
        }

        return _apps.Where(workSurfaceApp => workSurfaceApp.IsContextual && workSurfaceApp.OnboardedContextId == onboardedContextId).ToList();
    }

    public bool HasApp(Guid onboardedAppId)
    {
        return _apps.Any(workSurfaceApp => workSurfaceApp.OnboardedAppId == onboardedAppId);
    }

    public bool HasGlobalApp(Guid onboardedAppId)
    {
        return HasApp(onboardedAppId) &&
               GlobalApps().Any(x => x.OnboardedAppId == onboardedAppId);
    }

    public bool HasAppForContext(Guid onboardedAppId, Guid onboardedContextId)
    {
        return HasApp(onboardedAppId) &&
               ContextualApps(onboardedContextId).Any(x => x.OnboardedAppId == onboardedAppId);
    }

    public bool HasAppForAnyContexts(Guid onboardedAppId)
    {
        return HasApp(onboardedAppId) &&
               _apps.Any(workSurfaceApp => workSurfaceApp.IsContextual);
    }
}
