namespace PNI.EShop.Core.ProductCatalog.Data
{
    public class ColorValue : ValueObject<ColorValue>
    {
        public ColorDefinition Color { get; }

        public ColorValue(ColorDefinition color)
        {
            Color = color;
        }

        protected override bool EqualsCore(ColorValue other)
        {
            return Color.Equals(other.Color);
        }

        protected override int GetHashCodeCore()
        {
            return Color.GetHashCode() ^ 444;
        }

        public override ColorValue Value()
        {
            return new ColorValue(Color);
        }
    }
}