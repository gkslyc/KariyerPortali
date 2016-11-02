﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Model
{
   public class JobApplication
    {
        public int ApplicationId { get; set; }

        [ForeignKey("Candidate")]
        public Candidate CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        [ForeignKey("Employer")]
        public Employer EmployerId { get; set; }
        public Employer Employer { get; set; }

        [ForeignKey("Job")]
        public Job JobId { get; set; }
        public Job Job { get; set; }

        public string CoverLetter { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        
    }
}