using System;
using System.Linq;
using BLL.Services.Abstractions;
using FluentAssertions;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using WebAPI.Controllers;
using Xunit;

namespace Tests.ControllersTests;

public class MoviesTests
{
    [Fact]
    public void Get_Return_Movies()
    {
        var service = A.Fake<IMoviesService>();
        var movies = A.CollectionOfDummy<MovieModel>(10);
        A.CallTo(() => service.GetMovies()).Returns(movies);
        var controller = new MoviesController(service);
        
        var result = controller.Get();

        result.Count().Should().Be(movies.Count);
    }
    
    [Fact]
    public void Get_Given_Id_Return_Movie()
    {
        var service = A.Fake<IMoviesService>();
        var movie = A.Dummy<MovieModel>();
        A.CallTo(() => service.GetMovieById(Guid.Empty)).Returns(movie);
        var controller = new MoviesController(service);
        
        var okResult = controller.Get(Guid.Empty) as OkObjectResult;
        var result = okResult!.Value;

        result.Should().BeEquivalentTo(result);
    }
    
    [Fact]
    public void Get_Given_ById_Movie_Return_Status404()
    {
        var service = A.Fake<IMoviesService>();
        A.CallTo(() => service.GetMovieById(Guid.Empty)).Returns(null);
        var controller = new MoviesController(service);
        
        var result = controller.Get(Guid.Empty) as ObjectResult;

        result!.StatusCode.Should().Be(404);
    }
    
    [Fact]
    public void Post_Given_MovieModel_Return_Status200()
    {
        var service = A.Fake<IMoviesService>();
        var movie = A.Dummy<MovieModel>();
        var controller = new MoviesController(service);
        
        var result = controller.Post(movie) as ObjectResult;

        result!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public void Patch_Given_Id_MovieModel_Return_Status200()
    {
        var service = A.Fake<IMoviesService>();
        var movie = A.Dummy<MovieModel>();
        var controller = new MoviesController(service);
        
        var result = controller.Patch(Guid.Empty, movie) as ObjectResult;

        result!.StatusCode.Should().Be(200);
    }
}