using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;

public class Buyer : BaseEntity, IAggregateRoot
{
    public string IdentityGuid { get; private set; }

    private readonly List<PaymentMethod> _paymentMethods = [];

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    private Buyer()
    {
        // required by EF
    }

    public Buyer(string identity) : this()
    {
        Guard.Against.NullOrEmpty(identity, nameof(identity));
        IdentityGuid = identity;
    }
}
