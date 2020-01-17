
using System.Collections.Generic;


namespace ClinicaExemplo.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Remove(TEntity obj);

        void Update(TEntity obj);

        void Dispose();
    }
}
