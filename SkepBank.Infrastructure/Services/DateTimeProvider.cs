using SkepBank.Application.Common.Interfaces.Services;

namespace SkepBank.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
