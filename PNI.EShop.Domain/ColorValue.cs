using PNI.DDD.Core;

namespace PNI.EShop.Domain
{
    public class ColorValue : ValueObject<ColorValue>
    {
        private readonly ColorDefinition _color;

        public ColorValue(ColorDefinition color)
        {
            _color = color;
        }

        protected override bool EqualsCore(ColorValue other)
        {
            return _color.Equals(other._color);
        }

        protected override int GetHashCodeCore()
        {
            return _color.GetHashCode() ^ 444;
        }

        public override ValueObject<ColorValue> Value()
        {
            return new ColorValue(_color);
        }
    }
}