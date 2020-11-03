using System;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Test.Helpers.Locations;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Validators
{
    public class LocationValidatorTest
    {
        #region Constructor and Properties

        private readonly LocationValidatorTestHelper _locationValidatorTestHelper;
        private readonly LocationEntityTestHelper _locationEntityTestHelper;

        public LocationValidatorTest()
        {
            _locationValidatorTestHelper = new LocationValidatorTestHelper();
            _locationEntityTestHelper = new LocationEntityTestHelper();
        }

        #endregion

        #region Null Location

        [Fact]
        public void DefaultValidation_WithNullLocation_ThrowsNewParameterCannotBeNullException()
        {
            _locationValidatorTestHelper.DefaultValidation<ParameterCannotBeNullException>();
        }

        #endregion

        #region Id

        [Theory]
        [InlineData(-1)]
        [InlineData(-5000)]
        [InlineData(int.MinValue)]
        public void DefaultValidation_WithLocationWithNegativeId_ThrowsArgumentOutOfRangeException(int id)
        {
            _locationValidatorTestHelper
                .DefaultValidation<ArgumentOutOfRangeException>(
                    _locationEntityTestHelper.LocationWithoutId(id), "ID needs to 0 or more");
        }

        #endregion

        #region Name

        
        [Fact]
        public void DefaultValidation_WithEmptyLocationName_ThrowsPropertyCannotBeEmptyException()
        {
            _locationValidatorTestHelper
                .DefaultValidation<PropertyCannotBeEmptyException>(
                    _locationEntityTestHelper.LocationWithoutName(), "Name needs to be a value");
        }
        
        [Fact]
        public void DefaultValidation_WithLocationNameLessThen2Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutName("A"),"Name Must be 2 or more Characters");
        }
        
        [Fact]
        public void DefaultValidation_WithLocationNameAbove20Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutName("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"),
                "Name Must less then 20 Characters");
        }

        #endregion
        
        #region Address

        [Fact]
        public void DefaultValidation_WithEmptyLocationAddress_ThrowsPropertyCannotBeEmptyException()
        {
            _locationValidatorTestHelper
                .DefaultValidation<PropertyCannotBeEmptyException>(
                    _locationEntityTestHelper.LocationWithoutAddress(), 
                    "Address needs to be a value");
        }

        [Fact]
        public void DefaultValidation_WithLocationAddressLessThen4Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutAddress("A"),"Address Must be 4 or more Characters");
        }
        
        [Fact]
        public void DefaultValidation_WithLocationAddressAbove100Characters_ThrowsArgumentOutOfRangeException()
        {
            var charsAbove100 = "";
            for (int i = 0; i < 101; i++)
            {
                charsAbove100 += "A";
            }
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutAddress(charsAbove100),
                "Address Must less then 100 Characters");
        }

        #endregion
     
        #region Owner

        [Fact]
        public void DefaultValidation_WithEmptyLocationOwner_ThrowsPropertyCannotBeEmptyException()
        {
            _locationValidatorTestHelper
                .DefaultValidation<PropertyCannotBeEmptyException>(
                    _locationEntityTestHelper.LocationWithoutOwner(""), 
                    "Owner needs to be a value");
        }

        [Fact]
        public void DefaultValidation_WithLocationOwnerLessThen2Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutOwner("A"),"Owner Must be 2 or more Characters");
        }
        
        [Fact]
        public void DefaultValidation_WithLocationOwnerAbove20Characters_ThrowsArgumentOutOfRangeException()
        {
            var charsAbove20 = "";
            for (int i = 0; i < 21; i++)
            {
                charsAbove20 += "A";
            }
            _locationValidatorTestHelper.DefaultValidation<ArgumentOutOfRangeException>(
                _locationEntityTestHelper.LocationWithoutOwner(charsAbove20),
                "Owner Must less then 20 Characters");
        }

        #endregion

    }
}