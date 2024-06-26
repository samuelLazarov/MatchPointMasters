﻿namespace MatchPointMasters.Infrastructure.Constants
{
    public class DataConstants
    {
        public const string DateTimeDefaultFormat = "dd/MM/yyyy";
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";



        public static class ApplicationUserConstants
        {
            public const int ApplicationUserFirstNameMinLength = 1;
            public const int ApplicationUserFirstNameMaxLength = 30;

            public const int ApplicationUserLastNameMinLength = 1;
            public const int ApplicationUserLastNameMaxLength = 30;
        }

        public static class TournamentConstants
        {
            public const string DateTimeTournamentFormat = "dd/MM/yyyy HH:mm";

            //Tournament's Name
            public const int TournamentNameMinLength = 2;
            public const int TournamentNameMaxLength = 100;

            //Description
            public const int TournamentDescriptionMinLength = 50;
            public const int TournamentDescriptionMaxLength = 1000;

            //ImageUrl
            public const int TournamentImageUrlMinLength = 5;
            public const int TournamentImageUrlMaxLength = 500;

            //Tournament Capacity
            public const int TournamentCapacityMinRange = 8;
            public const uint TournamentCapacityMaxRange = 128;

            //Tournament Fee
            public const int TournamentFeeMinRange = 1;
            public const uint TournamentFeeMaxRange = uint.MaxValue;

        }

        public static class ClubConstants
        {
            //Name
            public const int ClubNameMinLength = 2;
            public const int ClubNameMaxLength = 100;

            //Address
            public const int ClubAddressMinLength = 10;
            public const int ClubAddressMaxLength = 100;

            //Phone
            public const int ClubPhoneMinLength = 7;
            public const int ClubPhoneMaxLength = 20;

            //ImageUrl
            public const int ClubImageUrlMinLength = 5;
            public const int ClubImageUrlMaxLength = 500;
        }


        public static class MatchConstants
        {
            //Tiebreaks Range
            public const int TiebreakMinRange = 0;
            public const uint TiebreakMaxRange = 50;

            //Games Range
            public const int GamesMinRange = 0;
            public const uint GamesMaxRange = 7;

            //Sets Range
            public const int SetsMinRange = 0;
            public const uint SetsMaxRange = 5;
        }

        public static class PlayerConstants
        {
            //Name
            public const int PlayerNameMinLength = 2;
            public const int PlayerNameMaxLength = 100;

            //Phone
            public const int PlayerPhoneMinLength = 7;
            public const int PlayerPhoneMaxLength = 20;

            //Birthdate
            public const string DateTimeBirthdayFormat = "dd/MM/yyyy";

            //ImageUrl
            public const int PlayerImageUrlMinLength = 5;
            public const int PlayerImageUrlMaxLength = 500;
        }

        public static class TournamentHostConstants
        {
            //Phone
            public const int HostPhoneMinLength = 7;
            public const int HostPhoneMaxLength = 20;

            //Email
            public const string HostEmailRegex = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        }

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

        public static class ArticleCommentConstants
        {
            //Title
            public const int ArticleCommentTitleMinLength = 1;
            public const int ArticleCommentTitleMaxLength = 50;

            //Description
            public const int ArticleCommentDescriptionMinLength = 15;
            public const int ArticleCommentDescriptionMaxLength = 8000;
        }


    }
}
