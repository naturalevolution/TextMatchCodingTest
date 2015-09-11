namespace TextMatch.Factories
{
    public class Factory
    {
        private static StringFactory _stringFactory;

        public static StringFactory String
        {
            get { return _stringFactory ?? (_stringFactory = new StringFactory()); }
        }
    }
}