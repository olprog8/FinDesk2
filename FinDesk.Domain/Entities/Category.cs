using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;
using FinDesk.Domain.Entities.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinDesk.Domain.Entities
{
    //[Table("Brand")]
    public class Category : NamedEntity, IOrderedEntity
    {
        //[Table("Categories")]
        public int Order { get; set; }
        public int? ParentId { get; set; }

        //Связь один к одному
        [ForeignKey(nameof(ParentId))]
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<BaseIssue> BaseIssues { get; set; }
    }
}
