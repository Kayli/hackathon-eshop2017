using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
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

        public override StringValue Value()
        {
            return new StringValue(_value);
        }

        public override string ToString()
        {
            return _value.Substring(0);
        }
    }
}