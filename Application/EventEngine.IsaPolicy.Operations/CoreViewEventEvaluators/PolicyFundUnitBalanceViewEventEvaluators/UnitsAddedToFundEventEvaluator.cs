using CodeConcepts.EventEngine.Contracts.Interfaces;
using CodeConcepts.EventEngine.IsaPolicy.Contracts.CoreViews.PolicyFundUnitBalanceView;
using CodeConcepts.EventEngine.IsaPolicy.Contracts.Events;

namespace CodeConcepts.EventEngine.IsaPolicy.Operations.CoreViewEventEvaluators.PolicyFundUnitBalanceViewEventEvaluators
{
    public class UnitsAddedToFundEventEvaluator : IEventEvaluator<UnitsAddedToFundEvent, PolicyFundUnitBalanceView>
    {
        public void Evaluate(PolicyFundUnitBalanceView view, UnitsAddedToFundEvent @event)
        {
            var allocation = new FundAllocationBalance
            {
                UnitBalance = @event.Units,
                PortionId = @event.PortionId,
                FundId = @event.FundId
            };
            view.FundAllocations.Add(allocation);
        }
    }
}