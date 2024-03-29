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
    
    public partial class Subscriber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscriber()
        {
            this.CRM = new HashSet<CRM>();
            this.InstallationEquipment = new HashSet<InstallationEquipment>();
        }
    
        public int SubscriberID { get; set; }
        public string Nomer { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int GenderID { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Place0fResidence { get; set; }
        public string ResidentialAddressID { get; set; }
        public string SeriaPassport { get; set; }
        public string NomerPassport { get; set; }
        public string DivisionCode { get; set; }
        public string IssuedBy { get; set; }
        public System.DateTime DateOfIssue { get; set; }
    
        public virtual Contract Contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM> CRM { get; set; }
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstallationEquipment> InstallationEquipment { get; set; }
    }
}
