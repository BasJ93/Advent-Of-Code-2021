using AoC2021.Implementations;
using AoC2021.Interfaces;
using NUnit.Framework;
using System;

namespace AoC2021.Tests
{
    public class FactoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetSolutionClass_ReturnsNull_WhenNoClassExists()
        {
            SolutionFactory f = new SolutionFactory();
            DateTime dateTime = DateTime.Parse("2021-12-26");
            ISolution solution = f.GetSolutionClass(dateTime);

            Assert.IsNull(solution);
        }

        [Test]
        public void GetSolutionClass_ReturnsCalss_WhenClassExists()
        {
            SolutionFactory f = new SolutionFactory();
            DateTime dateTime = DateTime.Parse("2021-12-01");
            ISolution solution = f.GetSolutionClass(dateTime);

            Assert.IsInstanceOf(typeof(ISolution), solution);
        }
    }
}