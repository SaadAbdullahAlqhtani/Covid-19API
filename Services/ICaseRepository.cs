using covid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid.Services
{
    public interface ICaseRepository
    {
        ICollection<Case> GetCases();
        Case GetCase(int caseId);


        ICollection<Case> GetCuredCases();
        ICollection<Case> GetInfectedCases();
        ICollection<Case> GetDeceasedCases();
        
      
        bool CaseExists(int CaseId);

        bool CreateCase(Case caseId);
        bool UpdateCase(Case caseId);
        bool DeleteCase(Case caseId);
        bool Save();
    }
}
