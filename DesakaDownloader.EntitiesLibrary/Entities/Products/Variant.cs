namespace DesakaDownloader.EntitiesLibrary.Entities.Products
{
    public class Variant : IComparable<Variant>, IEquatable<Variant>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Availability { get; set; }
        public override string ToString()
        {
            return String.Format("Name:{0},Value:{1},", Name, Value);
        }

        public Variant(string name = "", string value = "", bool available = true)
        {
            Name = name;
            Value = value;
            Availability = available;
        }
        public static bool operator ==(Variant a, Variant b)
        {

            return a.Name == b.Name && a.Value == b.Value;
        }
        public static bool operator !=(Variant a, Variant b)
        {

            return !(a.Name == b.Name && a.Value == b.Value);
        }

        public bool Equals(Variant v)
        {
          
            return Name == v.Name && Value == v.Value;

        }
        public override bool Equals(object obj)
        {
            return this.Equals((Variant)obj);

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(Variant other)
        {
            return String.Compare(this.ToString(), other.ToString());
        }
    }
}