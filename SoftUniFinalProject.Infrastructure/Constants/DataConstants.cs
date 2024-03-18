using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateTimeFormat = "dd/MM/yyyy HH:mm";
        public const string LenghtMessage = "The {0} field must be between {2} and {1} characters long.";
        public const string LenghtIntegerMessage = "The {0} field must be between {1} and {2}.";
        public const string RequiredMessage = "The {0} field is required.";
        public static class Sponsor 
        {
            public const int NameMaxLenght = 150;
            public const int NameMinLenght = 3;

            public const int NetWorthMax = 10;
            public const int NetWorthMin = 1;

            public const int YearCreatedMax = 2024;
            public const int YearCreatedMin = 1900;
        }

        public static class Team 
        {
            public const int NameMaxLenght = 90;
            public const int NameMinLenght = 2;

            public const int ManagerNameMaxLenght = 60;
            public const int ManagerNameMinLenght = 2;
            
            public const int StadiumMaxLenght = 90;
            public const int StadiumMinLenght = 2;

            public const int StadiumCapacityMax = 200000;
            public const int StadiumCapacityMin = 1000;

            public const int NicknameMaxLenght = 40;
            public const int NicknameMinLenght = 2;

            public const int YearCreatedMax = 2024;
            public const int YearCreatedMin = 1800;
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
