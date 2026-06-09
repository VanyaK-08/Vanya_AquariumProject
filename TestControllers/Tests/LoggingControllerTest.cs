using AquariumController;
using AquariumData;
using AquariumData.Entities;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class LoggingControlTests
    {
        private LoggingController controller;
        [SetUp]
        public void Setup()
        {
            AquariumContext context = TestDBStuff.CreateContext();
            context.Users.Add(new Userr
            {
                Id = 1,
                Username = "Petur08",
                Email = "petur.08@gmail.com",
                Password = "password123"
            });
            context.SaveChanges();
            controller = new LoggingController(context);
        }
        [Test]
        public async Task Login_SuccessfullyLogin()
        {
            var user = await controller.Login("Petur08", "petur.08@gmail.com", "password123");

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Petur08", user.Username);
            Assert.AreEqual("petur.08@gmail.com", user.Email);
        }
        [Test]
        public async Task Login_InvalidUsername_ReturnsNull()
        {
            var user = await controller.Login("WrongUsername", "petur.08@gmail.com", "password123");
            Assert.IsNull(user);
        }
        [Test]
        public async Task Login_InvalidEmail_ReturnsNull()
        {
            var user = await controller.Login("Petur08", "wrong@gmail.com", "password123");

            Assert.IsNull(user);
        }
        [Test]
        public async Task Login_InvalidPassword_ReturnsNull()
        {
            var user = await controller.Login("Petur08", "petur.08@gmail.com", "wrongpassword");

            Assert.IsNull(user);
        }

    }
}
