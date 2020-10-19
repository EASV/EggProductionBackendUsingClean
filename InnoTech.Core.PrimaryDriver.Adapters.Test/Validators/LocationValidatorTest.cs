using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Validators
{
    public class LocationValidatorTest
    {
        [Fact]
        public void DefaultValidation_WithNullLocation_ThrowsNewParameterCannotBeNullException()
        {
            LocationValidator validator = new LocationValidator();
            Action action = () => validator.DefaultValidation(null as Location);
            action.Should().Throw<ParameterCannotBeNullException>();

        }
        
        [Fact]
        public void DefaultValidation_WithEmptyLocationName_ThrowsPropertyCannotBeEmptyException()
        {
            LocationValidator validator = new LocationValidator();
            var location = new Location();
            location.Name = "";
            Action action = () => validator.DefaultValidation(location as Location);
            action.Should()
                .Throw<PropertyCannotBeEmptyException>()
                .And.ParamName.Should().Be("Name needs to be a value");

        }
        
        [Fact]
        public void DefaultValidation_WithLocationNameLessThen2Characters_ThrowsArgumentOutOfRangeException()
        {
            LocationValidator validator = new LocationValidator();
            var location = new Location();
            location.Name = "A";
            Action action = () => validator.DefaultValidation(location as Location);
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .And.ParamName.Should().Be("Name Must be 2 or more Characters");

        }
    }
}