using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace Services
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidates();

        public CandidateProfile GetCandidateProfile(String id);

        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool delCandidateProfile(String CandidateId);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
      
    }
}
