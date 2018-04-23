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

		<HttpGet>
		Public Function Index() As ActionResult
			Return View(DataProvider.GetCustomers())
		End Function
		<ValidateInput(False)>
		Public Function GridViewPartial() As ActionResult
			Return PartialView(DataProvider.GetCustomers())
		End Function
		<HttpPost, ValidateInput(False)>
		Public Function UpdateGridView(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customerInfo As Customer) As ActionResult
			If ModelState.IsValid Then
				DataProvider.UpdateCustomer(customerInfo)
			End If
			Return PartialView("GridViewPartial", DataProvider.GetCustomers())
		End Function
		Public Function CountryComboBox() As ActionResult
			Dim p As MVCxColumnComboBoxProperties = E4425.Helpers.CallbackComboBoxHelper.CreateComboBoxColumnProperties()
			Return GridViewExtension.GetComboBoxCallbackResult(p)
		End Function
	End Class
End Namespace