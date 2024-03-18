using SoftUniFinalProject.Core.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniFinalProject.Core.Contracts.Event
{
    public interface IFootballGameService
    {
        Task<FootballGameViewModel> GetFootballDetailsAsync(int footballGameId);
    }
}
