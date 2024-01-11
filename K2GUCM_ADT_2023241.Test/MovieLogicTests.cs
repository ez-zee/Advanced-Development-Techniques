using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using K2GUCM_ADT_2023241.Logic;
using K2GUCM_ADT_2023241.Models;
using K2GUCM_ADT_2023241.Repository.Interfaces;

namespace K2GUCM_ADT_2023241.Test
{
    [TestFixture]
    public class MovieLogicTests
    {
        //Mocking
        Mock<IRepository<Movie>> movieRepositoryMock = new();
        Mock<IRepository<Review>> reviewRepositoryMock = new();
        Mock<IRepository<Cast>> castRepositoryMock = new();
        MovieLogic movieLogic;

        [OneTimeSetUp]
        public void TestSetup()
        {
            //setting up mock repos for MovieRepository
            movieRepositoryMock.Setup(x => x.Create(It.Is<Movie>(y => y.Movie_Title == null))).Throws<ArgumentNullException>();
            movieRepositoryMock.Setup(x => x.Read(It.IsAny<int>())).Returns(new Movie());
            movieLogic = new(movieRepositoryMock.Object);

            movieRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Movie>{
                new Movie{Movie_ID = 1, Movie_Director = "Test", Movie_ReleaseYear = 2022, Movie_Title = "Test-Title"},
                new Movie{Movie_ID = 2, Movie_Director = "Test2", Movie_ReleaseYear = 2022, Movie_Title = "Test-Title2"}
                }
            );

            //setting up mock repos for CastRepository
            castRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Cast>
            {
                new Cast{Cast_ID = 1,Cast_Movie_ID = 1,Cast_Name = "Test1", Cast_Nick = "Test1_nick" },
                new Cast{Cast_ID = 2,Cast_Movie_ID = 2,Cast_Name = "Test2", Cast_Nick = "Test1_nick2" },
            });

            //setting up mock repos for ReviewRepository
            reviewRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Review>
            {
                new Review{Review_ID = 1, Review_Movie_ID = 1, Review_Content = "Test1_Content"},
                new Review{Review_ID = 2, Review_Movie_ID = 2, Review_Content = "Test2_Content"}
            });
        }

        //Testing all methods
        [Test]
        public void GetAllTest()
        {
            //Setup
            movieRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Movie> { new Movie { Movie_ID = 1 } });
            //Act
            movieLogic.GetAll();
            //Assert
            movieRepositoryMock.Verify(x => x.ReadAll(), Times.Once);
        }

        [Test]
        public void ThrowsTest()
        {
            Assert.Throws<ArgumentNullException>(() => movieLogic.Add(new Movie()));
        }

        [Test]
        public void AddTest()
        {
            //Act
            movieLogic.Add(new Movie { Movie_ID = 1, Movie_Title = "test" });
            //Assert
            movieRepositoryMock.Verify(x => x.Create(It.IsAny<Movie>()), Times.Once);
        }

        [Test]
        public void UpdateTest()
        {
            //Act
            movieLogic.Update(new Movie());
            //Assert
            movieRepositoryMock.Verify(m => m.Update(It.IsAny<Movie>()), Times.Once);
        }

        [Test]
        public void DeleteTest()
        {
            //Act
            movieLogic.Delete(1);
            //Assert
            movieRepositoryMock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void FindByIDTest()
        {
            //Act
            movieLogic.GetById(0);

            //ASSERT
            movieRepositoryMock.Verify(m => m.Read(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void NumberOfMoviesInAYearTest()
        {
            //Setup
            movieRepositoryMock.Setup(x => x.ReadAll()).Returns(new List<Movie>(){
                new Movie{Movie_ID = 1, Movie_Director = "Test", Movie_ReleaseYear = 2022, Movie_Title = "Test-Title"},
                new Movie{Movie_ID = 2, Movie_Director = "Test2", Movie_ReleaseYear = 2022, Movie_Title = "Test-Title2"}
                }
            );
            int expected = 2;
            int result = 0;
            //Act
            result = movieLogic.NumberOfMoviesInAGivenYear(2022);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}

