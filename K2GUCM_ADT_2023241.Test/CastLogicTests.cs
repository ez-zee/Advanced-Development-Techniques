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

        [Test]
        public void GetAllTest()
        {
            //Setup
            castRepo.Setup(x => x.GetAll()).Returns(new List<Cast>
            {
                new Cast {Cast_ID = 1}
            });
            //Act
            castLogic.GetAll();
            //Assert
            castRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void AddTest()
        {
            //Setup

            //Act
            castLogic.Add(new Cast { Cast_Name = "Test" });
            //Assert
            castRepo.Verify(x => x.Add(It.IsAny<Cast>()), Times.Once);
        }

        [Test]
        public void UpdateTest()
        {
            //Setup

            //Act
            castLogic.Update(new Cast());
            //Assert
            castRepo.Verify(x => x.Update(It.IsAny<Cast>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {
            //Setup

            //Act
            castLogic.Delete(new Cast());
            //Asserts if an item was deleted only once
            castRepo.Verify(x => x.Delete(It.IsAny<Cast>()), Times.Once);
        }
    }
}