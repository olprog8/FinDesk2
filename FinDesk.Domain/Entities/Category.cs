using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;
using FinDesk.Domain.Entities.Base;

namespace FinDesk.Domain.Entities
{
    class Category : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int? ParentId { get; set; }
    }
}
