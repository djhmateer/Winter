namespace Winter.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Winter.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Winter.Web.Repository.WinterDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Winter.Web.Repository.WinterDb context)
        {
            context.StoryTypes.AddOrUpdate(
                st => st.Name,
                new StoryType { StoryTypeID = 1, Name = "Joke" },
                new StoryType { StoryTypeID = 2, Name = "Video" },
                new StoryType { StoryTypeID = 3, Name = "Quote" },
                new StoryType { StoryTypeID = 4, Name = "Picture" },
                new StoryType { StoryTypeID = 5, Name = "AnimatedGIF" }
                );

            context.Stories.AddOrUpdate(
                s => s.StoryID,
                new Story { StoryID = 1, StoryTypeID = 1, Title = "Banana", Content = "Q: Why did the banana go to the doctors? A: He wasn't peeling very well", AddedDate = DateTime.Now, Rating = 1 },
                new Story { StoryID = 2, StoryTypeID = 2, Title = "Glasgow Pizza Shop", VideoURL = "//www.youtube.com/embed/y0TxfwB3BWQ?rel=0", AddedDate = DateTime.Now, Rating = 2 },
                new Story { StoryID = 3, StoryTypeID = 3, Title = "Spike Milligan", Content = "I told you I was ill.", ImageURL = @"http://newsimg.bbc.co.uk/media/images/40190000/jpg/_40190457_milligangrave202250.jpg", AddedDate = DateTime.Now, Rating = 5 }
                );

            if (!context.Users.Any(u => u.UserName == "dave"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = "dave" };

                userManager.Create(user, "letmein");
                roleManager.Create(new IdentityRole { Name = "admin" });
                userManager.AddToRole(user.Id, "admin");
            }
        }
    }
}
