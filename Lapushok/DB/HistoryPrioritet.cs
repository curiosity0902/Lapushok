//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lapushok.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistoryPrioritet
    {
        public int IDHistoryPrioritet { get; set; }
        public Nullable<int> IDAgent { get; set; }
        public Nullable<int> IDPrioritet { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual Prioritet Prioritet { get; set; }
    }
}
