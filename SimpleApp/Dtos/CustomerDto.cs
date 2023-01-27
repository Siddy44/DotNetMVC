using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SimpleApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter the Name of the Customer")]
        [StringLength(100)]
        
        public string Name { get; set; }
       
        public bool IsSubscribedToNewsLetter { get; set; }
       
        public byte MembershipTypeId { get; set; }
  
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}