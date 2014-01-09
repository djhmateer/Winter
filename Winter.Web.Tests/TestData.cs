using System;
using System.Collections.Generic;
using System.Linq;
using Winter.Web.Models;

namespace Winter.Web.Tests
{
    public class TestData
    {
        public static IQueryable<Story> Stories
        {
            get
            {
                // Create a list of 100 Stories
                var stories = new List<Story>();
                for (var i = 1; i <= 100; i++)
                {
                    var story = new Story { StoryID = i, StoryTypeID = 1, Title = "Banana" + i, Content = "asdf", AddedDate = DateTime.Now, Rating = i };
                    stories.Add(story);
                }
                return stories.AsQueryable();
            }
        }
    }
}
