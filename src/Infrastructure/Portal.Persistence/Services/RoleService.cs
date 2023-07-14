using Microsoft.AspNetCore.Identity;
using Portal.Application.Abstractions.Services;
using Portal.Domain.Entities.Users;

namespace Portal.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRole(string name)
        {
            IdentityResult result = await _roleManager.CreateAsync(new() { Name = name });

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string name)
        {

            IdentityResult result = await _roleManager.DeleteAsync(new() { Name = name });

            return result.Succeeded;
        }

        public async Task<bool> UpdateRole(string id ,string name)
        {

            IdentityResult result = await _roleManager.UpdateAsync(new() {Id= id ,Name = name });

            return result.Succeeded;
        }
    }
}
