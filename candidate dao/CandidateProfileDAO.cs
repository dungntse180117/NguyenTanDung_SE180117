using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidatedao;

namespace candidate_dao
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
       
        public CandidateProfile GetCandidatesProfileById(String id)
        {
            return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }   

        public List<CandidateProfile> GetCandidatesProfiles()
        {
            return dbContext.CandidateProfiles.ToList();
        }

        public CandidateProfile GetCandidateProfile(String id)
        {
            return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));

        }

        public bool addCandidate(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            
                if(candidateProfile == null)
            {
                dbContext.CandidateProfiles.Add(candidateProfile);
                dbContext.SaveChanges();    
                isSuccess = true;   
            }
            return isSuccess;
        }
        public bool delCandidate(String candidatedId)
        {
            bool isSuccess = false;
            CandidateProfile candidate = GetCandidateProfile(candidatedId);
            try
            {
                if (candidate != null)
                {
                    dbContext.CandidateProfiles.Remove(candidate);
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool updateCandidate(String profileID)
        {
            bool isSuccess = false;
            CandidateProfile candidate = this.GetCandidatesProfileById(profileID);
            try
            {
                if (candidate != null)
                {
                    dbContext.Entry<CandidateProfile>(candidate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
