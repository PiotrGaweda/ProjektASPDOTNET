﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class StudentViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is missing!")]
        public string Name { get; set; }

        [RegularExpression(".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Incorrect email format!")]
        [Required(ErrorMessage = "Email is missing or incorrect!")]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "Index number too short!")]
        [MaxLength(6, ErrorMessage = "Index number too long!")]
        [Required(ErrorMessage = "Index number is missing!")]
        public string IndexNumber { get; set; }

        public DateTime? Birth { get; set; }
    }
}


