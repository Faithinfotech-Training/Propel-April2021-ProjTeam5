using System;
using System.Collections.Generic;

namespace TrainingAcademy5._2Camp.Models
{
    public partial class Coursemain
    {
        public Coursemain()
        {
            Userpermission = new HashSet<Userpermission>();
        }

        public int Courseid { get; set; }
        public int? Orgid { get; set; }
        public string Coursename { get; set; }
        public int? Courseduration { get; set; }
        public string Qualification { get; set; }
        public string Timeslot { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Closingdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Backlog { get; set; }
        public double? Percentage { get; set; }
        public double? Experience { get; set; }
        public int? Maxnoofcandidate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool? Isactive { get; set; }
        public DateTime? Createddate { get; set; }

        public Organization Org { get; set; }
        public ICollection<Userpermission> Userpermission { get; set; }
    }
}
