# GridView - How to use Callback Mode for the ComboBox column


<p><strong>UPDATED:<br></strong><br>Starting with version v2016 vol 1 (v16.1), a built-in combo box editor can operate in callback mode.  You can find detailed steps by clicking the "Show Implementation Details" link below.<br><br><br><strong>For earlier versions:</strong><br>At this moment, GridView does not support Callback Mode for the built-in combobox editor in ComboBoxDataColumn: <a href="https://www.devexpress.com/Support/Center/p/S170130">GridView - Support callback mode for the built-in editor of the MVCxGridViewColumnType.ComboBox column</a>. However, in some scenarios it is required to use ComboBoxDataColumn in Callback Mode, for instance, when the ComboBox' data source is too large. In this case it is necessary to use templates. This example demonstrates how to implement Callback Mode ComboBox in Edit Form and in Auto Filter Row of the GridView. <br> <strong>See also:<br> </strong><a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052"><strong>Using Callbacks</strong></a><strong><br> </strong></p>


<h3>Description</h3>

1.&nbsp;Use the&nbsp;<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewColumn_EditorPropertiestopic">MVCxGridViewColumn.EditorProperties</a> method to define an editor at the column level.&nbsp;<br>
<code lang="cs">settings.Columns.Add(columnCountry =&gt; {
		columnCountry.Caption = "CountryID";
		columnCountry.FieldName = "CountryID";
		columnCountry.ColumnType = MVCxGridViewColumnType.ComboBox;
		columnCountry.EditorProperties().ComboBox(p =&gt; {
			p.CallbackRouteValues = new { Controller = "Home", Action = "CountryComboBox" };
			p.ValueField = "CountryID";
			p.TextField = "CountryName";
			p.ValueType = typeof(int);
			p.CallbackPageSize = 20;
			p.DropDownStyle = DropDownStyle.DropDown;
			p.BindList(E4425.Models.DataProvider.GetCountries());
		});
	});</code>
<code lang="vb"> settings.Columns.Add(Sub(columnCountry)
                          columnCountry.Caption = "CountryID"
                          columnCountry.FieldName = "CountryID"
                          columnCountry.ColumnType = MVCxGridViewColumnType.ComboBox
                          columnCountry.EditorProperties().ComboBox(Sub(p)
                                                                          p.CallbackRouteValues = New With {.Controller = "Home", .Action = "CountryComboBox"}
                                                                          p.ValueField = "CountryID"
                                                                          p.TextField = "CountryName"
                                                                          p.ValueType = GetType(Integer)
                                                                          p.DataSource = E4425.Models.DataProvider.GetCountries()
                                                                          p.CallbackPageSize = 20
                                                                          p.DropDownStyle = DropDownStyle.DropDown
									                                      p.BindList(E4425.Models.DataProvider.GetCountries())
                                                                    End Sub)
                                                     End Sub)</code>
2.&nbsp;&nbsp;Use the&nbsp;&nbsp;<a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebMvcMVCxColumnComboBoxPropertiestopic">MVCxColumnComboBoxProperties</a>&nbsp;class to create combo box settings.&nbsp;The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxColumnComboBoxProperties_BindListtopic">MVCxColumnComboBoxProperties.BindList</a> &nbsp;method should be used to bind a column to data.&nbsp;<br>
<code lang="cs">public static MVCxColumnComboBoxProperties CreateComboBoxColumnProperties() {
			MVCxColumnComboBoxProperties p = new MVCxColumnComboBoxProperties();
			p.CallbackRouteValues = new { Controller = "Home", Action = "CountryComboBox" };
			p.ValueField = "CountryID";
			p.TextField = "CountryName";
			p.ValueType = typeof(int);
			p.CallbackPageSize = 20;
			p.DropDownStyle = DropDownStyle.DropDown;
			p.BindList(E4425.Models.DataProvider.GetCountries());
			return p;
}</code>
<br>
<code lang="vb">Public Shared Function CreateComboBoxColumnProperties() As MVCxColumnComboBoxProperties
			Dim p As New MVCxColumnComboBoxProperties()
			p.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "CountryComboBox"}
			p.ValueField = "CountryID"
			p.TextField = "CountryName"
			p.ValueType = GetType(Integer)
			p.CallbackPageSize = 20
			p.DropDownStyle = DropDownStyle.DropDown
			p.BindList(E4425.Models.DataProvider.GetCountries())
			Return p
End Function</code>
<br>3. Use the&nbsp; <a href="http://help.devexpress.com/#AspNet/DevExpressWebMvcGridExtensionBase_GetComboBoxCallbackResulttopic">GetComboBoxCallbackResult</a>&nbsp;method to handle a combo box callback on the server.<br>
<code lang="cs">public ActionResult CountryComboBox() {
            MVCxColumnComboBoxProperties p = E4425.Helpers.CallbackComboBoxHelper.CreateComboBoxColumnProperties();
            return GridViewExtension.GetComboBoxCallbackResult(p); 
} </code>
<code lang="vb">Public Function CountryComboBox() As ActionResult
	Dim p As MVCxColumnComboBoxProperties = E4425.Helpers.CallbackComboBoxHelper.CreateComboBoxColumnProperties()
	Return GridViewExtension.GetComboBoxCallbackResult(p)
End Function</code>

<br/>


