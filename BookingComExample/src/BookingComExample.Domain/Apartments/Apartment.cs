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
        public Apartment(
            Guid id,
            Name name,
            Desrciption desrciption,
            Address address,
            Money price,
            Money cleaningFee,
            List<Amenity> amenities
            ) : base(id)
        {
            Name = name;
            Desrciption = desrciption;
            Address = address;
            Price = price;
            CleaningFee = cleaningFee;
            Amenities = amenities;
        }

        public Name Name { get; private set; }
        public Desrciption Desrciption { get; private set; }
        public Address Address { get; private set; }
        public Money Price { get; set; }
        public Money CleaningFee { get; set; }
        public DateTime? LastBookedOnUtc { get; internal set; }
        public List<Amenity> Amenities { get; private set; }
    }
}
