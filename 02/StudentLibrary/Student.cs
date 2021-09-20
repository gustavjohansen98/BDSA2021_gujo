using System;

namespace StudentLibrary
{
    public class Student
    {
        public int Id {}
        public string GivenName {}
        public string Surname {}
        public Status Status {}
        public DateTime StartDate {}
        public DateTime EndDate {}
        public DateTime GraduationDate {}

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
