using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCafe_Remake_.Controllers;
using PetCafe_Remake_.Interface;
using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Tests
{
    public class DogControllerTests
    {
        private IDogRepository _dogRepository;
        private IPhotoService _photoService;
        private IHttpContextAccessor _httpContextAccessor;
        private DogController _dogController;

        public DogControllerTests()
        {
            _dogRepository = A.Fake<IDogRepository>();
            _photoService = A.Fake<IPhotoService>();
            _httpContextAccessor = A.Fake<HttpContextAccessor>();

            //this is sut
            _dogController = new DogController(_dogRepository, _photoService, _httpContextAccessor);

        }

        // to test getAll
        [Fact]
        public void DogController_Index_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var dogs = A.Fake<IEnumerable<Dog>>();
            A.CallTo(() => _dogRepository.GetAll()).Returns(dogs);
            //Act
            var result = _dogController.Index();
            //Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }

        // to test getById
        [Fact]
        public void DogController_Detail_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var id = 1;
            var dog = A.Fake<Dog>();
            A.CallTo(() => _dogRepository.GetByIdAsync(id)).Returns(dog);
            //Act
            var result = _dogController.Detail(id);
            //Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }

        // to test detele
        [Fact]
        public void DogController_DeteleDog_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var id = 1;
            var dog = A.Fake<Dog>();
            A.CallTo(() => _dogRepository.Delete(dog));
            //Act
            var result = _dogController.DeleteDog(id);
            //Assert - Object check actions
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}