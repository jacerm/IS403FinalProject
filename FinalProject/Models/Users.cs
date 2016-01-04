using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
	[Table("Users")]
	public class Users
	{
			//user model using a useremail as the primary key, validation for each attribute for the creation of users
			[Key]
			public int UserID { get; set; }
			public string UserName { get; set; }
			[DataType(DataType.Password)]
			public string UserPassword { get; set; }
			public int UserScore { get; set; }
	}
}