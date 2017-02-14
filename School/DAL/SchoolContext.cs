using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace School.DAL
{
    public class SchoolContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SchoolContext() : base("name=SchoolContext")
        {
        }

        public System.Data.Entity.DbSet<School.Models.LessonModel> Lessons { get; set; }
        public System.Data.Entity.DbSet<School.Models.DaysModel> Days { get; set; }
        public System.Data.Entity.DbSet<School.Models.SubjectModel> Subjects { get; set; }
        public System.Data.Entity.DbSet<School.Models.TeacherModel> Teachers { get; set; }
        public System.Data.Entity.DbSet<School.Models.StudentModel> Students { get; set; }
        public System.Data.Entity.DbSet<School.Models.CourseModel> Courses { get; set; }
    }
}
