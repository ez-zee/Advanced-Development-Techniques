using Moq;
using NUnit.Framework;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Test
{
    [TestFixture]
    public class ReviewLogicTests
    {
        Mock<IReviewRepository> reviewRepo = new();
        ReviewLogic reviewLogic;

        [SetUp]
        public void Setup()
        {
            reviewRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Review());
            reviewRepo.Setup(x => x.Add(It.Is<Review>(y => y.Review_Movie_ID == 0))).Throws<ArgumentNullException>();

            reviewLogic = new ReviewLogic(reviewRepo.Object);
        }

        [Test]
        public void ThrowsTest()
        {
            //Setup

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => reviewLogic.Add(new Review()));
        }

        [Test]
        public void GetAllTest()
        {
            //Setup
            reviewRepo.Setup(x => x.GetAll()).Returns(new List<Review>
            {
                new Review {Review_ID = 1}
            });
            //Act
            reviewLogic.GetAll();
            //Assert
            reviewRepo.Verify(x => x.GetAll(), Times.AtLeastOnce);
        }

        [Test]
        public void AddTest()
        {
            //Setup

            //Act
            reviewLogic.Add(new Review { Review_Movie_ID = 1 });
            //Assert
            reviewRepo.Verify(x => x.Add(It.IsAny<Review>()), Times.Once);
        }

        [Test]
        public void UpdateTest()
        {
            //Setup

            //Act
            reviewLogic.Update(new Review());
            //Assert
            reviewRepo.Verify(x => x.Update(It.IsAny<Review>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {
            //Setup

            //Act
            reviewLogic.Delete(new Review());
            //Assert
            reviewRepo.Verify(x => x.Delete(It.IsAny<Review>()), Times.Once);
        }

        [Test]
        public void GetByIdTest()
        {
            //Setup

            //Act
            reviewLogic.GetById(1);
            //Assert
            reviewRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void GetAllFromAGivenMovie()
        {
            //Setup
            reviewRepo.Setup(x => x.GetAll()).Returns(new List<Review>
            {
                new Review{ Review_ID = 1, Review_Content = "Test1", Review_Movie_ID = 1},
                new Review{ Review_ID = 2, Review_Content = "Test2", Review_Movie_ID = 2},
            });
            List<Review> expected = new List<Review> { new Review { Review_ID = 1, Review_Content = "Test1", Review_Movie_ID = 1 } };
            //Act
            List<Review> result = (List<Review>)reviewLogic.GetAllFromAGivenMovie(1);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
