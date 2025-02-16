﻿using System;
using System.Collections.Generic;
using Fallout.Models;

/*---------------------------------------------
 *        Data Repository Interface
 * This is the generic interface which is extended
 * for each Enity Class such as Employeee. 
---------------------------------------------*/

namespace Fallout.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(Employee employee, TEntity entity);
        void Delete(Employee employee);
    }
}
