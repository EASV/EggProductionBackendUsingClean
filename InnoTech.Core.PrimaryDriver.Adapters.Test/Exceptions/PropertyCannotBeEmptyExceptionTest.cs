using System;
using System.IO;
using FluentAssertions;
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
            Action action = () => throw new PropertyCannotBeEmptyException();
            action.Should()
                .Throw<PropertyCannotBeEmptyException>()
                .And.ParamName.Should().Be("Unknown needs to be a value");
        }
        
        [Fact]
        public void NewPropertyInvalidException_WithParamNameAsString_ReturnsParamNamePropertyMessage()
        {
            Action action = () => throw new PropertyCannotBeEmptyException("Name");
            action.Should()
                .Throw<PropertyCannotBeEmptyException>()
                .And.ParamName.Should().Be("Name needs to be a value");
        }
    }
}