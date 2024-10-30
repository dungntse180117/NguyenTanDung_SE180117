using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;
using repos;

namespace Services
{
    public class JobPostingService : IJobPostingService
    {
        private IJobPostingRepo jobPostingRepo;

        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }

        public bool addJob(JobPostings job)
        {
            return jobPostingRepo.addJob(job);
        }

        public bool delJob(string postingID)
        {
            return jobPostingRepo.delJob(postingID);
        }

        public JobPostings GetJob(string id)
        {
            return jobPostingRepo.GetJobPostingsByID(id);
        }

        public List<JobPostings> GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }


        public bool UpdateJob(JobPostings job)
        {
            return jobPostingRepo.updateJob(job);
        }
    }
}
