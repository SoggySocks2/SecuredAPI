﻿using System;
using System.Collections.Generic;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Models
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsStaff { get; set; }
        public string LanguageCode { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
