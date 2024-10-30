using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace repos
{
    public interface ICandidateProfileRepos
    {
        public List<CandidateProfile> GetCandidatesProfiles();

        public CandidateProfile GetCandidateProfileById(String id);

        public bool AddCandidate(CandidateProfile candidateProfile);

        public bool DelCandidate(String profileID);

        public bool updateCandidate(String profileID);

    }
}
