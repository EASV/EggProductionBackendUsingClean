using System;

namespace InnoTech.Core.PrimaryDriverAdapters.Exceptions
{
    public class ParameterCannotBeNullException: NullReferenceException
    {
        public ParameterCannotBeNullException(string parameterName = "Unknown") :
            base($"{parameterName} Parameter Cannot be null")
        {
            
        }
    }
}