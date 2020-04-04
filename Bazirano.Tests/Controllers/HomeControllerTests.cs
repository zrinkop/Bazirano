﻿using Bazirano.Controllers;
using Bazirano.Models.Admin;
using Bazirano.Models.Board;
using Bazirano.Models.Column;
using Bazirano.Models.DataAccess;
using Bazirano.Models.Home;
using Bazirano.Models.News;
using Bazirano.Tests.TestData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Bazirano.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]  
        void Index_DisplaysViewWithCorrectModel()
        {
            var boardThreadsRepoMock = new Mock<IBoardThreadRepository>();
            var articlesRepoMock = new Mock<IArticleRepository>();
            var homeController = new HomeController(boardThreadsRepoMock.Object, articlesRepoMock.Object);

            var result = (ViewResult)homeController.Index();

            Assert.Equal(nameof(homeController.Index), result.ViewName);
            Assert.IsType<HomePageViewModel>(result.ViewData.Model);
        }
    }
}
