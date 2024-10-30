using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace repos
{
    public interface IJobPostingRepo
    {
        public bool addJob(JobPostings job);
        public bool delJob(string postingID);
        public List<JobPostings> GetJobPostings();
        JobPostings GetJobPostingsByID(string id);
        public bool updateJob(string postingID);
        public bool updateJob(JobPostings job);
    }
}
