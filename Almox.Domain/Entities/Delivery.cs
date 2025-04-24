using Almox.Domain.Common;
using Almox.Domain.Enums;

namespace Almox.Domain.Entities;

public class Delivery : BaseEntity
{
    public required User User { get; set; }
    public required DateTime Date { get; set; }
    public required string Observations { get; set; }
    public required Status Status { get; set; }
}
