using System.Collections.Generic;
using MakeMeUpzz.Models;
using MakeMeUpzz.Repositories;

namespace MakeMeUpzz.Handlers
{
    public class MakeupHandler
    {
        private readonly MakeupRepository _makeupRepository;

        public MakeupHandler()
        {
            _makeupRepository = new MakeupRepository();
        }

        public IEnumerable<Makeup> GetAllMakeups()
        {
            return _makeupRepository.GetAll();
        }

        public Makeup GetMakeupById(int id)
        {
            return _makeupRepository.GetById(id);
        }

        public void AddMakeup(Makeup makeup)
        {
            _makeupRepository.Add(makeup);
        }

        public void UpdateMakeup(Makeup makeup)
        {
            _makeupRepository.Update(makeup);
        }

        public void DeleteMakeup(int id)
        {
            _makeupRepository.Delete(id);
        }
    }
}