//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sessia_2_YP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConnectedService
    {
        public int ConnectedServiceID { get; set; }
        public int ContractsID { get; set; }
        public int ServicesID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Contract Contract { get; set; }
        public virtual Service Service { get; set; }
    }
}
