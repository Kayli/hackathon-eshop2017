using System;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class DateValue : ValueObject<DateValue>
    {
        private readonly DateTimeOffset _value;

        public DateValue(DateTimeOffset value)
        {
            _value = value;
        }

        protected override bool EqualsCore(DateValue other)
        {
            return _value.Equals(other._value);
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode() ^ 555;
        }

        public override DateValue Value()
        {
            return new DateValue(_value);
        }
    }
}