using api.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace api.Mapping
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Id(p => p.Id, m =>
            {
                m.Column("id");
                m.Type<Int64Type>();
                m.Generator(Generators.Native);
            });

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