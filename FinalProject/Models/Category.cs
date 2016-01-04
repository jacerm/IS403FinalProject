using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
	[Table("Category")]
	public class Category
	{
		[Key]
		public string CategoryID { get; set; }
		public string CategoryDesc { get; set; }
	}
}