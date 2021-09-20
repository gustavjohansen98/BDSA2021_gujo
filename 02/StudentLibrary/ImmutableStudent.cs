using System;

namespace StudentLibrary
{
    public record ImmutableStudent
    {
        public int Id { get; init; }
        public string GivenName { get; init; }
        public string Surname { get; init; }
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
        }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
        public DateTime GraduationDate { get; init; }

        /* 
        * to check on compile time, if the compiler will flag an error 
        * stating that the 'Equals' member is already defined
        * public override bool Equals(object obj) => obj is ImmutableStudent immutableStudent && Equals(immutableStudent);
        */

    }
}