using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Validators;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Validators
{
    public class LocationValidatorTest
    {
        private LocationValidatorTestHelper _locationValidatorTestHelper;
        private LocationTestHelper _locationTestHelper;

        public LocationValidatorTest()
        {
            _locationValidatorTestHelper = new LocationValidatorTestHelper();
            _locationTestHelper = new LocationTestHelper();
        }
        [Fact]
        public void DefaultValidation_WithNullLocation_ThrowsNewParameterCannotBeNullException()
        {
            _locationValidatorTestHelper.DefaultValidation<ParameterCannotBeNullException>();
        }
        
        [Fact]
        public void DefaultValidation_WithEmptyLocationName_ThrowsPropertyCannotBeEmptyException()
        {
             _locationValidatorTestHelper
                 .DefaultValidation<PropertyCannotBeEmptyException>(
                     _locationTestHelper.Location(), 
                     "Name needs to be a value");
        }
        
        [Fact]
        public void DefaultValidation_WithLocationNameLessThen2Characters_ThrowsArgumentOutOfRangeException()
        {
            _locationValidatorTestHelper
                .DefaultValidation<ArgumentOutOfRangeException>(
                    _locationTestHelper.Location("A"),
                    "Name Must be 2 or more Characters");
        }
    }
}