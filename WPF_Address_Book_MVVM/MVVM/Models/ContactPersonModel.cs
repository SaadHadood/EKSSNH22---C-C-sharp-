using System;

namespace WPF_Address_Book_MVVM.MVVM.Models
{
    public class ContactPersonModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string DisplayName => $"{FirstName} {LastName}";
    }
}
