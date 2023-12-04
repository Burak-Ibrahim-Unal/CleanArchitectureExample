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
        public string Name  { get; set; }
        public string Desrciption  { get; set; }
        public string Country  { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }  
        public decimal CleaningFeeAmount { get; set; }
        public string CleaningFeeCurrency { get; set; }
        public DateTime? LastBookedOnUtc { get; set; }
        public List<Amenity> Amenities { get; set; }

        public Apartment(Guid id) 
            : base(id)
        {
                
        }

    }
}
