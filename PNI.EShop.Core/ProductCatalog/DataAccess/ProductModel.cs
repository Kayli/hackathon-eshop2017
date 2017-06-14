using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class ProductModel : ValueObject<ProductModel>
    {
        private readonly ColorValue _color;
        private readonly ModelType _type;
        private readonly DateValue _createdAt;
        private readonly DateValue _updatedAt;

        public ProductModel(ColorValue color, ModelType type, DateValue createdAt, DateValue updatedAt)
        {
            _color = color.Value();
            _type = type.Value();
            _createdAt = createdAt.Value();
            _updatedAt = updatedAt.Value();
        }

        protected override bool EqualsCore(ProductModel other)
        {
            return _color.Equals(other._color) &&
                   _type.Equals(other._type) &&
                   _createdAt.Equals(other._createdAt) &&
                   _updatedAt.Equals(other._updatedAt);
        }

        protected override int GetHashCodeCore()
        {
            return _color.GetHashCode() ^ 123 &
                   _type.GetHashCode() ^ 223 &
                   _createdAt.GetHashCode() ^ 523 &
                   _updatedAt.GetHashCode() ^ 623;
        }

        public override ProductModel Value()
        {
            return new ProductModel(_color, _type, _createdAt, _updatedAt);
        }
    }
}