using System;
using System.Collections.Generic;
using System.Text;

namespace Civir.Infrastructure.Persistence;

public interface IUnitOfWork: IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class;

    Task<int> Complete();
}