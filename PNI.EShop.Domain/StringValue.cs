using PNI.DDD.Core;

namespace PNI.EShop.Domain
{
    public class StringValue : ValueObject<StringValue>
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        protected override bool EqualsCore(StringValue other)
        {
            return _value.Equals(other._value);
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode() ^ 666;
        }

        public override ValueObject<StringValue> Value()
        {
            return new StringValue(_value);
        }
    }
}