using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using payme.Core.Common.Exceptions;

namespace payme.Application.Extensions
{
    public static class StringExtensions
    {
        public static bool IsTheSame(this string value, string valueToCompare)
        {
            if ((string.IsNullOrEmpty(value)) || (string.IsNullOrEmpty(valueToCompare)))
                throw new CustomException();
            return value.Trim().ToLower() == valueToCompare.Trim().ToLower();
        }
        public static T ParseEnum<T>(this string value)
        {
        return (T)Enum.Parse(typeof(T), value, true);
        }

    }
}
