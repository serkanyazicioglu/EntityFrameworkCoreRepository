namespace TestProject
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Member")]
    public partial class Member
    {
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public int Status { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        public int? Type { get; set; }

        [StringLength(500)]
        public string ProfilePictureUrl { get; set; }

        public Guid? PasswordRecoveryId { get; set; }

        [StringLength(32)]
        public string HashSalt { get; set; }
    }
}
