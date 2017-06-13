namespace PNI.EShop.Core._Common
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        protected Entity(IIdentity<TId> id)
        {
            Id = id;
        }

        public IIdentity<TId> Id { get; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TId>;

            return !ReferenceEquals(compareTo, null) && ReferenceEquals(this, compareTo);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode()^793;
        }
    }
}