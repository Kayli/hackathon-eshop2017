using PNI.DDD.Core;

namespace PNI.EShop.Domain
{
    public class Model : ValueObject<Model>
    {
        private readonly ColorValue _color;
        private readonly ModelType _type;
        private readonly StringValue _name;
        private readonly StringValue _fileRelativePath;
        private readonly DateValue _createdAt;
        private readonly DateValue _updatedAt;

        public Model(ColorValue color, ModelType type, StringValue name, StringValue fileRelativePath, DateValue createdAt, DateValue updatedAt)
        {
            _color = color;
            _type = type;
            _name = name;
            _fileRelativePath = fileRelativePath;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        protected override bool EqualsCore(Model other)
        {
            return _color.Equals(other._color) &&
                   _type.Equals(other._type) &&
                   _name.Equals(other._name) &&
                   _fileRelativePath.Equals(other._fileRelativePath) &&
                   _createdAt.Equals(other._createdAt) &&
                   _updatedAt.Equals(other._updatedAt);
        }

        protected override int GetHashCodeCore()
        {
            return _color.GetHashCode() ^ 123 &
                   _type.GetHashCode() ^ 223 &
                   _name.GetHashCode() ^ 323 &
                   _fileRelativePath.GetHashCode() ^ 423 &
                   _createdAt.GetHashCode() ^ 523 &
                   _updatedAt.GetHashCode() ^ 623;
        }

        public override ValueObject<Model> Value()
        {
            return new Model(_color, _type, _name, _fileRelativePath, _createdAt, _updatedAt);
        }
    }
}