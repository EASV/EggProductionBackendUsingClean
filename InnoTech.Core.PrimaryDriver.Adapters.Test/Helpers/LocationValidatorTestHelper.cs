using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Validators;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationValidatorTestHelper
    {
        public void DefaultValidation<T>(Location location = null, string message = null) where T : Exception
        {
            Action action = () => LocationValidator().DefaultValidation(location);
            if (message != null)
            {
                action.Should().Throw<T>()
                    .And.Message.Should().Be(message);
            }
            else
            {
                action.Should().Throw<T>();
            }
            
        }

        public ILocationValidator LocationValidator()
        {
            return new LocationValidator();
        }
    }
}