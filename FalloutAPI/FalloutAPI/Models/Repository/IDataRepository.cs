using System;
using System.Collections.Generic;
using FalloutAPI.Models;

/*---------------------------------------------
 *        Data Repository Interface
 * This is the generic interface which is extended
 * for each Enity Class such as Employeee. 
---------------------------------------------*/

namespace FalloutAPI.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity GetByName(string name);
        void Add(TEntity entity);
        void Update(TEntity repoEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
