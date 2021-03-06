﻿using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Winter.Web.Controllers;
using Winter.Web.Models;
using Winter.Web.Tests.Fakes;

namespace Winter.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_GivenFake_ShouldReturn100Stories()
        {
            var db = new FakeWinterDb();
            db.AddSet(TestData.Stories);

            ILogger logger = new FakeLogger();
            var controller = new HomeController(db, logger);

            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Story>;

            Assert.AreEqual(100, model.Count());
        }

        //[TestMethod]
        //public void Index_GivenFake_ShouldReturnAllStoriesOrderedByRatingWithHighestFirst()
        //{
        //    var db = new FakeWinterDb();
        //    db.AddSet(TestData.Stories);
        //    var controller = new HomeController(db);

        //    var result = controller.Index() as ViewResult;
        //    var model = result.Model as IEnumerable<Story>;

        //    // Want the one with the highest rating first
        //    var expected = db.Query<Story>().OrderByDescending(s => s.Rating).ToList();
        //    CollectionAssert.AreEqual(expected, model.ToList());
        //}

        [TestMethod]
        public void Index_GivenNothing_ResultShouldNotBeNull()
        {
            UnityConfig.RegisterComponents(); 
            var controller = UnityConfig.container.Resolve<HomeController>();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_GivenNothing_ShouldLog()
        {
            UnityConfig.RegisterComponents();
            var controller = UnityConfig.container.Resolve<HomeController>();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }


        //[TestMethod]
        //public void About_GivenNothing_ViewBagShouldContainMessage()
        //{
        //    var controller = new HomeController(null);

        //    var result = controller.About() as ViewResult;

        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}
    }

    // Integration tests depend on the test data inserted in migrations
    [TestClass]
    public class HomeControllerTestsIntegration
    {
        [TestMethod]
        public void Index_GivenNothing_ShouldReturnAListOfAll2Stories()
        {
            UnityConfig.RegisterComponents();
            var controller = UnityConfig.container.Resolve<HomeController>();

            var result = controller.Index() as ViewResult;

            var model = result.Model as IEnumerable<Story>;

            Assert.AreEqual(2, model.Count());
        }

        //    [TestMethod]
        //    public void Index__FirstStorySpikeMilliganShouldReturnStoryTypeName()
        //    {
        //        var controller = new HomeController();

        //        var result = controller.Index() as ViewResult;
        //        var model = result.Model as IEnumerable<Story>;

        //        Assert.AreEqual(2, model.Count());
        //        var first = model.FirstOrDefault();
        //        Assert.IsNotNull(first.StoryType.Name);
        //    }
        //}

        // Unit test as injecting in a fake repository
        //[TestMethod]
        //public void Index_GivenAFakeRepository_ShouldReturnAListOfAllStories()
        //{
        //    var storyRepository = Mock.Create<IStoryRepository>();
        //    Mock.Arrange(() => storyRepository.GetAllStories())
        //        .Returns(new List<Story>()
        //        {
        //            new Story { StoryID=1, Title="title1", Content="content1"},
        //            new Story { StoryID=2, Title="title2", Content="content2"}
        //        })
        //        .MustBeCalled();

        //    // Act
        //    HomeController controller = new HomeController(storyRepository);
        //    ViewResult result = controller.Index() as ViewResult;
        //    IEnumerable<Story> model = result.Model as IEnumerable<Story>;

        //    Assert.AreEqual(2, model.Count());
    }
}
