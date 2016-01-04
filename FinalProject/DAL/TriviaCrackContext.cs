using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalProject.DAL
{
	public class TriviaCrackContext : DbContext
	{
		public TriviaCrackContext(): base("TriviaCrackContext")
		{

		}

		public DbSet<Users> Users { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Question> Questions { get; set; }
	}
}