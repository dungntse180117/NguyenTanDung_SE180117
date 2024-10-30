using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidate_dao;
using candidatedao;
namespace repos
{
    public class CandidatProfileRepo : ICandidateProfileRepos
    {
        public bool AddCandidate(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.addCandidate(candidateProfile);
       

        public bool DelCandidate(string profileID)=>CandidateProfileDAO.Instance.delCandidate(profileID);
        

        public CandidateProfile GetCandidateProfileById(string id)=>CandidateProfileDAO.Instance.GetCandidatesProfileById(id);   
       
        public List<CandidateProfile> GetCandidatesProfiles()=>CandidateProfileDAO.Instance.GetCandidatesProfiles() ;

        public bool updateCandidate(String profileID) => CandidateProfileDAO.Instance.updateCandidate(profileID);
        
    }
}
