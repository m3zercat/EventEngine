using System;
using CodeConcepts.EventEngine.Api.Contracts;
using CodeConcepts.EventEngine.IsaPolicy.Contracts.CoreViews.PolicyFundUnitBalanceView;

namespace CodeConcepts.EventEngine.IsaPolicy.Contracts.Interfaces.CoreQueries
{
    public interface IPolicyFundUnitBalanceQuery : IQuery
    {
        PolicyFundUnitBalanceView Read(Guid contextId);
    }
}