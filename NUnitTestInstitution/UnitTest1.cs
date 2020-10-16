using NUnit.Framework;
using MyAPI.dal.Entities;
using MyAPI.Data;
using MyAPI.api;
using Microsoft.EntityFrameworkCore;

namespace NUnitTestInstitution
{
    
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        public void CheckGet()
        {
            string id = "2";
            string name = "ige";
        }
    }
}