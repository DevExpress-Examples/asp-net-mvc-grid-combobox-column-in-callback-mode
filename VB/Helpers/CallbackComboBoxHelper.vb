Imports Microsoft.VisualBasic
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace E4425.Helpers
	Public NotInheritable Class CallbackComboBoxHelper
		Private Shared callbackComboBox As ComboBoxSettings
		Private Sub New()
		End Sub
		Public Shared Function CreateCommonComboBoxSettings() As ComboBoxSettings
			callbackComboBox = New ComboBoxSettings()
			callbackComboBox.Properties.TextField = "CountryName"
			callbackComboBox.Properties.ValueField = "CountryID"
			callbackComboBox.Properties.ValueType = GetType(Integer)
			callbackComboBox.Properties.DropDownStyle = DropDownStyle.DropDown
			callbackComboBox.Properties.CallbackPageSize = 20
			Return callbackComboBox
		End Function
		Public Shared Function CreateComboBoxSettings(ByVal isInEditForm As Boolean) As ComboBoxSettings
			callbackComboBox = CreateCommonComboBoxSettings()
			If isInEditForm Then
				callbackComboBox.Name = "CountryID"
				callbackComboBox.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "CountryComboBoxPartial"}
			Else
				callbackComboBox.Name = "FilterCountryID"
				callbackComboBox.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "FilterComboBox"}
				callbackComboBox.Properties.ClientSideEvents.SelectedIndexChanged = "OnSelectedIndexChanged"
			End If
			Return callbackComboBox
		End Function

	End Class

End Namespace
