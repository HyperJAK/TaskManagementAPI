using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagementAPI.Classes;
using TaskManagementAPI.Classes.Database;

namespace ClassFormWithDb.Classes
{
    [Table("user")]
    public class User
    {
        [Column("userId")]
        [Key]
        public int UserId { get; set; }

        [Column("profilePic")]
        public string ProfilePic { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("username")]
        [Required]
        public string Username { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        [Column("registration_date")]
        public DateTime? RegistrationDate { get; set; }

        [Column("passId")]
        public string PassId { get; set; }

        [Column("platform_account")]
        public string PlatformAccount { get; set; }

        [Column("disabled")]
        public bool? Disabled { get; set; }

        [InverseProperty("User")]
        public List<UserHasTask> UserHasTasks { get; set; }
    }

}
