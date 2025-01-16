﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications;

public class CustomerOrdersWithItemsSpecification
{
    private readonly string _buyerId = "TestBuyerId";
    private readonly Address _shipToAddress = new("Street", "City", "OH", "US", "11111");

    [Fact]
    [Trait("TestCategory", "CI")]
    public void ReturnsOrderWithOrderedItem()
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification(_buyerId);

        var result = GetTestCollection()
            .AsQueryable()
            .FirstOrDefault(spec.WhereExpressions.FirstOrDefault());

        Assert.NotNull(result);
        Assert.NotNull(result.OrderItems);
        Assert.Single(result.OrderItems);
        Assert.NotNull(result.OrderItems.FirstOrDefault().ItemOrdered);
    }

    [Fact]
    [Trait("TestCategory", "CI")]
    public void ReturnsAllOrderWithAllOrderedItem()
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification(_buyerId);

        var result = GetTestCollection()
            .AsQueryable()
            .Where(spec.WhereExpressions.FirstOrDefault())
            .ToList();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Single(result[0].OrderItems);
        Assert.NotNull(result[0].OrderItems.FirstOrDefault().ItemOrdered);
        Assert.Equal(2, result[1].OrderItems.Count);
        Assert.NotNull(result[1].OrderItems.ToList()[0].ItemOrdered);
        Assert.NotNull(result[1].OrderItems.ToList()[1].ItemOrdered);
    }

    public List<Order> GetTestCollection()
    {
        var ordersList = new List<Order>
        {
            new(_buyerId, _shipToAddress,
            [
                new OrderItem(new CatalogItemOrdered(1, "Product1", "testurl"), 10.50m, 1)
            ]),
            new(_buyerId, _shipToAddress,
            [
                new OrderItem(new CatalogItemOrdered(2, "Product2", "testurl"), 15.50m, 2),
                new OrderItem(new CatalogItemOrdered(2, "Product3", "testurl"), 20.50m, 1)
            ])
        };

        return ordersList;
    }
}
