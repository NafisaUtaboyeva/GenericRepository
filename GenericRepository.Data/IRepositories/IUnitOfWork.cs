﻿using GenericRepository.Api.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task SaveChangesAsync();
    }
}
