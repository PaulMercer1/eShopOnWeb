using Microsoft.eShopWeb.Web.Extensions;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests;

public class GenerateBrandsCacheKey
{
    [Fact]
    [Trait("TestCategory", "CI")]
    public void ReturnsBrandsCacheKey()
    {
        var result = CacheHelpers.GenerateBrandsCacheKey();

        Assert.Equal("brands", result);
    }
}
