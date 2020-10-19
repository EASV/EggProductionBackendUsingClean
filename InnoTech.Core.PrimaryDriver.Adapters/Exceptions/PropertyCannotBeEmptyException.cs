using System;
using System.IO;

namespace InnoTech.Core.PrimaryDriverAdapters.Exceptions
{
    public class PropertyCannotBeEmptyException: ArgumentOutOfRangeException
    {
        public PropertyCannotBeEmptyException(string propertyName = "Unknown"): 
            base(null, $"{propertyName} needs to be a value") {
        }
    }
}