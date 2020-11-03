using InnoTech.Core.InfratructurePorts.Repositories;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Test.Helpers.Locations;
using Moq;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Services
{
    public class LocationServiceTest
    {
        #region Constructor and Properties

        private readonly LocationServiceTestHelper _helper;

        public LocationServiceTest()
        {
            _helper = new LocationServiceTestHelper();
        }

        #endregion

        #region Create - Busines Logic

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


        #endregion
        
        #region Create - Busines Flow

        [Fact]
        public void Create_WithValidLocationParameter_ShouldCallILocationValidatorsDefaultValidationMethodOneTimeWithParam()
        {
            var validatorMock = _helper.LocationValidatorMock();
            var location = _helper.CreateVerify(validator: validatorMock.Object);
            validatorMock.Verify(locationValidator => locationValidator.DefaultValidation(location), Times.Once);
        }
        
        [Fact]
        public void Create_WithValidLocationParameter_ShouldCallIRepositoryAddMethodOneTimeWithParam()
        {
            var repositoryMock = _helper.LocationRepositoryMock();
            var location = _helper.CreateVerify(locationRepository: repositoryMock.Object);
            repositoryMock.Verify(locationRepository => locationRepository.Add(location), Times.Once);
        }

        #endregion
        
    }
}