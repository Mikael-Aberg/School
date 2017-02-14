using System.Collections.Generic;
using System.ComponentModel;

namespace School.Models
{
    public class StudentModel
    {
        public StudentModel()
        {
            Courses = new List<CourseModel>();
            Grades = new List<GradeModel>();
        }

        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        public virtual ICollection<GradeModel> Grades { get; set; }
        public virtual ICollection<CourseModel> Courses { get; set; }
    }
}