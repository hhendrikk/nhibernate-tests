namespace api.Entities
{
    public class Address : Entity
    {
        public virtual string Lines { get; protected set; }
        public virtual string City { get; protected set; }
        public virtual string State { get; protected set; }
        public virtual string ZipCode { get; protected set; }

        protected Address()
        {

        }

        public Address(string lines, string city, string state, string zipCode)
            : this()
        {
            Lines = lines;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}