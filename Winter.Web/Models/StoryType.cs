using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Winter.Web.Models
{
    public class StoryType
    {
        public int StoryTypeID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
    }
}