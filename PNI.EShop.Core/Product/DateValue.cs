using System;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class DateValue : ValueObject<DateValue>
    {
        public DateTimeOffset Date { get; }

        public DateValue(DateTimeOffset value)
        {
            Date = value;
        }

        protected override bool EqualsCore(DateValue other)
        {
            return Date.Equals(other.Date);
        }

        protected override int GetHashCodeCore()
        {
            return Date.GetHashCode() ^ 555;
        }

        public override DateValue Value()
        {
            return new DateValue(Date);
        }
    }
}