using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingComExample.Domain.Abstractions
{
   
    public abstract class Entity
    { 
        private readonly List<IDomanEvent> _domainEvents = new();
        
        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public IReadOnlyList<IDomanEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }
        
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        
        public void RaiseDomainEvent(IDomanEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
