using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBManger.Entities
{
    /// <summary>
    /// Student entity
    /// </summary>
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //[MaxLength(500)]
        public string UserName { get; set; }
        [Required]
        //[MaxLength(500)]
        public string FirstName { get; set; }
        [Required]
        //[MaxLength(500)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        //[MaxLength(500)]
        public string Career { get; set; }
    }
}
