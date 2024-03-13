using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateTimeFormat = "dd.MM.yyyy";
        public static class Sponsor 
        {
            public const int NameMaxLenght = 150;
            public const int NameMinLenght = 3;
            public const string NameLenght = "The {0} field must be between {2} and {1} characters long.";

            public const int NetWorthMax = 10;
            public const int NetWorthMin = 1;
            public const string NetWorthRange = "The {0} field must be between {2} and {1} characters long.";
        }

        public static class Team 
        {
            public const int NameMaxLenght = 90;
            public const int NameMinLenght = 2;

            public const int ManagerNameMaxLenght = 60;
            public const int ManagerNameMinLenght = 2;
            
            public const int StadiumMaxLenght = 90;
            public const int StadiumMinLenght = 2;

            public const int NicknameMaxLenght = 40;
            public const int NicknameMinLenght = 2;
        }

        public static class FootballGame 
        {
            public const int RefereeNameMaxLenght = 50;
            public const int RefereeNameMinLenght = 1;
        }

        public static class Event
        {
            public const int NameMaxLenght = 50;
            public const int NameMinLenght = 1;

            public const int DescriptionMaxLenght = 100;
            public const int DescriptionMinLenght = 1;

            public const int LocationNameMaxLenght = 50; 
            public const int LocationNameMinLenght = 2; 
        }

        public static class Comment 
        {
            public const int TextMaxLenght = 300;
            public const int TextMinLenght = 1;
        }
    }
}
