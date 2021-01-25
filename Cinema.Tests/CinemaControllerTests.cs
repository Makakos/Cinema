using Cinema.Controllers;
using Cinema.Models;
using Cinema.Repositories.Abstruct;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Cinema.Tests
{
    public class CinemaControllerTests
    {
        [Fact]
        public void FilmsTest()
        {
            // Arrange

            var moq = new Mock<DataManager>();
            CinemaController controller = new CinemaController(moq.Object);

            // Act
           var result = controller.Films();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<DataManager>(viewResult.Model);
        }


        [Fact]
        public void FilmTest()
        {
            // Arrange
            var moqFilms = new Mock<IFilmsRepository>();
            moqFilms.Setup(rep => rep.GetFilmById(1)).Returns(TestFilm);

            //var moq = new Mock<DataManager>();
            //moq.Setup(rep=>rep.filmsRepository.GetFilmById(1)).Returns(TestFilm);
            //CinemaController controller = new CinemaController(moq.Object);

            Film expected = new Film
            {
                Id = 1,
                Name = "Shindler`s list",
                Runtime = new TimeSpan(3, 17, 0),
                Description = null,
                PosterImagePath = null,
                Rate = 8.9,
                DirectorName = "Steven",
                DirectorLastName = "Spilberg",
                Sessions = null
            };

            // Act
            //var result = controller.Film(1);
            Film actual = moqFilms.Object.GetFilmById(1);

            // Assert
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom<Film>(viewResult.Model);
            Assert.Equal(expected.Id,actual.Id);
            Assert.Equal(expected.Name, actual.Name);
        }


        [Fact]
        public void SessionTest()
        {
            // Arrange
            var moqSessions = new Mock<ISessionsRepository>();
            moqSessions.Setup(rep => rep.GetSessionById(1)).Returns(TestSession);

    

            Session expected = new Session
            {
                Id = 1,
                Date = new DateTime(2020, 12, 13),
                Hall = 1,
                FilmId = 0,
                Film = null

            };

            // Act
            
            Session actual = moqSessions.Object.GetSessionById(1);

            // Assert
            Assert.Equal(expected.Id, actual.Id);
        }


        private Film TestFilm()
        {
            Film result = new Film
            {
                Id = 1,
                Name = "Shindler`s list",
                Runtime = new TimeSpan(3, 17, 0),
                Description=null,
                PosterImagePath=null,
                Rate = 8.9,
                DirectorName = "Steven",
                DirectorLastName = "Spilberg",
                Sessions=null
                
            };
               
            return result;
        }

        private Session TestSession()
        {
            Session result = new Session
            {
                Id = 1,
                Date = new DateTime(2020, 12, 13),
                Hall = 1,
                FilmId = 0,
                Film = null

            };

            return result;
        }
    }
}
