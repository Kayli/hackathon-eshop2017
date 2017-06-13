using PNI.DDD.Core;
using PNI.EShop.Core;

namespace PNI.EShop.Domain
{
    public class ModelType : ValueObject<ModelType>
    {
        private readonly ModelTypeDefinition _modelType;

        public ModelType(ModelTypeDefinition modelType)
        {
            _modelType = modelType;
        }

        protected override bool EqualsCore(ModelType other)
        {
            return _modelType.Equals(other._modelType);
        }

        protected override int GetHashCodeCore()
        {
            return _modelType.GetHashCode() ^ 333;
        }

        public override ValueObject<ModelType> Value()
        {
            return new ModelType(_modelType);
        }
    }
}