using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
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

        public override ColorValue Value()
        {
            return new ColorValue(_color);
        }
    }
}