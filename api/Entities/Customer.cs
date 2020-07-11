namespace api.Entities
{
    public class Customer : Entity
    {
        public virtual string Name { get; protected set; }
        public virtual Address BillingAddress { get; protected set; }
        public virtual Address ShippingAddress { get; protected set; }

        protected Customer()
        {

        }

        public Customer(string name, Address billingAddress,
            Address shippingAddress)
            : this()
        {
            Name = name;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
        }
    }
}