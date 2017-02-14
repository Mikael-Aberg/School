using System.Collections.Generic;

namespace School.Models
{
    public class CourseModel
    {
        public CourseModel()
        {
            this.Students = new List<StudentModel>();
        }

        public int Id { get; set; }
        public virtual SubjectModel Subject { get; set; }
        public virtual ICollection<StudentModel> Students { get; set; }
    }
}