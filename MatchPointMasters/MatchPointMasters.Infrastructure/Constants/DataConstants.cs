namespace MatchPointMasters.Infrastructure.Constants
{
    public class DataConstants
    {
        public const string DateTimeDefaultFormat = "dd/MM/yyyy";
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public static class MatchConstants
        {

        }

        public static class TournamentConstants
        {
            public const string DateTimeEventFormat = "dd/MM/yyyy HH:mm";

            //Tournament's Name
            public const int TournamentNameMinLength = 4;
            public const int TournamentNameMaxLength = 100;

            //Description
            public const int TournamentDescriptionMinLength = 50;
            public const int TournamentDescriptionMaxLength = 1000;

            
        }

        public static class ClubConstants
        {
            //Location
            public const int ClubLocationMinLength = 10;
            public const int ClubLocationMaxLength = 100;

            //ImageUrl
            public const int ClubImageUrlMinLength = 5;
            public const int ClubImageUrlMaxLength = 500;
        }

        public static class PlayerConstants
        {

        }

        public const int NameMinLenght = 2;

        public const int NameMaxLenght = 50;

        public const int TitleMaxLenght = 50;

        public const int TitleMinLenght = 10;

        public const int AddressMaxLenght = 150;

        public const int AddressMinLenght = 30;

        public const int DescriptionMaxLength = 500;

        public const int DescriptionMinLength = 50;

        public const int PlayerPhoneMaxLength = 15;

        public const int PlayerPhoneMinLength = 7;

        public static class ArticleConstants
        {
            public const string DateTimeArticleFormat = "dd/MM/yyyy HH:mm";

            //Title
            public const int ArticleTitleMinLength = 5;
            public const int ArticleTitleMaxLength = 100;

            //Content
            public const int ArticleContentMinLength = 100;
            public const int ArticleContentMaxLength = 10000;

            //ImageUrl
            public const int ArticleImageUrlMinLength = 5;
            public const int ArticleImageUrlMaxLength = 500;

            //ViewsCount
            public const int ArticleViewsCountMinRange = 0;
            public const int ArticleViewsCountMaxLength = int.MaxValue;
        }
    }
}
