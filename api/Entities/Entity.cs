using System;

namespace api.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
    }
}