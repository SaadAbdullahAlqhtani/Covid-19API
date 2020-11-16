using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using covid.Models;
using covid.Services;

namespace covid.Services
{
    public class CaseRepository : ICaseRepository
    {
        private CaseDBContext _caseContext;

        public CaseRepository(CaseDBContext caseContext)
        {
            _caseContext = caseContext;
        }



        public ICollection<Case> GetCases()
        {
            return _caseContext.Cases.OrderBy(a => a.Id).ToList();
        }
        public Case GetCase(int caseId)
        {
            return _caseContext.Cases.Where(a => a.Id == caseId).FirstOrDefault();
        }




        public ICollection<Case> GetCuredCases()
        {
            return _caseContext.Cases.Where(a => a.Type == "Cured").OrderBy(a => a.LastName).ToList();
        }
        public ICollection<Case> GetInfectedCases()
        {
            return _caseContext.Cases.Where(a => a.Type == "Infected").OrderBy(a => a.LastName).ToList();
        }
        public ICollection<Case> GetDeceasedCases()
        {
            throw new NotImplementedException();
        }



        public bool CaseExists(int caseId)
        {
            return _caseContext.Cases.Any(a => a.Id == caseId);
        }



        public bool CreateCase(Case data)
        {
            _caseContext.Add(data);
            return Save();
        }
        public bool UpdateCase(Case data)
        {
            _caseContext.Update(data);
            return Save();
        }
        public bool DeleteCase(Case data)
        {
            _caseContext.Remove(data);
            return Save();
        }

        public bool Save()
        {
            var saved = _caseContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        
    }
}
