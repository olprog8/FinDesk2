
using FinDesk.Domain.Entities.Base.Interfaces;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinDesk.Domain.Entities.Base
{

    /// <summary>Именованная сущность</summary>
    public abstract class NamedEntity: BaseEntity, INamedEntity
    {
        [Required, StringLength(300)]
        public string Name { get; set; }
    }
}
