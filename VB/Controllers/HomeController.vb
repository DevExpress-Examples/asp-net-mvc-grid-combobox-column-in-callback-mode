Imports Microsoft.VisualBasic
Imports System.Web.Mvc
Imports E4425.Models
Imports DevExpress.Web.Mvc
Imports System.Collections.Generic
Imports System.Collections
Imports System.Linq
Imports System

Namespace E4425.Controllers
	Public Class HomeController
		Inherits Controller
		<HttpGet> _
		Public Function Index() As ActionResult
			Return View(DataProvider.GetCustomers())
		End Function
		<ValidateInput(False)> _
		Public Function GridViewPartial() As ActionResult
			Return PartialView(DataProvider.GetCustomers())
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function UpdateGridView(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customerInfo As Customer) As ActionResult
			If ModelState.IsValid Then
				DataProvider.UpdateCustomer(customerInfo)
			End If
			Return PartialView("GridViewPartial", DataProvider.GetCustomers())
		End Function
		Public Function CountryComboBoxPartial() As ActionResult
			Return PartialView("CountryComboBoxPartial", DataProvider.GetCountries())
		End Function
		Public Function FilterComboBox() As ActionResult
			Return PartialView("FilterComboBox", DataProvider.GetCountries())
		End Function
	End Class
End Namespace