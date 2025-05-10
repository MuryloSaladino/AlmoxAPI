using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Requests;

public class RequestsRepository(
    AlmoxContext almoxContext
) : BaseRepository<Request>(almoxContext), IRequestsRepository {}
