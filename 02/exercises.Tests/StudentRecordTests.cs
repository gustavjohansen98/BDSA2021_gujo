using System;
using Xunit;
using StudentLibrary;
using Moq;

namespace exercises.Tests
{
    public class StudentRecordTests
    {
        private static DateTime jan_1st = new DateTime(2021, 1, 1);
        private static DateTime aug_1st = new DateTime(2021, 8, 1);
        private static DateTime dec_1st = new DateTime(2021, 12, 1);

        private static ImmutableStudent testRecord = new ImmutableStudent
            {
                Id = 0,
                GivenName = "John",
                Surname = "Doe",
                StartDate = jan_1st,
                EndDate = null,
                GraduationDate = dec_1st
            };

        [Fact]
        public void Check_the_ToString_override_generated_by_record()
        {
            System.Console.WriteLine(testRecord.ToString());
        }

        [Fact]
        public void Given_testRecord_status_is_Active()
        {
            Assert.Equal(Status.Active, testRecord.Status);
        }

        [Fact]
        public void Assert_the_Equals_override_evaluates_to_true()
        {
            var duplicate = testRecord;
            Assert.True(testRecord.Equals(duplicate));
        }

        [Fact]
        public void Assert_the_Equals_override_evaluates_to_false()
        {
            var duplicate = testRecord with { Id = 1, EndDate = aug_1st };
            Assert.False(testRecord.Equals(duplicate));
            Assert.Equal(Status.Dropout, duplicate.Status);
        }
    }
}