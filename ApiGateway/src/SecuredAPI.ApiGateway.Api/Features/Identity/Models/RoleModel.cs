﻿using System;
using System.Collections.Generic;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PermissionModel> Permissions { get; set; }
    }
}
