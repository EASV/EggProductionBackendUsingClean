using System;
using InnoTech.Core.PrimaryDriverAdapters.Exceptions;
using Xunit;

namespace InnoTech.Core.PrimaryDriver.Adapters.Test.Exceptions
{
    public class ParameterCannotBeNullExceptionTest
    {
        [Fact]
        public void NewExceptionOfTypeNullReference_WithNoParam_ReturnsParameterNamePlusCannotBeNullAsMessage()
        {
            NullReferenceException ex = new ParameterCannotBeNullException();
            Assert.Equal("Unknown Parameter Cannot be null", ex.Message);
        }
        
        [Fact]
        public void NewException_WithParamNameAsParameter_ReturnsParameterNameInMessage()
        {
            NullReferenceException ex = new ParameterCannotBeNullException("Location");
            Assert.Equal("Location Parameter Cannot be null", ex.Message);
        }
    }
}