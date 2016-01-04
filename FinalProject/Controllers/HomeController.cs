using FinalProject.DAL;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace FinalProject.Controllers
{
	public class HomeController : Controller
	{
		private TriviaCrackContext db = new TriviaCrackContext();

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Answer(int id)
		{
			IEnumerable<Data> data =

				db.Database.SqlQuery<Data>(

			"Select * " +

			"FROM question JOIN category ON question.CategoryID = category.CategoryID " +
			"Where question.QuestionID = " + id + ";");
			var currentuser = db.Users.Find(1);
			ViewBag.userscore = currentuser.UserScore;
			return View(data);
		}

		[HttpPost]
		public ActionResult NewAnswer(FormCollection form, int? id)
		{
			String newanswer = form["NewAnswer"].ToString();
			var intanswer = Int32.Parse(newanswer);

			var currentQuestion = db.Questions.Find(id);
			if (currentQuestion.CorrectAnswer == intanswer) 
			{
				var currentuser = db.Users.Find(1);
				currentuser.UserScore = currentuser.UserScore + 10;
				ViewBag.userscore = currentuser.UserScore;
			}
			currentQuestion.Answered = true;
			db.SaveChanges();

			return RedirectToAction("Play", "Home");
		}

		[Authorize]
		public ActionResult Play()
		{
			var currentuser = db.Users.Find(1);
			ViewBag.userscore = currentuser.UserScore;
			IEnumerable<Data> data =

				db.Database.SqlQuery<Data>(

			"Select * " +

			"FROM question JOIN category ON question.CategoryID = category.CategoryID " +
			"Where question.Answered = 'false'");
			return View(data);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(FormCollection form, bool rememberMe = false)
		{
			String username = form["User Name"].ToString();
			String password = form["Password"].ToString();

			if (string.Equals(username, "BYU") && (string.Equals(password, "Cougars")))
			{
				FormsAuthentication.SetAuthCookie(username, rememberMe);

				return RedirectToAction("Index", "Home");

			}
			else
			{
				return View();
			}
		}

	}
}