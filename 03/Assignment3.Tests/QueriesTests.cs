using System;
using Xunit;
using BDSA2020.Assignment03;

namespace BDSA2020.Assignment03.Tests
{
    public class QueriesTests
    {
        private Queries q = new Queries();

        [Theory]
        [InlineData("Rowling", "Albus Dumbledore, Harry Potter, Lord Voldemort, Severus Snape, Draco Malfoy, Sirius Black, Ron Wesley")]
        [InlineData("Tolkien", "Sauron, Gandalf")]
        [InlineData("George Lucas", "Darth Vader, Luke Skywalker, Master Yoda")]
        public void Given_creator_return_wizard_names_by_creator(string creator, string names)
        {
            var expected = names.Split(", ");

            var actual_Extension = q.GetWizardnamesByCreatorExtension(creator);
            var actual_linq = q.GetWizardnamesByCreatorLINQ(creator);

            Assert.Equal(expected, actual_Extension);
            Assert.Equal(expected, actual_linq);
        }

        [Theory]
        [InlineData("Darth", 1977)]
        public void Given_wizard_name_return_year_of_first_apperance(string wizardName, int year)
        {
            var actual_Extension = q.GetYearOfWizardFirstApperanceExtension(wizardName);
            var actual_linq = q.GetYearOfWizardFirstApperanceLINQ(wizardName);

            Assert.Equal(year, actual_Extension);
            Assert.Equal(year, actual_linq);
        }
    }
}
