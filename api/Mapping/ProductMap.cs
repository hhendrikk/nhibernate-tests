using api.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace api.Mapping
{
    public class ProductMap : EntityMap<Product>
    {
        public ProductMap()
        {
            Table("Product");

            Discriminator(p => p.Column("productType"));

            NaturalId(map => {
                map.Property(p => p.Name, m => {
                    m.NotNullable(true);
                });
            }, x => x.Mutable(true));

            Property(p => p.Name, m =>
            {
                m.Column("name");
                m.Type(NHibernateUtil.String);
                m.Length(100);
                m.NotNullable(true);
            });

            Property(p => p.Description, m =>
            {
                m.Column("description");
                m.Type(NHibernateUtil.String);
                m.Length(255);
                m.NotNullable(true);
            });

            Property(p => p.UnitPrice, m =>
            {
                m.Column("unitPrice");
                m.Type(NHibernateUtil.Currency);
                m.NotNullable(true);
            });
        }
    }
}