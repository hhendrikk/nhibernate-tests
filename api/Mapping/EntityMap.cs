using api.Entities;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace api.Mapping
{
    public abstract class EntityMap<T> : ClassMapping<T> where T : Entity
    {
        public EntityMap()
        {
            Id(e => e.Id, m =>
            {
                m.Column("id");
                m.Type(NHibernateUtil.Int64);
                m.Generator(Generators.Native);
            });
        }
    }
}