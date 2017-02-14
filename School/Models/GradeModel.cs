using System;

namespace School.Models
{
    public class GradeModel
    {
        public int Id { get; set; }
        public CourseModel Course { get; set; }
        public String Grade { get; set; }
    }
}