using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Winter.Web.Models
{
    public class Story : IValidatableObject
    {
        public int StoryID { get; set; }

        public StoryType StoryType { get; set; }
        public int StoryTypeID { get; set; }

        [Required]
        [StringLength(100)]
        [MaxWords(10, ErrorMessage = "10 Words or less in Title please")]
        public string Title { get; set; }

        [StringLength(2048)]
        [MaxWords(2000, ErrorMessage = "2000 Words or less in content please - keep it short!")]
        public string Content { get; set; }

        [Display(Name = "Video URL")]
        [DisplayFormat(NullDisplayText = "none set")]
        public string VideoURL { get; set; }

        [Display(Name = "Image URL")]
        [DisplayFormat(NullDisplayText = "none set")]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Added Date")]
        [DisplayFormat(DataFormatString = "{0:d-MMM-yy}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "Rating should be in the range of 0 to 9999")]
        public int Rating { get; set; }

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == "Dave")
            {
                yield return new ValidationResult("Sorry you can't do this Dave");
            }
        }
    }

    public class MaxWordsAttribute : ValidationAttribute
    {
        public MaxWordsAttribute(int wordCount)
            : base("Too many words in {0}")
        {
            WordCount = wordCount;
        }

        public int WordCount { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var wordCount = value.ToString().Split(' ').Length;
                if (wordCount > WordCount)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
}