using System;
using System.Collections.Generic;
using CodeConcepts.EventEngine.IsaPolicy.DataAccess.Interfaces;
using CodeConcepts.EventEngine.IsaPolicy.Views.Queries.Interfaces;

namespace CodeConcepts.EventEngine.IsaPolicy.Views.Queries
{
    public class PolicyEventContextIdQuery : IPolicyEventContextIdQuery
    {
        private readonly IIsaPolicyEventStoreRepository _eventStore;

        public PolicyEventContextIdQuery(IIsaPolicyEventStoreRepository eventStore)
        {
            _eventStore = eventStore;
        }

        public Guid? GeteventContextId(string policyNumber)
        {
            var contextIds = _eventStore.FindContextIds(policyNumber);
            return contextIds;
        }

        public IEnumerable<Guid> GeteventContextId(int clientId)
        {
            var contextIds = _eventStore.FindContextIds(clientId);
            return contextIds;
        }
    }
}