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
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.ConnectedService = new HashSet<ConnectedService>();
        }
    
        public int ContractID { get; set; }
        public string Number { get; set; }
        public System.DateTime DateOfCinclusion { get; set; }
        public int TypeContractID { get; set; }
        public int PersonalAccount { get; set; }
        public Nullable<int> ReasonForTerminationID { get; set; }
        public Nullable<System.DateTime> TermibationDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConnectedService> ConnectedService { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual ReasonForTermination ReasonForTermination { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}
