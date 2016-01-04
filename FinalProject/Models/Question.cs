﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
	[Table("Question")]
	public class Question
	{
		[Key]
		public int QuestionID { get; set; }
		public string CategoryID { get; set; }
		public string QuestionText { get; set; }
		public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
		public string Answer4 { get; set; }
		public int CorrectAnswer { get; set; }
		public bool? Answered { get; set; }
	}
}