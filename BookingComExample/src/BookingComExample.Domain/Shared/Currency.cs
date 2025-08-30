using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingComExample.Domain.Shared
{
    public record Currency
    {
        public static readonly Currency Usd = new Currency("USD");
        public static readonly Currency Eur = new Currency("EUR");
        public static readonly Currency Tl = new Currency("TL");
        internal static readonly Currency None = new Currency("");

        private Currency(string code) => Code = code;

        public string Code { get; init; }

        public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, Eur, Tl };

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ?? throw new ApplicationException("The Currency code is invalid");
        }
    }
}
