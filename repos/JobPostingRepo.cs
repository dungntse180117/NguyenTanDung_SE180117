using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using candidate_dao;

namespace repos
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool addJob(JobPostings job) => JobPostingDAO.Instance.addJob(job);
       

        public bool delJob(string postingID)
        {
            throw new NotImplementedException();
        }

        public List<JobPostings> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();

        public JobPostings GetJobPostingsByID(string id)
        {
            throw new NotImplementedException();
        }

        public bool updateJob(string postingID)
        {
            throw new NotImplementedException();
        }

        public bool updateJob(JobPostings job)
        {
            throw new NotImplementedException();
        }
    }
}
