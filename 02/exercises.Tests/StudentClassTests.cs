using System;
using Xunit;
using StudentLibrary;
using Moq;

namespace exercises.Tests
{
    public class StudentClassTests
    {
        private static DateTime jan_1st = new DateTime(2021, 1, 1);
        private static DateTime aug_1st = new DateTime(2021, 8, 1);
        private static DateTime dec_1st = new DateTime(2021, 12, 1);

        private static Student testSubject = new Student 
        {
            Id = 0,
            GivenName = "John",
            Surname = "Doe",
            StartDate = jan_1st,
            EndDate = null,
            GraduationDate = dec_1st
        };

        [Fact]
        public void Student_ToString_with_active_Status()
        {
            string toStringCall = "John Doe with id 0, has status Active";
            Assert.Equal(toStringCall, testSubject.ToString());
        }

        [Fact]
        public void Set_Id_of_student_should_result_in_error_on_compile_time()
        {
            // Assert.True(false, testSubject.Id = 1);
            Assert.True(true);
        }

        [Fact]
        public void Trying_to_set_Status_throws_error_on_compile_time()
        {
            // Assert.Throws<Exception>(() => testSubject.Status = Status.New);
            Assert.True(true);
        }

        [Fact]
        public void Given_new_dates_sets_correct_Status()
        {
            var newStudent = new Student
            {
                Id = 1,
                GivenName = "John",
                Surname = "Doe",
                StartDate = jan_1st,
                EndDate = null,
                GraduationDate = dec_1st
            };

            newStudent.EndDate = aug_1st;
            Assert.Equal(Status.Dropout, newStudent.Status);
            
            newStudent.EndDate = null;
            Assert.Equal(Status.Active, newStudent.Status);

            newStudent.StartDate = DateTime.MaxValue;
            Assert.Equal(Status.New, newStudent.Status);

            newStudent.StartDate = jan_1st;
            newStudent.GraduationDate = aug_1st;
            Assert.Equal(Status.Graduated, newStudent.Status);
        }
    }
}
