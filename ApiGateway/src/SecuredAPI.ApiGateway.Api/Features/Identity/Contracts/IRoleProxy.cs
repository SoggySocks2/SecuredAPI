using SecuredAPI.ApiGateway.Api.Features.Identity.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Contracts
{
    public interface IRoleProxy
    {
        Task<RoleModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<RoleModel> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<List<RoleInfoModel>> GetAsync(CancellationToken cancellationToken);
        Task<List<RoleModel>> GetWithPermissionsAsync(CancellationToken cancellationToken);
        Task<RoleModel> AddAsync(CreateRoleModel createRoleModel, CancellationToken cancellationToken);
        Task<RoleModel> UpdateAsync(UpdateRoleModel updateRoleModel, CancellationToken cancellationToken);
        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
