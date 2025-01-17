using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.UnitTests.Builders;

public class OrderBuilder
{
    private Order _order;
    public static string TestBuyerId => "12345";
    public static int TestCatalogItemId => 234;
    public static string TestProductName => "Test Product Name";
    public static string TestPictureUri => "http://test.com/image.jpg";
    public decimal TestUnitPrice { get; set; } = 1.23m;
    public int TestUnits { get; set; } = 3;
    public CatalogItemOrdered TestCatalogItemOrdered { get; }

    public OrderBuilder()
    {
        TestCatalogItemOrdered = new CatalogItemOrdered(TestCatalogItemId, TestProductName, TestPictureUri);
        _order = WithDefaultValues();
    }

    public Order Build()
    {
        return _order;
    }

    public Order WithDefaultValues()
    {
        var orderItem = new OrderItem(TestCatalogItemOrdered, TestUnitPrice, TestUnits);
        var itemList = new List<OrderItem>() { orderItem };
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), itemList);
        return _order;
    }

    public Order WithNoItems()
    {
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), []);
        return _order;
    }

    public Order WithItems(List<OrderItem> items)
    {
        _order = new Order(TestBuyerId, new AddressBuilder().WithDefaultValues(), items);
        return _order;
    }
}
