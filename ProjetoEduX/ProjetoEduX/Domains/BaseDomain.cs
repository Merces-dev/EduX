using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEduX.Domains
{
    public abstract class BaseDomain
    {
        public Guid Id { get; private set; }

        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
