using Microsoft.EntityFrameworkCore;
using SoftUniFinalProject.Core.Services.AttendanceService;
using SoftUniFinalProject.Infrastructure.Data.Common;
using SoftUniFinalProject.Infrastructure.Data.Models;
using SoftUniFinalProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftUniFinalProject.Core.Services.Admin.UserService;

namespace SoftUniFinalProject.UnitTests
{
    public class UserServiceTests
    {
        private UserService userService;

        [SetUp]
        public void Setup()
        {
           userService = new UserService();
        }

        [Test]
        public void RoleCreate_ReturnsCorrectRole()
        {
            // Arrange
            string roleName = "TestRole";

            // Act
            var role = userService.RoleCreate(roleName);

            // Assert
            Assert.NotNull(role);
            Assert.AreEqual(roleName, role.Name);
            Assert.AreEqual(roleName.ToUpper(), role.NormalizedName);
        }
    }
}
