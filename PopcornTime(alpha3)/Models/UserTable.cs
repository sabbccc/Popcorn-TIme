namespace PopcornTime_alpha3_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class UserTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserTable()
        {
            this.PaymentTables = new HashSet<PaymentTable>();
        }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Name is reqired!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "User name is reqired!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User type is reqired!")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Email is reqired!")]
        public string Email { get; set; }

        public string PhoneNo { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is reqired!")]
        public string Password { get; set; }


        public string LoginErrorMsg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentTable> PaymentTables { get; set; }

    }
}
