using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class Sponsor 
        {
            public const int NameMaxLenght = 150;
            public const int NameMinLenght = 3;

            public const int NetWorthMax = 10;
            public const int NetWorthMin = 1;
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
    }
}
