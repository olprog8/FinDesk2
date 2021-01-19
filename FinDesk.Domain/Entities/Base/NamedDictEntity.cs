using System;

using FinDesk.Domain.Entities.Base.Interfaces;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinDesk.Domain.Entities.Base
{
        /// <summary>Именованная сущность Словарь</summary>
        public abstract class NamedDictEntity : BaseEntity, INamedDictEntity
        {
            [Required, StringLength(300)]
            public string Name { get; set; }

            [StringLength(300)]
            public string NameRus
            {
                get
                {
                    return this.nameRus.Length != 0
                       ? this.nameRus
                       : "";
                }

                set { this.nameRus = value; }
            }

        private string nameRus = "";


        [StringLength(300)]
        public string Descr01
        {
            get
            {
                return this.descr01.Length != 0
                   ? this.descr01
                   : "";
            }

            set { this.descr01 = value; }
        }

        private string descr01 = "";


        public string ChangeUser
        {
            get
            {
                return this.changeUser.Length != 0
                   ? this.changeUser
                   : "Admin";
            }

            set { this.changeUser = value; }
        }

        private string changeUser = "";

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ChangeDt
        {
            get
            {
                return this.changeDt.HasValue
                   ? this.changeDt.Value
                   : DateTime.Now;
            }

            set { this.changeDt = value; }
        }

        private DateTime? changeDt = null;

    }
}
