﻿using Equinor.ProjectExecutionPortal.Application.Services.ContextTypeService;
using Equinor.ProjectExecutionPortal.Domain.Common.Exceptions;
using Equinor.ProjectExecutionPortal.Domain.Entities;
using Equinor.ProjectExecutionPortal.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Equinor.ProjectExecutionPortal.Application.Commands.OnboardedApps.UpdateOnboardedApp;

public class UpdateOnboardedAppCommand : IRequest<Guid>
{
    public UpdateOnboardedAppCommand(string appKey, IList<string> contextTypes)
    {
        AppKey = appKey;
        ContextTypes = contextTypes;
    }

    public string AppKey { get; }
    public IList<string> ContextTypes { get; set; }

    public class Handler : IRequestHandler<UpdateOnboardedAppCommand, Guid>
    {
        private readonly IReadWriteContext _readWriteContext;
        private readonly IContextTypeService _contextTypeService;

        public Handler(IReadWriteContext readWriteContext, IContextTypeService contextTypeService)
        {
            _readWriteContext = readWriteContext;
            _contextTypeService = contextTypeService;
        }

        public async Task<Guid> Handle(UpdateOnboardedAppCommand command, CancellationToken cancellationToken)
        {
            var entity = await _readWriteContext.Set<OnboardedApp>()
                .Include(x => x.ContextTypes)
                .FirstOrDefaultAsync(x => x.AppKey == command.AppKey, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException("App is not onboarded", command.AppKey);
            }

            entity.AddContextTypes(await _contextTypeService.GetAllowedContextTypesByKeys(command.ContextTypes, cancellationToken));

            await _readWriteContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
