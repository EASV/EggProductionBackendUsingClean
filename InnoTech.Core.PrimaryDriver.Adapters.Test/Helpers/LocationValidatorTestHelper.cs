using System;
using FluentAssertions;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriverAdapters.Validators;
using InnoTech.Core.PrimaryDriverPorts.Validators;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Helpers
{
    public class LocationValidatorTestHelper
    {
        public void DefaultValidation<TE>(Location location = null, string message = null) where TE : Exception
        {
            Action action = () => LocationValidator().DefaultValidation(location);
            if (message != null)
            {
                action.Should().Throw<TE>()
                    .And.Message.Should().Be(message);
            }
            else
            {
                action.Should().Throw<TE>();
            }
            
        }

        private ILocationValidator LocationValidator()
        {
            return new LocationValidator();
        }
    }
}