using System.Collections.Generic;
using NWS.APIClient.Extensions;
using Xunit;

namespace NWS.APIClient.Tests.UtilityTests
{
    public class StringExtensionsTests
    {
        [Theory]
        [MemberData(nameof(GetValidWFOs))]
        public void Valid_Strings_Return_True(string validString)
        {
            Assert.True(validString.IsValidWFO());
        }

        [Theory]
        [MemberData(nameof(GetInvalidWFOs))]
        public void InValid_Strings_Return_False(string invalidString)
        {
            Assert.False(invalidString.IsValidWFO());
        }

        public static IEnumerable<object[]> GetValidWFOs()
        {
            yield return new object[] { "STU" };
            yield return new object[] { "NH1" };
            yield return new object[] { "NH2" };
            yield return new object[] { "ONA" };
            yield return new object[] { "ONP" };
            yield return new object[] { "onp" };
        }

        public static IEnumerable<object[]> GetInvalidWFOs()
        {
            yield return new object[] { "PPP" };
            yield return new object[] { "PA" };
            yield return new object[] { "P" };
            yield return new object[] { "!@#" };
            yield return new object[] { "123" };
            yield return new object[] { "" };
            yield return new object[] { "    " };
            yield return new object[] { string.Empty };
            yield return new object[] { null };
        }
    }
}