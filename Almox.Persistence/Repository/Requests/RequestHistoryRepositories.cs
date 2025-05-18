using Almox.Application.Repository.RequestsRepository;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Deliveries;

public class RequestHistoryRepository(
    AlmoxContext almoxContext
) : BaseRepository<RequestHistory>(almoxContext), IRequestHistoryRepository {}
