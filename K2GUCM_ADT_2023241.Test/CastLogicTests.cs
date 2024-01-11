using Moq;
using NUnit.Framework;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Logic.Interfaces;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Test
{
    [TestFixture]
    public class CastLogicTests
    {
        //Mocking

        Mock<ICastRepository> castRepo = new();
        ICastLogic castLogic;

        [SetUp]
        public void Setup()
        {
            //Sets up a mock repo
            castRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Cast());
            castRepo.Setup(x => x.Add(It.Is<Cast>(y => y.Cast_Name == null))).Throws<ArgumentNullException>();

            castLogic = new CastLogic(castRepo.Object);
        }

        [Test]
        public void ThrowsTest()
        {
            //Setup

            //Act

            //Asserts if exception is thrown
            Assert.Throws<ArgumentNullException>(() => castLogic.Add(new Cast()));
        }
    }
}