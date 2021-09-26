using System;
using Xunit;
using BDSA2020.Assignment03;
using System.Collections.Generic;
using System.Linq;

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

        [Fact]
        public void Given_Harry_Potter_return_wizard_and_year()
        {
            var actual_Extension = q.GetNamesAndYearsFromMediaExtension("Harry Potter");
            var actual_linq = q.GetNamesAndYearsFromMediaLINQ("Harry Potter");

            var expected = new (string, int?)[]{
                ("Albus Dumbledore", 1997),
                ("Harry Potter", 1997),
                ("Lord Voldemort", 1997),
                ("Severus Snape", 1997),
                ("Draco Malfoy", 1997),
                ("Sirius Black", 1997),
                ("Ron Wesley", 1997),
            };

            Assert.Equal(expected, actual_Extension);
            Assert.Equal(expected, actual_linq);
        }

        [Fact]
        public void Get_wizards_ordered_by_creator_desc()
        {
            var actual_Extension = q.GetWizardNamesGroupedByCreatorExtension().ToArray();
            var actual_linq = q.GetWizardNamesGroupedByCreatorLINQ().ToArray();

            IEnumerable<string> expected = new string[]{
                "Sauron",
                "Gandalf",
                "Sirius Black",
                "Severus Snape",
                "Ron Wesley",
                "Lord Voldemort",
                "Harry Potter",
                "Draco Malfoy",
                "Albus Dumbledore",
                "Master Yoda",
                "Luke Skywalker",
                "Darth Vader",
            };

            Assert.Equal(expected, actual_Extension);
            Assert.Equal(expected, actual_linq);
        }
    }
}
