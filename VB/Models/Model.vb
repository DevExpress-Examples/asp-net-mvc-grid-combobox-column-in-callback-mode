Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.SessionState

Namespace E4425.Models
	Public NotInheritable Class DataProvider

		Private Sub New()
		End Sub


		Private Shared ReadOnly Property Session() As HttpSessionState
			Get
				Return HttpContext.Current.Session
			End Get
		End Property

		Private Shared ReadOnly Property DemoData() As DemoDataObject
			Get
				Const key As String = "FB1EB35F-86F5-4FFE-BB23-CBAAF1514C49"
				If Session(key) Is Nothing Then
					Dim obj = New DemoDataObject()
					obj.FillObj()
					Session(key) = obj
				End If
				Return DirectCast(Session(key), DemoDataObject)
			End Get
		End Property

		Public Shared Function GetCustomers() As IEnumerable(Of Customer)
			Return DemoData.Customers
		End Function
		Public Shared Function GetCountries() As IEnumerable(Of Country)
			Return DemoData.Countries
		End Function

		Public Shared Sub UpdateCustomer(ByVal customerInfo As Customer)
			Dim c = DemoData.Customers.First(Function(i) i.CustomerID = customerInfo.CustomerID)
			c.CustomerName = customerInfo.CustomerName
			c.CountryID = customerInfo.CountryID
		End Sub
	End Class

	Public Class DemoDataObject
		Public Property Customers() As List(Of Customer)
		Public Property Countries() As List(Of Country)
		Public Sub FillObj()
			Customers = New List(Of Customer)()
			Countries = New List(Of Country)()
			For i As Integer = 0 To 999
				Countries.Add(CreateCountry("CountryName" & i))
			Next i
			For i As Integer = 0 To 999
				CreateCustomer("CustomerName" & i, Countries(i))
			Next i
		End Sub

		Private Function CreateCustomer(ByVal name As String, ByVal country As Country) As Customer
			Dim c = New Customer() With {.CustomerName = name, .CountryID = country.CountryID, .CustomerID = Customers.Count}
			Customers.Add(c)
			Return c
		End Function

		Private Function CreateCountry(ByVal name As String) As Country
			Dim c = New Country() With {.CountryName = name}
			c.CountryID = Countries.Count
			Return c
		End Function
	End Class

	Public Class Customer
		Public Property CustomerID() As Integer
		Public Property CustomerName() As String
		Public Property CountryID() As Integer
	End Class

	Public Class Country
		Public Property CountryID() As Integer
		Public Property CountryName() As String
	End Class

End Namespace