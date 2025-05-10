using Almox.Application.Repository.ActionLogsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.ActionLogs;

public class ActionLogsRepository(
    AlmoxContext almoxContext
) : BaseRepository<ActionLog>(almoxContext), IActionLogsRepository {}
