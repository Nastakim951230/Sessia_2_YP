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
    
    public partial class InformatsiaSotrudnika
    {
        public int InformatsiaSotrudnikaID { get; set; }
        public int ID_Role { get; set; }
        public string Informatsia { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
