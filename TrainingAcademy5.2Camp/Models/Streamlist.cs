using System;
using System.Collections.Generic;

namespace TrainingAcademy5._2Camp.Models
{
    public partial class Streamlist
    {
        public int Streamid { get; set; }
        public int? Courseid { get; set; }
        public int? Degreeid { get; set; }
        public string Stream { get; set; }
    }
}
