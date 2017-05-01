using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.DynamicData;

namespace Data.Model
{
	public class Crudmodel
	{

		public List<studentviewmodel> GetAllStudents()
		{
			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["datacontext"].ConnectionString))
			{
				con.Open();
				string s = string.Empty;
				String SelectCmdString = "select * from Studentregistration";
				SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(SelectCmdString, con);
				DataSet mydatase = new DataSet();
				mySqlDataAdapter.Fill(mydatase, "chatabotproducts");

				List<studentviewmodel> emp = new List<studentviewmodel>();
				emp = (from DataRow row in mydatase.Tables["chatabotproducts"].Rows

					   select new studentviewmodel
					   {
						   Namr = row["Name"].ToString(),
						   Address = row["Address"].ToString(),

					   }).ToList();
				return emp;

			}
		}

		public List<studentviewmodel> GetAllStudentsdatatable()
		{
			DataTable dt = new DataTable();
			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["datacontext"].ConnectionString))
			{
				con.Open();
				string s = string.Empty;
				String SelectCmdString = "select * from Studentregistration";
				SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(SelectCmdString, con);
				mySqlDataAdapter.Fill(dt);


				List<studentviewmodel> emp = new List<studentviewmodel>();
				emp = (from DataRow row in dt.Rows

					   select new studentviewmodel
					   {
						   Namr = row["Name"].ToString(),
						   Address = row["Address"].ToString(),

					   }).ToList();
				return emp;

			}
		}
	}
}

