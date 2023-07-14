namespace Portal.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string name);
    }
}
