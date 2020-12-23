
using FinDesk.Domain.Entities.Base.Interfaces;

namespace FinDesk.Domain.Entities.Base
{

    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity: BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }
}
