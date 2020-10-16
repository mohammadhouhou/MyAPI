using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.dal.Entities;
using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UniversityContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

               
                if (context.Courses != null && context.Courses.Any())
                    return;   // DB has already been seeded

                
                var courses = GetCourses().ToArray();
                context.Courses.AddRange(courses);
                context.SaveChanges();

                var students = GetStudents().ToArray();
                context.Students.AddRange(students);
                context.SaveChanges();

                var teachers = GetTeachers().ToArray();
                context.Teachers.AddRange(teachers);
                context.SaveChanges();

                var institutions = GetInstitutions().ToArray();
                context.institutions.AddRange(institutions);
                context.SaveChanges();
            }
        }
        public static List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>()
            {
                new Course {Name="Math"},
                new Course {Name="Secure Coding"},
                new Course {Name="Projet Info"}
            };
            return courses;
        }
        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student {Firstname="Will", Lastname="Smith"},
                new Student {Firstname="George", Lastname="Ford"},
            };
            return students;
        }
        public static List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher {TeacherID=1, Name="Fred Mansour"},
                new Teacher {TeacherID=2, Name="Fadi Hanna"}

            };
            return teachers;
        }
        public static List<Institution> GetInstitutions()
        {
            List<Institution> institutions = new List<Institution>()
            {
                new Institution {id=1,name="ige" },
                new Institution {id=2, name="inci"}

            };
            return institutions;
        }
    }
}
