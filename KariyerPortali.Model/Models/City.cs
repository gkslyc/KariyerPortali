﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KariyerPortali.Model
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

       
        public int CountryId { get; set; }
        public Country Country { get;set;}
        public ICollection<Employer> Employers { get; set; }
        public ICollection<Resume> Resumes { get; set; }

    }
}