using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        public virtual TeacherModel Teacher { get; set; }
    }
}