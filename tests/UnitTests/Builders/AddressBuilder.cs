using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.UnitTests.Builders;

public class AddressBuilder
{
    private Address _address;
    public static string TestStreet => "123 Main St.";
    public static string TestCity => "Kent";
    public static string TestState => "OH";
    public static string TestCountry => "USA";
    public static string TestZipCode => "44240";

    public AddressBuilder()
    {
        _address = WithDefaultValues();
    }
    public Address Build()
    {
        return _address;
    }
    public Address WithDefaultValues()
    {
        _address = new Address(TestStreet, TestCity, TestState, TestCountry, TestZipCode);
        return _address;
    }
}
