using System;

namespace StudentLibrary
{
    public class Student
    {
        public int Id { get; init; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public Status Status 
        {
            get 
            {
                var now = DateTime.Now;
                if (now >= EndDate)
                    return Status.Dropout;
                if (now > GraduationDate)
                    return Status.Graduated;
                if (now > StartDate && now < GraduationDate)
                    return Status.Active;
                return Status.New;
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime GraduationDate { get; set; }

        public override string ToString()
        {
            return $"{this.GivenName} {this.Surname} with id [{this.Id}], has status {this.Status}";
        }
    }

    public enum Status { New, Active, Dropout, Graduated }
}
