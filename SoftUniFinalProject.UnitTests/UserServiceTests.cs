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
