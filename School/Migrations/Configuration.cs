namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.SchoolContext context)
        {

            context.Days.AddOrUpdate(
                new Models.DaysModel { Id = 1, Day = "Monday" },
                new Models.DaysModel { Id = 1, Day = "Tuesday" },
                new Models.DaysModel { Id = 1, Day = "Wednesday" },
                new Models.DaysModel { Id = 1, Day = "Thursday" },
                new Models.DaysModel { Id = 1, Day = "Friday" }
                );
            context.SaveChanges();

            context.Students.AddOrUpdate(
                new Models.StudentModel { Id = 1, FirstName = "Roosevelt", LastName = "Hibbert" },
                new Models.StudentModel { Id = 2, FirstName = "Alethea", LastName = "Hull" },
                new Models.StudentModel { Id = 3, FirstName = "Rosaline", LastName = "Johns" },
                new Models.StudentModel { Id = 4, FirstName = "Faith", LastName = "Appleby" },
                new Models.StudentModel { Id = 5, FirstName = "Loraine", LastName = "Darby" },
                new Models.StudentModel { Id = 6, FirstName = "Matilda", LastName = "Ryers" },
                new Models.StudentModel { Id = 7, FirstName = "Terrance", LastName = "Simon" },
                new Models.StudentModel { Id = 8, FirstName = "Deanne", LastName = "Sands" },
                new Models.StudentModel { Id = 9, FirstName = "Katherine", LastName = "Miller" },
                new Models.StudentModel { Id = 10, FirstName = "Florence", LastName = "Cheshire" }
                );
            context.SaveChanges();

            context.Teachers.AddOrUpdate(
                new Models.TeacherModel { Id = 1, FirstName = "Merlin", LastName = "Simons" },
                new Models.TeacherModel { Id = 2, FirstName = "Montgomery", LastName = "Dickinson" },
                new Models.TeacherModel { Id = 3, FirstName = "Branden", LastName = "Pond" },
                new Models.TeacherModel { Id = 4, FirstName = "Darell", LastName = "Waterman" },
                new Models.TeacherModel { Id = 5, FirstName = "Brandie", LastName = "Olhouser" },
                new Models.TeacherModel { Id = 6, FirstName = "Archer", LastName = "Lacey" }
                );
            context.SaveChanges();

            Random r = new Random();
            context.Subjects.AddOrUpdate(
                new Models.SubjectModel { Id = 1, SubjectName = "Math" },
                new Models.SubjectModel { Id = 2, SubjectName = "PE" },
                new Models.SubjectModel { Id = 3, SubjectName = "English" },
                new Models.SubjectModel { Id = 4, SubjectName = "Geography" },
                new Models.SubjectModel { Id = 5, SubjectName = "History" },
                new Models.SubjectModel { Id = 6, SubjectName = "Music" },
                new Models.SubjectModel { Id = 7, SubjectName = "Science" },
                new Models.SubjectModel { Id = 8, SubjectName = "Biology" },
                new Models.SubjectModel { Id = 9, SubjectName = "Chemistry" },
                new Models.SubjectModel { Id = 10, SubjectName = "Woodwork" }
                );
            context.SaveChanges();

            foreach (var item in context.Subjects)
            {
                var id = r.Next(1, 6);
                item.Teacher = context.Teachers.Find(id);
            }

            context.SaveChanges();

            context.Courses.AddOrUpdate(
                new Models.CourseModel { Id = 1, },
                new Models.CourseModel { Id = 2, },
                new Models.CourseModel { Id = 3, },
                new Models.CourseModel { Id = 4, },
                new Models.CourseModel { Id = 5, },
                new Models.CourseModel { Id = 6, },
                new Models.CourseModel { Id = 7, },
                new Models.CourseModel { Id = 8, },
                new Models.CourseModel { Id = 9, },
                new Models.CourseModel { Id = 10, }
                );

            var counter = 1;
            foreach (var item in context.Courses)
            {
                item.Subject = context.Subjects.Find(counter);
                counter++;
            }
            context.SaveChanges();

            foreach (var item in context.Courses)
            {
                item.Students.Clear();
                for (int i = 0; i < r.Next(1, 10); i++)
                {
                    var id = r.Next(1, 10);
                    item.Students.Add(context.Students.Find(id));
                }
            }
            context.SaveChanges();

            context.Lessons.AddOrUpdate(
                new Models.LessonModel { Id = 1, StartTime = "9:00", EndTime = "10:00" },
                new Models.LessonModel { Id = 2, StartTime = "10:00", EndTime = "12:00" },
                new Models.LessonModel { Id = 3, StartTime = "12:00", EndTime = "13:00" },
                new Models.LessonModel { Id = 4, StartTime = "9:00", EndTime = "12:00" },
                new Models.LessonModel { Id = 5, StartTime = "13:00", EndTime = "15:00" },
                new Models.LessonModel { Id = 6, StartTime = "13:30", EndTime = "16:30" },
                new Models.LessonModel { Id = 7, StartTime = "8:00", EndTime = "10:00" },
                new Models.LessonModel { Id = 8, StartTime = "8:30", EndTime = "11:00" },
                new Models.LessonModel { Id = 9, StartTime = "10:00", EndTime = "12:00" },
                new Models.LessonModel { Id = 10, StartTime = "9:00", EndTime = "10:00" }
                );
            context.SaveChanges();

            foreach (var item in context.Lessons)
            {
                item.Course = context.Courses.Find(r.Next(1, 10));
                item.Day = context.Days.Find(r.Next(1, 5));
            }
            context.SaveChanges();

            String[] grades = { "A", "B", "C", "D", "F" };

            foreach (var student in context.Students)
            {
                student.Grades.Clear();
                foreach (var item in student.Courses)
                {
                    student.Grades.Add(new Models.GradeModel { Course = item, Grade = grades[r.Next(0, grades.Length)] });
                }
            }
        }
    }
}