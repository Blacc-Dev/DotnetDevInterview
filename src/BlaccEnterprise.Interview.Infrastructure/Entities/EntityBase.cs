namespace BlaccEnterprise.Interview.Infrastructure.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
        }

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase;

            if (ReferenceEquals(this, compareTo)) 
                return true;

            if (compareTo is null) 
                return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}