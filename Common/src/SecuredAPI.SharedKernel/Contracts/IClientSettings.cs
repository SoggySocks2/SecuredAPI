﻿namespace SecuredAPI.SharedKernel.Contracts
{
    public interface IClientSettings
    {
        string Name { get; set; }
        string ConnectionString { get; set; }
    }
}
