using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using repos;

namespace Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private ICandidateProfileRepos profileRepos;

        public CandidateProfileService()
        {
            profileRepos = new CandidatProfileRepo();
        }
       
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepos.AddCandidate(candidateProfile);
        }

        public bool delCandidateProfile(String CandidateID)
        {
            return profileRepos.DelCandidate(CandidateID);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return profileRepos.GetCandidateProfileById(id);
        }

        public List<CandidateProfile> GetCandidates()
        {
            return profileRepos.GetCandidatesProfiles();
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepos.AddCandidate(candidateProfile);
        }
    }
}
