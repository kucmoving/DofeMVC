using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PetCafe_Remake_.Data;
using PetCafe_Remake_.Models;
using PetCafe_Remake_.Models.Data.Enum;
using PetCafe_Remake_.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCafe_Remake_.Tests.Repository
{
    public class ClubRepositoryTests
    {
        private async Task<ApplicationDbContext> GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Dogs.CountAsync() < 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    //copy the formart in seedata
                    databaseContext.Dogs.Add(
                      new Dog()
                      {
                          DogName = "ABC",
                          Image = "https://www...",
                          Introduction = "dog for unit test",
                          DogCategory = DogCategory.ToyGroup,
                          VisitTime = new VisitTime()
                          {
                              Day = "Sunday",
                              TimeFrame = "Afternoon"
                          }
                      });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }


        //check add 
        [Fact]
        public async void DogRepository_Add_ReturnsBool()
        {
            //Arrange
            var dog = new Dog()
            {
                DogName = "ABC",
                Image = "https://www...",
                Introduction = "dog for unit test",
                DogCategory = DogCategory.ToyGroup,
                VisitTime = new VisitTime()
                {
                    Day = "Sunday",
                    TimeFrame = "Afternoon"
                }
            };
            var dbContext = await GetDbContext();
            var dogRepository = new DogRepository(dbContext);
            //Act
            var result = dogRepository.Add(dog);
            //Assert
            result.Should().BeTrue();
        }

        //check add 
        [Fact]
        public async void DogRepository_Update_ReturnsBool()
        {
            //Arrange
            var dog = new Dog()
            {
                DogName = "ABC",
                Image = "https://www...",
                Introduction = "dog for unit test",
                DogCategory = DogCategory.ToyGroup,
                VisitTime = new VisitTime()
                {
                    Day = "Sunday",
                    TimeFrame = "Afternoon"
                }
            };
            var dbContext = await GetDbContext();
            var dogRepository = new DogRepository(dbContext);
            //Act
            var result = dogRepository.Update(dog);
            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async void DogRepository_GetByIdAsyncNoTracking_ReturnsDog()
        {            //Arrange
            var id = 1;
            var dbContext = await GetDbContext();
            var dogRepository = new DogRepository(dbContext);
            //Act
            var result = dogRepository.GetByIdAsyncNoTracking(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<Dog>>();
        }
    }
}

