﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications;

public class CatalogFilterPaginatedSpecification
{
    [Fact]
    [Trait("TestCategory", "CI")]
    public void ReturnsAllCatalogItems()
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification(0, 10, null, null);

        var result = GetTestCollection()
            .AsQueryable()
            .Where(spec.WhereExpressions.FirstOrDefault());

        Assert.NotNull(result);
        Assert.Equal(4, result.ToList().Count);
    }

    [Fact]
    [Trait("TestCategory", "CI")]
    public void Returns2CatalogItemsWithSameBrandAndTypeId()
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification(0, 10, 1, 1);

        var result = GetTestCollection()
            .AsQueryable()
            .Where(spec.WhereExpressions.FirstOrDefault());

        Assert.NotNull(result);
        Assert.Equal(2, result.ToList().Count);
    }

    private static List<CatalogItem> GetTestCollection()
    {
        var catalogItemList = new List<CatalogItem>
        {
            new(1, 1, "Item 1", "Item 1", 1.00m, "TestUri1"),
            new(1, 1, "Item 1.5", "Item 1.5", 1.50m, "TestUri1"),
            new(2, 2, "Item 2", "Item 2", 2.00m, "TestUri2"),
            new(3, 3, "Item 3", "Item 3", 3.00m, "TestUri3")
        };

        return catalogItemList;
    }
}
