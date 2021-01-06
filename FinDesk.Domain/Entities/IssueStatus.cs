using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;
using FinDesk.Domain.Entities.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinDesk.Domain.Entities
{
    public class IssueStatus : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        //Навигационное свойство (связывание)
        public virtual ICollection<BaseIssue> BaseIssues { get; set; }

    }

}
