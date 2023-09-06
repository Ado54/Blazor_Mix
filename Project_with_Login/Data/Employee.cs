﻿using System.ComponentModel.DataAnnotations;

namespace Project_with_Login.Data
{
    public class Employee
    {
      
        public int Id { get; set; }


        [Required, MinLength(1), MaxLength(50)]
        public string FirstName { get; set; }
        [Required]

        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Designation { get; set; }

    }
}