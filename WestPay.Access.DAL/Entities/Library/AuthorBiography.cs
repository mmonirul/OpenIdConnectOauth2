using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestPay.Access.DAL.Entities.Library 
{ 
    public class AuthorBiography
    {
        [ForeignKey("Author")]
        public Guid Id { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public virtual Author Author { get; set; }
    }
}