using System;
using PNI.DDD.Core;

namespace PNI.EShop.Domain
{
    public class DateValue : ValueObject<DateValue>
    {
        private readonly DateTime _value;

        public DateValue(DateTime value)
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

        public override ValueObject<DateValue> Value()
        {
            return new DateValue(_value);
        }
    }
}