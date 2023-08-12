using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using FluentAssertions;
using Moq;
using Xunit;

namespace CarWorkshop.Application.Mappings.Tests
{
    public class CarWorkshopMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarWorskhopDtoToCarWorkshop()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg => 
             cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarWorkshopDto() 
            { 
                City = "City",
                PhoneNumber = "123123123",
                PostalCode = "12-123",
                Street = "Street"
            };

            // act
            var result = mapper.Map<Domain.Entities.CarWorkshop>(dto);

            // assert
            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.PostalCode.Should().Be(dto.PostalCode);
            result.ContactDetails.Street.Should().Be(dto.Street);
        }

        [Fact()]
        public void MappingProfile_ShouldMaCarWorkshoppToCarWorskhopDto()
        {
            // arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(cfg =>
             cfg.AddProfile(new CarWorkshopMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carWorkshop = new Domain.Entities.CarWorkshop() 
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new Domain.Entities.CarWorkshopContactDetails()
                {
                    City = "City",
                    PhoneNumber = "123123123",
                    PostalCode = "12-123",
                    Street = "Street"
                }
            };

            // act
            var result = mapper.Map<CarWorkshopDto>(carWorkshop);

            // assert
            result.Should().NotBeNull();
            result.IsEditable.Should().BeTrue();
            result.City.Should().Be(carWorkshop.ContactDetails.City);
            result.PhoneNumber.Should().Be(carWorkshop.ContactDetails.PhoneNumber);
            result.PostalCode.Should().Be(carWorkshop.ContactDetails.PostalCode);
            result.Street.Should().Be(carWorkshop.ContactDetails.Street);
        }
    }
}