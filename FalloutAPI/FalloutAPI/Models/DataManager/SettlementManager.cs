
using System.Linq;
using System.Collections.Generic;
using Fallout.Repository;
namespace Fallout.Models.DataManager
{
    public class SettlementManager : IDataRepository<Settlement>
    {
        readonly SettlementContext _settlementContext;

        public SettlementManager(SettlementContext context)
        {
            _settlementContext = context;
        }

        public void Add(Settlement entity)
        {
            _settlementContext.Settlements.Add(entity);
            _settlementContext.SaveChanges();
        }

        public void Delete(Settlement settlement)
        {
            _settlementContext.Settlements.Remove(settlement);
            _settlementContext.SaveChanges();
        }

        public Settlement Get(long id) {
           return _settlementContext.Settlements
                .FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Settlement> GetAll()
        {
            return _settlementContext.Settlements.ToList();
        }

        public void Update(Settlement settlement, Settlement entity)
        {
            settlement.ID = entity.ID;
            settlement.Name = entity.Name;
            settlement.NumSettlers = entity.NumSettlers;
            settlement.Walls = entity.Walls;
            settlement.Area = entity.Area;
            settlement.Weaponized = entity.Weaponized;
            settlement.Armored = entity.Armored;
            settlement.Defenses = entity.Defenses;
            settlement.Full = entity.Full;

            _settlementContext.SaveChanges();
        }
    }
}
