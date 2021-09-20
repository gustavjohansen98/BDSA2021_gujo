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
                if ((EndDate != null && EndDate != DateTime.MinValue) && now >= EndDate)
                    return Status.Dropout;
                if (now > GraduationDate)
                    return Status.Graduated;
                if (now > StartDate && now < GraduationDate)
                    return Status.Active;
                return Status.New;
            }
            // maaah, this didn't quite work out :((
            // get 
            // {
            //     DateTime now = DateTime.Now;
            //     return now switch
            //     {
            //         (now > StartDate) and (now < GraduationDate)                              => Status.Active,
            //         (EndDate != null and EndDate != DateTime.MinValue) and (now >= EndDate)   => Status.Dropout,
            //         now > GraduationDate                                                      => Status.Graduated,                                                    
            //         now < StartDate                                                           => Status.New,
            //         _                                                                         => throw new InvalidProgramException("this will not work"),
            //     }; 
            // }
        }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime GraduationDate { get; set; }

        public override string ToString()
        {
            return $"{this.GivenName} {this.Surname} with id {this.Id}, has status {this.Status}";
        }
    }

    public enum Status { New, Active, Dropout, Graduated }
}
