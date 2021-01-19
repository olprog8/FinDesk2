using System;
using System.Collections.Generic;
using System.Text;

namespace FinDesk.Domain.Entities.Base.Interfaces
{
    interface INamedDictEntity: IBaseEntity, INamedEntity
    {
        string NameRus { get; set; }
        string Descr01 { get; set; }

        DateTime ChangeDt { get; set; }
        
        string ChangeUser { get; set; }
    }
}
