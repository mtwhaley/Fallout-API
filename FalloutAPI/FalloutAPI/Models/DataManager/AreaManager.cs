
using System.Linq;
using System.Collections.Generic;
using FalloutAPI.Repository;

/*---------------------------------------------------
                Employee Repository
 This is where the Data Repository Interface class
 is implemented for the Employee Entitys. This is where
 The Crud operations are actually defined. They rely on 
 the Entity Framework objects defined in the model.
--------------------------------------------------*/

namespace FalloutAPI.Models.DataManager
{
    public class AreaManager : IDataRepository<Area>
    {
        readonly AreaContext _areaContext;

        public AreaManager(AreaContext context)
        {
            _areaContext = context;
        }

        public void Add(Area entity)
        {
            _areaContext.Areas.Add(entity);
            _areaContext.SaveChanges();
        }

        public void Delete(Area area)
        {
            _areaContext.Areas.Remove(area);
            _areaContext.SaveChanges();
        }

        public Area Get(long id) {
           return null;
        }

        public Area GetByName(string name) {
            return _areaContext.Areas
                .FirstOrDefault(a => a.Name == name);;
        }

        public IEnumerable<Area> GetAll()
        {
            return _areaContext.Areas.ToList();
        }

        public void Update(Area area, Area entity)
        {
            area.Name = entity.Name;

            _areaContext.SaveChanges();
        }
    }
}
