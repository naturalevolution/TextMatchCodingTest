namespace TextMatch.Models
{
    public abstract class BaseModel
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(ErrorMessage); }
        }
    }
}