namespace PNI.DDD.Core
{
    public abstract class Identity<T> : IIdentity<T>
    {
        protected Identity(T id)
        {
            Id = id;
        }

        public T Id { get; }
    }
}