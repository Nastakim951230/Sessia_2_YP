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
    
    public partial class Sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnik()
        {
            this.InstallationEquipment = new HashSet<InstallationEquipment>();
        }
    
        public int SotrudnikID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string NomerTelefon { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public int Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstallationEquipment> InstallationEquipment { get; set; }
        public virtual Role Role1 { get; set; }
    }
}
