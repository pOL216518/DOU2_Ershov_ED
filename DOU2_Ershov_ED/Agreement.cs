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
    
    public partial class Agreement
    {
        public int id_agreement { get; set; }
        public Nullable<System.DateTime> Start_date { get; set; }
        public Nullable<System.DateTime> End_date { get; set; }
        public Nullable<int> id_car { get; set; }
        public Nullable<decimal> Rental_amount { get; set; }
        public Nullable<int> id_user { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Cars Cars { get; set; }
    }
}
