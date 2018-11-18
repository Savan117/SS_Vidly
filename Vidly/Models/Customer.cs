using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required (ErrorMessage ="Please enter cutomer's name")]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribedToNewsletter { get; set; }
		public MembershipType MembershipType { get; set; }
		public int MembershipTypeID { get; set; }
		[Display(Name="Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? BirthDate { get; set; }
		public object MembershipTypeDto { get; internal set; }
	}
}