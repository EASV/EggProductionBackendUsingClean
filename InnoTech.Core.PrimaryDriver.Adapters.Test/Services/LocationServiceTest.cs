using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using Moq;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        private readonly LocationServiceTestHelper _helper;

        public LocationServiceTest()
        {
            _helper = new LocationServiceTestHelper();
        }
        
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationRepository_ThrowsNullReferenceException()
        {
            _helper.CreateInvalid<ParameterCannotBeNullException>(
                message: "LocationRepository Parameter Cannot be null");
        }
        
        [Fact]
        public void CreateNewLocationServiceOfTypeILocationService_WithNullAsILocationValidator_ThrowsNullReferenceException()
        {
            _helper.CreateInvalid<ParameterCannotBeNullException>(
                repository: new Mock<ILocationRepository>().Object,
                message: "LocationValidator Parameter Cannot be null");
        }

        [Fact]
        public void Create_WithLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOneTime()
        {
            var validatorMock = _helper.LocationValidatorMock();
            var location = _helper.CreateVerify(validator: validatorMock.Object);
            validatorMock.Verify(lm => lm.DefaultValidation(location), Times.Once);
        }
    }
}