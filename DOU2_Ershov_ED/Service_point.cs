//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOU2_Ershov_ED
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service_point
    {
        public int id_service_car { get; set; }
        public Nullable<int> id_car { get; set; }
        public Nullable<int> id_service { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Comments { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Service_list Service_list { get; set; }
    }
}
