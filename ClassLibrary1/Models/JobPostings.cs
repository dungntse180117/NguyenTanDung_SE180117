using System;
using System.Collections.Generic;

#nullable disable

namespace businessObject.Models
{
    public partial class JobPostings
    {
        public JobPostings()
        {
           CandidateProfiles = new HashSet<CandidateProfile>();
        }

        public string PostingId { get; set; }
        public string JobPostingTitle { get; set; }
        public string Description { get; set; }
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}
