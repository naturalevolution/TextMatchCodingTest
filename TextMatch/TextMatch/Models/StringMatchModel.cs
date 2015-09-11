using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TextMatch.Common.Messages;

namespace TextMatch.Models
{
    public class StringMatchModel : BaseModel
    {
        public StringMatchModel()
        {
            Positions = new List<int>();
        }
        [Required(ErrorMessageResourceType = typeof (ErrorResource), ErrorMessageResourceName = "Required_Field")]
        [Display(ResourceType = typeof (TextMatchResource), Name = "Text")]
        public string Text { get; set; }

        [Required(ErrorMessageResourceType = typeof (ErrorResource), ErrorMessageResourceName = "Required_Field")]
        [Display(ResourceType = typeof (TextMatchResource), Name = "SubText")]
        public string SubText { get; set; }

        [Display(ResourceType = typeof(TextMatchResource), Name = "Positions")]
        public List<int> Positions { get; set; }

        public string ShowPosition
        {
            get { return string.Join(", ", Positions); }
        }
    }
}