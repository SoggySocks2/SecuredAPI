﻿using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace SecuredAPI.ApiGateway.Api.Features.Customers.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Get a customer
        /// </summary>
        /// <param name="id">Unique identifier</param>
        /// <param name="cancellationToken"></param>
        [HttpGet("{id}")]
        //[Authorize(Policy = nameof(PermissionKey.CustomerRead))]
        public IActionResult GetAsync(string id, CancellationToken cancellationToken = default)
        {
            if (id == string.Empty)
            {
                return BadRequest();
            }

            return Ok($"You requested customer id {id}");
        }
    }
}
