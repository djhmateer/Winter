using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Winter.Web.Controllers;
using Winter.Web.Models;

namespace Winter.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        // Integration
        [TestMethod]
        public void Index__ShouldReturnAllStoriesIncludingStoryTypeName()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            IEnumerable<Story> model = result.Model as IEnumerable<Story>;

            var x = model.ToList();

            Assert.AreEqual(3, model.Count());
        }


        [TestMethod]
        public void Index__ShouldReturnAllStoriesOrderedByRating()
        {
            //var db = new FakeWinterDb();
            //db.AddSet(TestData.Restaurants);
            //var controller = new HomeController(db);

            //var result = controller.Index() as ViewResult;
            //var model = result.Model as IEnumerable<StoryListViewModel>;

            //Assert.AreEqual(10, model.Count());
        }


        // Integration
        [TestMethod]
        public void Index_GivenNothing_ResultShouldNotBeNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        // Integration test hitting the db
        [TestMethod]
        public void Index_GivenNothing_ShouldReturnAListOf3Stories()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            IEnumerable<Story> model = result.Model as IEnumerable<Story>;

            Assert.AreEqual(3, model.Count());
        }


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
        //}



        [TestMethod]
        public void About_GivenNothing_ViewBagShouldContainMessage()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.About() as ViewResult;

            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }   

        [TestMethod]
        public void Contact_GivenNothing_ResultShouldNotBeNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
