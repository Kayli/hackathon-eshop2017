using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class ProductModel : ValueObject<ProductModel>
    {
        public ColorValue Color { get; }
        public ModelType Type { get; }
        public DateValue CreatedAt { get; }
        public DateValue UpdatedAt { get; }

        public ProductModel(ColorValue color, ModelType type, DateValue createdAt, DateValue updatedAt)
        {
            Color = color.Value();
            Type = type.Value();
            CreatedAt = createdAt.Value();
            UpdatedAt = updatedAt.Value();
        }

        protected override bool EqualsCore(ProductModel other)
        {
            return Color.Equals(other.Color) &&
                   Type.Equals(other.Type) &&
                   CreatedAt.Equals(other.CreatedAt) &&
                   UpdatedAt.Equals(other.UpdatedAt);
        }

        protected override int GetHashCodeCore()
        {
            return Color.GetHashCode() ^ 123 &
                   Type.GetHashCode() ^ 223 &
                   CreatedAt.GetHashCode() ^ 523 &
                   UpdatedAt.GetHashCode() ^ 623;
        }

        public override ProductModel Value()
        {
            return new ProductModel(Color, Type, CreatedAt, UpdatedAt);
        }
    }
}