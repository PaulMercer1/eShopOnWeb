﻿using System.Collections.Generic;
using System.Linq;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Moq;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications;

public class BasketWithItems
{
    private readonly int _testBasketId = 123;
    private readonly string _buyerId = "Test buyerId";

    // tests with specifications can use an evaluator or just WhereExpressions.FirstOrDefault if only one
    private readonly SpecificationEvaluator<Basket> _evaluator = new();

    [Fact]
    [Trait("TestCategory", "CI")]
    public void MatchesBasketWithGivenBasketId()
    {
        var spec = new BasketWithItemsSpecification(_testBasketId);

        var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec)
                                .FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(_testBasketId, result.Id);
    }

    [Fact]
    [Trait("TestCategory", "CI")]
    public void MatchesNoBasketsIfBasketIdNotPresent()
    {
        var badBasketId = -1;
        var spec = new BasketWithItemsSpecification(badBasketId);

        var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec)
                    .Any();

        Assert.False(result);
    }

    [Fact]
    [Trait("TestCategory", "CI")]
    public void MatchesBasketWithGivenBuyerId()
    {
        var spec = new BasketWithItemsSpecification(_buyerId);

        var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec)
                    .FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(_buyerId, result.BuyerId);
    }

    [Fact]
    [Trait("TestCategory", "CI")]
    public void MatchesNoBasketsIfBuyerIdNotPresent()
    {
        var badBuyerId = "badBuyerId";
        var spec = new BasketWithItemsSpecification(badBuyerId);

        var result = _evaluator.GetQuery(GetTestBasketCollection().AsQueryable(), spec)
                                  .Any();

        Assert.False(result);
    }

    public List<Basket> GetTestBasketCollection()
    {
        var basket1Mock = new Mock<Basket>(_buyerId);
        basket1Mock.SetupGet(s => s.Id).Returns(1);
        var basket2Mock = new Mock<Basket>(_buyerId);
        basket2Mock.SetupGet(s => s.Id).Returns(2);
        var basket3Mock = new Mock<Basket>(_buyerId);
        basket3Mock.SetupGet(s => s.Id).Returns(_testBasketId);

        return
        [
            basket1Mock.Object,
            basket2Mock.Object,
            basket3Mock.Object
        ];
    }
}
