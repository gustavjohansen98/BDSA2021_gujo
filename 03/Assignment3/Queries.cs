using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace BDSA2020.Assignment03
{
    public class Queries
    {
        private readonly IReadOnlyCollection<Wizard> wizards = Wizard.Wizards.Value;
        public IEnumerable<string> GetWizardnamesByCreatorLINQ(string creator) 
        {
            var results = from w in wizards
                          where w.Creator.Contains(creator)
                          select w.Name;  
            return results;
        } 

        public IEnumerable<string> GetWizardnamesByCreatorExtension(string creator) 
        {
            return wizards.Where( w => w.Creator.Contains(creator)).Select( x => x.Name);
        } 

        public int? GetYearOfWizardFirstApperanceLINQ(string wizardName)
        {
            var result = from w in wizards
                         where w.Name.Contains(wizardName)
                         orderby w.Year
                         select w.Year;
            return result.FirstOrDefault();
        }

        public int? GetYearOfWizardFirstApperanceExtension(string wizardName)
        {
            return wizards.Where( w => w.Name.Contains(wizardName)).Select( w => w.Year).Min();
        }

        public IEnumerable<Tuple<string, int?>> GetNamesAndYearsFromMediaLINQ(string media)
        {
            var result = from w in wizards
                         where w.Medium.Equals(media)
                         select new Tuple<string, int?>(w.Name, w.Year);

            return result;
        }

        public IEnumerable<(string, int?)> GetNamesAndYearsFromMediaExtension(string media)
        {
            return wizards.Where( w => w.Medium.Equals(media)).Select(w => (w.Name, w.Year));
        }

        public IEnumerable<string> GetWizardNamesGroupedByCreatorLINQ()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetWizardNamesGroupedByCreatorExtension()
        {
            throw new NotImplementedException();
        }
    }
}
