using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidatedao;
using Microsoft.EntityFrameworkCore;

namespace candidate_dao
{
    public class JobPostingDAO
    {
        private CandidateManagementContext DbContext;
        private static JobPostingDAO instance;

        public static JobPostingDAO Instance
        {
            get{
                 if(instance==null){
                 instance = new JobPostingDAO();
               }
            return instance;
            }
        }
        public JobPostingDAO()
        {
            DbContext = new CandidateManagementContext();
        }

        public List<JobPostings> GetJobPostings()
        {
            return DbContext.JobPostings.ToList();
        }
        public JobPostings GetJobPostings(String postingID)
        {
            return DbContext.JobPostings.SingleOrDefault(m => m.PostingId.Equals(postingID));
        }
        public bool addJob(JobPostings job)
        {
            bool isSuccess = false;

            if (job == null)
            {
                DbContext.JobPostings.Add(job);
                DbContext.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public bool delJob(string postingID)
        {
            bool isSuccess = false;
            JobPostings JOB = GetJobPostings(postingID);
            try
            {
                if (JOB != null)
                {
                    DbContext.JobPostings.Remove(JOB);
                    DbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
        public bool updateJob(String jobId)
        {
            bool isSuccess = false;
            JobPostings JOB = this.GetJobPostings(jobId);
            try
            {
                if (JOB != null)
                {
                    DbContext.Entry<JobPostings>(JOB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    DbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
