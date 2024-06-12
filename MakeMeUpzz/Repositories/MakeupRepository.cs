using MakeMeUpzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeMeUpzz.Repositories
{
    public class MakeupRepository
    {
        private readonly List<Makeup> _makeups;

        public MakeupRepository()
        {
            _makeups = new List<Makeup>();
        }

        public void Add(Makeup makeup)
        {
            _makeups.Add(makeup);
        }

        public Makeup GetById(int id)
        {
            return _makeups.FirstOrDefault(m => m.MakeupID == id);
        }

        public IEnumerable<Makeup> GetAll()
        {
            return _makeups;
        }

        public void Update(Makeup makeup)
        {
            var existingMakeup = GetById(makeup.MakeupID);
            if (existingMakeup != null)
            {
                existingMakeup.MakeupName = makeup.MakeupName;
                existingMakeup.MakeupPrice = makeup.MakeupPrice;
                existingMakeup.MakeupWeight = makeup.MakeupWeight;
                existingMakeup.MakeupTypeID = makeup.MakeupTypeID;
                existingMakeup.MakeupBrandID = makeup.MakeupBrandID;
            }
        }

        public void Delete(int id)
        {
            var makeup = GetById(id);
            if (makeup != null)
            {
                _makeups.Remove(makeup);
            }
        }
    }
}
