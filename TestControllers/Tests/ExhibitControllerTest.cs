using AquariumController;
using AquariumData;
using AquariumData.Entities;
using TestControllers.Saving;

namespace TestControllers.Tests
{
    public class ExhibitControlTests
    {
        private ExhibitController controller;
        [SetUp]
        public void Setup()
        {
            AquariumContext context = TestDBStuff.CreateContext();
            context.SaveChanges();
            controller = new ExhibitController(context);
        }
        [Test]
        public async Task AddExhibit_SuccessfullyAddExhibit()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            await controller.AddExhibit(exhibit);
            var exhibits = await controller.GetAllExhibits();
            var addedExhibit = exhibits.FirstOrDefault();
            Assert.IsNotNull(addedExhibit);
            Assert.AreEqual("Exhibit1", addedExhibit.Title);
            Assert.AreEqual("Description1", addedExhibit.Description);
        }
        [Test]
        public void AddExhibit_InvalidTitle_ThrowsException()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "",
                Description = "Description1"
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddExhibit(exhibit));
        }
        [Test]
        public async Task AddExhibit_AlreadyExisting_ThrowsException()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            await controller.AddExhibit(exhibit);
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.AddExhibit(exhibit));
        }
        [Test]
        public async Task UpdateExhibit_SuccessfullyUpdateExhibit()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            await controller.AddExhibit(exhibit);
            var exhibits = await controller.GetAllExhibits();
            var addedExhibit = exhibits.FirstOrDefault();
            addedExhibit.Title = "UpdatedTitle";
            addedExhibit.Description = "UpdatedDescription";
            await controller.UpdateExhibit(addedExhibit);
            var updatedExhibits = await controller.GetAllExhibits();
            var updatedExhibit = updatedExhibits.FirstOrDefault();
            Assert.IsNotNull(updatedExhibit);
            Assert.AreEqual("UpdatedTitle", updatedExhibit.Title);
            Assert.AreEqual("UpdatedDescription", updatedExhibit.Description);
        }
        [Test]
        public async Task UpdateExhibit_NonExisting_ThrowsException()
        {
            Exhibit exhibit = new Exhibit
            {
                Id = 999,
                Title = "NonExisting",
                Description = "Description"
            };
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateExhibit(exhibit));
        }
        [Test]
        public async Task UpdateExhibit_InvalidTitle_ThrowsException()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            await controller.AddExhibit(exhibit);
            var exhibits = await controller.GetAllExhibits();
            var addedExhibit = exhibits.FirstOrDefault();
            addedExhibit.Title = "";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateExhibit(addedExhibit));
        }
        [Test]
        public async Task UpdateExhibit_AlreadyExisting_ThrowsException()
        {
            Exhibit exhibit = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            await controller.AddExhibit(exhibit);
            var exhibits = await controller.GetAllExhibits();
            var addedExhibit = exhibits.FirstOrDefault();
            Exhibit exhibit2 = new Exhibit
            {
                Title = "Exhibit2",
                Description = "Description2"
            };
            await controller.AddExhibit(exhibit2);
            addedExhibit.Title = "Exhibit2";
            Assert.ThrowsAsync<ArgumentException>(async () => await controller.UpdateExhibit(addedExhibit));
        }
        [Test]
        public async Task GetAllExhibits_ReturnsAllExhibits()
        {
            Exhibit exhibit1 = new Exhibit
            {
                Title = "Exhibit1",
                Description = "Description1"
            };
            Exhibit exhibit2 = new Exhibit
            {
                Title = "Exhibit2",
                Description = "Description2"
            };
            await controller.AddExhibit(exhibit1);
            await controller.AddExhibit(exhibit2);
            var exhibits = await controller.GetAllExhibits();
            Assert.AreEqual(2, exhibits.Count);
            Assert.IsTrue(exhibits.Any(e => e.Title == "Exhibit1" && e.Description == "Description1"));
            Assert.IsTrue(exhibits.Any(e => e.Title == "Exhibit2" && e.Description == "Description2"));
        }
    }
}
