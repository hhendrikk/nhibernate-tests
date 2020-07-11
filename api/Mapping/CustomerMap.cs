using api.Entities;
using NHibernate;

namespace api.Mapping
{
    public class CustomerMap : EntityMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");

            Property(p => p.Name, m =>
            {
                m.Column("name");
                m.NotNullable(true);
            });

            Component(c => c.BillingAddress, m =>
            {
                m.Property(p => p.Lines, x =>
                {
                    x.Column("billingLines");
                    x.NotNullable(true);
                });
                m.Property(p => p.City, x =>
                {
                    x.Column("billingCity");
                    x.NotNullable(true);
                });
                m.Property(p => p.State, x =>
                {
                    x.Column("billingState");
                    x.NotNullable(true);
                });
                m.Property(p => p.ZipCode, x =>
                {
                    x.Column("billingZipCode");
                    x.NotNullable(true);
                });
            });

            Component(c => c.ShippingAddress, m =>
            {
                m.Property(p => p.Lines, x =>
                {
                    x.Column("shippingLines");
                    x.NotNullable(true);
                });
                m.Property(p => p.City, x =>
                {
                    x.Column("shippingCity");
                    x.NotNullable(true);
                });
                m.Property(p => p.State, x =>
                {
                    x.Column("shippingState");
                    x.NotNullable(true);
                });
                m.Property(p => p.ZipCode, x =>
                {
                    x.Column("shippingZipCode");
                    x.NotNullable(true);
                });
            });
        }
    }
}