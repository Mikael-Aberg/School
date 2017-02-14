using System.Collections.Generic;
using System.ComponentModel;

namespace School.Models
{
    public class TeacherModel
    {
        public TeacherModel()
        {
            Subjects = new List<SubjectModel>();
        }

        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<SubjectModel> Subjects { get; set; }
    }
}