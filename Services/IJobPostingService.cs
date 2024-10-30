using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessObject.Models;

namespace Services
{
    public interface IJobPostingService
    {
        public List<JobPostings> GetJobPostings();

        public JobPostings GetJob(String id);

        public bool addJob(JobPostings job);

        public bool delJob(String postingID);

        public bool UpdateJob(JobPostings job);
    }
}
