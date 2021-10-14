﻿using SecuredAPI.Identity.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SecuredAPI.Identity.Data.Contracts
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Role> GetByNameAsync(string name, CancellationToken cancellationToken);
        Task<Role> GetByIdWithUsersAsync(Guid id, CancellationToken cancellationToken);
        Task<Role> GetByNameWithUsersAsync(string name, CancellationToken cancellationToken);
        Task<List<Role>> GetListAsync(CancellationToken cancellationToken);
        Task<List<Role>> GetListByIdAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken);
        Task<List<Role>> GetListWithPermissionsAsync(CancellationToken cancellationToken);
        Task<Role> AddAsync(Role role, CancellationToken cancellationToken);
        Task<Role> UpdateAsync(Role role, CancellationToken cancellationToken);
        Task DeleteAsync(Role role, CancellationToken cancellationToken);
    }
}
