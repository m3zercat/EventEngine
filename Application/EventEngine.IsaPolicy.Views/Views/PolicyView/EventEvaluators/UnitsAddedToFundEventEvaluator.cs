using System.Linq;
using CodeConcepts.EventEngine.Contracts.Interfaces;
using CodeConcepts.EventEngine.IsaPolicy.Contracts.Events;
using CodeConcepts.EventEngine.IsaPolicy.Views.Contracts.Views.PolicyView.Domain;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Views.PolicyView.EventEvaluators
{
    public class UnitsAddedToFundEventEvaluator : IEventEvaluator<UnitsAddedToFundEvent, Contracts.Views.PolicyView.Domain.PolicyView>
    {
        public void Evaluate(Contracts.Views.PolicyView.Domain.PolicyView view, UnitsAddedToFundEvent @event)
        {
            var allocation = new FundAllocation
            {
                Units = @event.Units,
                PortionId = @event.PortionId,
                ShadowUnits = @event.Units
            };
            var fund = view.Funds.SingleOrDefault(f => f.FundId == @event.FundId);
            if (fund == null)
            {
                fund = new Fund
                {
                    FundId = @event.FundId
                };
                view.Funds.Add(fund);
            }
            fund.Allocations.Add(allocation);
            fund.TotalUnits += @event.Units;
            fund.TotalShadowUnits += @event.Units;
        }
    }
}