using ProjectK3.Entities;

namespace ProjectK3.Repositories.IServices;

public interface IDashboard
{
    Task<List<Statistical>> GetStatisticals();
}
