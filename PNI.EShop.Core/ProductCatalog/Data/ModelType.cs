namespace PNI.EShop.Core.ProductCatalog.Data
{
    public class ModelType : ValueObject<ModelType>
    {
        public ModelTypeDefinition ModelTypeDefinition { get; }

        public ModelType(ModelTypeDefinition modelTypeDefinition)
        {
            ModelTypeDefinition = modelTypeDefinition;
        }

        protected override bool EqualsCore(ModelType other)
        {
            return ModelTypeDefinition.Equals(other.ModelTypeDefinition);
        }

        protected override int GetHashCodeCore()
        {
            return ModelTypeDefinition.GetHashCode() ^ 333;
        }

        public override ModelType Value()
        {
            return new ModelType(ModelTypeDefinition);
        }
    }
}