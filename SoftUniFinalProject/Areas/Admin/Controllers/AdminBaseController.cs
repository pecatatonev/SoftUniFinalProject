using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static SoftUniFinalProject.Core.Constants.RoleConstants;

namespace SoftUniFinalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class AdminBaseController : Controller
    {
    }
}
