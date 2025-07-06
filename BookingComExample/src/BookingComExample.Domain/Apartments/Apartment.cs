using BookingComExample.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingComExample.Domain.Apartments
{
    public sealed class Apartment : Entity
    {
        public Apartment(Guid id) : base(id)
        {

        }

        public Name Name { get; private set; }
        public Desrciption Desrciption { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; set; }
        public Money CleaningFee { get; set; }
        public DateTime? LastBookedOnUtc { get; private set; }
        public List<Amenity> Amenities { get; private set; }
    }
}
