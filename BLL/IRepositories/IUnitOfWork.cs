﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveAsync();
    }
}
