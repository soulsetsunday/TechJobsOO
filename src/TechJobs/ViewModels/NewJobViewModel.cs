﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        //this is for refrence, the default message is actually fine
        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct valudation attributes and display names.
        // SelectListItem is a .net thing for <option> lists
        // No new job things can be added here, hence everything being selected from a list

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        [Required]
        [Display(Name = "Skill")]
        public int CoreCompetencyID { get; set; }
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        [Required]
        [Display(Name = "Position Type")]
        public int PositionTypeID { get; set; }
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

            foreach (Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

        }
    }
}
