using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BinaMitraTextileWebCore.Controllers;
using BinaMitraTextileWebCore.Models;
using LibCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace BinaMitraTextileWebCore
{
    public class Helper : HelperVariables
    {
		public static AppDBContext dbContext = CreateDBContext();

		/* DATABASE *******************************************************************************************************************************************/

		//to create AppDBContext within static methods
		public static AppDBContext CreateDBContext(int? timeout = null)
		{
			AppDBContext dbContext = new AppDBContext(new DbContextOptionsBuilder<AppDBContext>().UseSqlServer(ConnectionString).Options);
			if(timeout != null)
				dbContext.Database.SetCommandTimeout(timeout);
			return dbContext;
		}

		/* APPEND METHODS *************************************************************************************************************************************/

		public static string append<T>(string log, string value, string delimiter)
		{
			return Util.append(log, getName<T>(value), delimiter);
		}

		public static string append<T>(string log, object oldValue, object newValue, string format)
		{
			if (oldValue != null) oldValue = getName<T>(oldValue);
			if (newValue != null) newValue = getName<T>(newValue);

			return Util.appendChange(log, oldValue, newValue, format);
		}

		public static string addLogForList<T>(string log, List<string> oldValue, List<string> newValue, string format)
		{
			if (newValue != null)
				newValue = newValue.ConvertAll(d => d.ToUpper());

			if (oldValue != null)
				oldValue = oldValue.ConvertAll(d => d.ToUpper());

			string addedlog = string.Empty;
			if (newValue != null)
			{
				foreach (string value in newValue)
				{
					if (oldValue != null && oldValue.Contains(value))
						oldValue.Remove(value);
					else
						addedlog = append<T>(addedlog, value, ", ");
				}
			}
			if (!string.IsNullOrEmpty(addedlog)) addedlog = Environment.NewLine + "Added: " + addedlog;

			string removedlog = string.Empty;
			if (oldValue != null)
			{
				foreach (string value in oldValue)
					removedlog = append<T>(removedlog, value, ", ");
			}

			if (!string.IsNullOrEmpty(removedlog)) removedlog = Environment.NewLine + "Removed: " + removedlog;

			if (!string.IsNullOrEmpty(removedlog) || !string.IsNullOrEmpty(addedlog))
			{
				string newlog = string.Format(format, removedlog + addedlog);
				return Util.append(log, newlog, Environment.NewLine + Environment.NewLine);
			}
			else
				return log;
		}

		public static string getName<T>(object value)
		{
		//	string id = value.ToString().ToLower();
		//	if (typeof(T) == typeof(UserAccountRolesModel))
		//		return dbContext.UserAccountRoles.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault().Name;
		//	else if (typeof(T) == typeof(UserAccountsModel))
		//		return new UserAccountsController().get((Guid)value).Fullname;
  //          else if (typeof(T) == typeof(BranchesModel))
  //              return new BranchesController().get(new Guid(id)).Name;
  //          else if (typeof(T) == typeof(FranchisesModel))
  //              return dbContext.Franchises.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault().Name;
  //          //else if (typeof(T) == typeof(PromotionEventsModel))
  //          //	return dbContext.PromotionEvents.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault().Name;
  //          else if (typeof(T) == typeof(LanguagesModel))
		//		return dbContext.Languages.Where(x => x.Id.ToString().ToLower() == id).FirstOrDefault().Name;
		//	//else if (typeof(T) == typeof(ClubClassesModel))
		//	//	return ClubClassesController.get(new Guid(id)).Name;
		//	//else if (typeof(T) == typeof(SaleInvoiceItemsModel))
		//	//	return SaleInvoiceItemsController.get_by_IdList(id).FirstOrDefault().SaleInvoices_No;
		//	else
				return null;
		}

        /* METHODS ********************************************************************************************************************************************/



        /******************************************************************************************************************************************************/
    }
}
