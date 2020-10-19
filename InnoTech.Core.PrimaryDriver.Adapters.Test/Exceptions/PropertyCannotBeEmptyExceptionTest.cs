using System;
using System.IO;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Exceptions
{
    public class PropertyInvalidExceptionTest
    {
        [Fact]
        public void NewPropertyInvalidException_WithNoParam_ReturnsUnknownPropertyMessage()
        {
            ArgumentOutOfRangeException ex = new PropertyCannotBeEmptyException();
                Assert.Equal("Unknown Parameter Cannot Be Null", ex.Message);
        }
        
        [Fact]
        public void NewPropertyInvalidException_WithParamNameAsString_ReturnsParamNamePropertyMessage()
        {
            ArgumentOutOfRangeException ex = new PropertyCannotBeEmptyException("Name");
            Assert.Equal("Name Parameter Cannot Be Null", ex.Message);
        }
    }
}