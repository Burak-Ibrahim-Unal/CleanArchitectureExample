using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingComExample.Domain.Apartments
{
    public record Money(decimal Amount, Currency Currency)
    {
        public static Money operator +(Money first, Money second)
        {
            if (first.Currency != second.Currency)
            {
                throw new InvalidOperationException("Currencies have to be equal");
            }
            return new Money(first.Amount + second.Amount, first.Currency);
        }   
        
        public static Money ZeroMoney() => new (0, Currency.None);
        public static Money ZeroMoney(Currency currency) => new (0, currency);
        
        public bool IsZero() => this == ZeroMoney();
    }
}
