﻿using System;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.CatalogItemTests;

public class UpdateDetails
{
    private readonly CatalogItem _testItem;
    private readonly int _validTypeId = 1;
    private readonly int _validBrandId = 2;
    private readonly string _validDescription = "test description";
    private readonly string _validName = "test name";
    private readonly decimal _validPrice = 1.23m;
    private readonly string _validUri = "/123";

    public UpdateDetails()
    {
        _testItem = new CatalogItem(_validTypeId, _validBrandId, _validDescription, _validName, _validPrice, _validUri);
    }

    [Fact]
    public void ThrowsArgumentExceptionGivenEmptyName()
    {
        var newValue = "";
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(newValue, _validDescription, _validPrice));
    }

    [Fact]
    public void ThrowsArgumentExceptionGivenEmptyDescription()
    {
        var newValue = "";
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, newValue, _validPrice));
    }

    [Fact]
    public void ThrowsArgumentNullExceptionGivenNullName()
    {
        Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(null, _validDescription, _validPrice));
    }

    [Fact]
    public void ThrowsArgumentNullExceptionGivenNullDescription()
    {
        Assert.Throws<ArgumentNullException>(() => _testItem.UpdateDetails(_validName, null, _validPrice));
    }

    [Theory]
    [InlineData(-1.23)]
    public void ThrowsArgumentExceptionGivenNonPositivePrice(decimal newPrice)
    {
        Assert.Throws<ArgumentException>(() => _testItem.UpdateDetails(_validName, _validDescription, newPrice));
    }
}
