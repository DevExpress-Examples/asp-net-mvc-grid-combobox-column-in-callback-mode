Imports Microsoft.VisualBasic
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
				Return CType(Session(key), DemoDataObject)
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
		Private privateCustomers As List(Of Customer)
		Public Property Customers() As List(Of Customer)
			Get
				Return privateCustomers
			End Get
			Set(ByVal value As List(Of Customer))
				privateCustomers = value
			End Set
		End Property
		Private privateCountries As List(Of Country)
		Public Property Countries() As List(Of Country)
			Get
				Return privateCountries
			End Get
			Set(ByVal value As List(Of Country))
				privateCountries = value
			End Set
		End Property
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
		Private privateCustomerID As Integer
		Public Property CustomerID() As Integer
			Get
				Return privateCustomerID
			End Get
			Set(ByVal value As Integer)
				privateCustomerID = value
			End Set
		End Property
		Private privateCustomerName As String
		Public Property CustomerName() As String
			Get
				Return privateCustomerName
			End Get
			Set(ByVal value As String)
				privateCustomerName = value
			End Set
		End Property
		Private privateCountryID As Integer
		Public Property CountryID() As Integer
			Get
				Return privateCountryID
			End Get
			Set(ByVal value As Integer)
				privateCountryID = value
			End Set
		End Property
	End Class

	Public Class Country
		Private privateCountryID As Integer
		Public Property CountryID() As Integer
			Get
				Return privateCountryID
			End Get
			Set(ByVal value As Integer)
				privateCountryID = value
			End Set
		End Property
		Private privateCountryName As String
		Public Property CountryName() As String
			Get
				Return privateCountryName
			End Get
			Set(ByVal value As String)
				privateCountryName = value
			End Set
		End Property
	End Class

End Namespace