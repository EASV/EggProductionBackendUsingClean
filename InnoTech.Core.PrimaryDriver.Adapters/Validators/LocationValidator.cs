using System;
using InnoTech.Core.Entity;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;

namespace InnoTech.Core.PrimaryDriverAdapters.Validators
{
    public class LocationValidator
    {
        public void DefaultValidation(Location location)
        {
            if (location == null)
            {
                throw new ParameterCannotBeNullException("Location");
            }
            if (string.IsNullOrEmpty(location.Name))
            {
                throw new PropertyCannotBeEmptyException("Name");
            }

            if (location.Name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Name Must be 2 or more Characters");
            }
        }
    }
}