using System;
using System.Collections.Generic;
using System.Text;

using FinDesk.Domain.Entities.Base.Interfaces;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinDesk.Domain.Entities
{
    //[Table("BaseIssues")]
    public class BaseIssue: IBaseEntity
    {

        public int Id { get; set; }
        public string User { get; set; }

        public DateTime IssueTS { get; set; }

        public int IssueTypeId { get; set; }
        
        [ForeignKey(nameof(IssueTypeId))]
        public virtual IssueType IssueType { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }


        public int IssueStatusId { get; set; }

        [ForeignKey(nameof(IssueStatusId))]
        public virtual IssueStatus IssueStatus { get; set; }


        public string LongDescr { get; set; }

        //
        public DateTime SolveTS { get; set; }
        public string SolveDescr { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        public string SolveUser { get; set; }


        //[NotMapped] - не отражается на базу
        //public int NotMappedProperty { get; set; }
    }
}
