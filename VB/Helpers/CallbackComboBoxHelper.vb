Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace E4425.Helpers
	Public NotInheritable Class CallbackComboBoxHelper

		Private Sub New()
		End Sub
		Private Shared callbackComboBox As ComboBoxSettings

		Public Shared Function CreateComboBoxColumnProperties() As MVCxColumnComboBoxProperties
			Dim p As New MVCxColumnComboBoxProperties()
				p.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "CountryComboBox"}
				p.ValueField = "CountryID"
				p.TextField = "CountryName"
				p.ValueType = GetType(Integer)
				p.CallbackPageSize = 20
				p.DropDownStyle = DropDownStyle.DropDown
				p.BindList(E4425.Models.DataProvider.GetCountries())
			Return p
		End Function

	End Class
End Namespace
