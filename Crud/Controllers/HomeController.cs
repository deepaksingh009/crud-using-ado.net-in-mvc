using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Data.Model;

namespace Crud.Controllers
{
	public class HomeController : Controller
	{

		SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["datacontext"].ConnectionString);


		public ActionResult Index()
		{
			try
			{
				DataSet d = new DataSet();
				List<studentviewmodel> emp = new List<studentviewmodel>();
				Crudmodel crud = new Crudmodel();
				emp = crud.GetAllStudents();
				emp = crud.GetAllStudentsdatatable();

				return View(emp);
			}
			catch (Exception)
			{

				throw;
			}
			
			

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
	}
}