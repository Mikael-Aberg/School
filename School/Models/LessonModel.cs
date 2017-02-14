using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public CourseModel Course { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DaysModel Day { get; set; }
    }
}