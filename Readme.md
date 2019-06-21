<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* **[CallbackComboBoxHelper.cs](./CS/Helpers/CallbackComboBoxHelper.cs) (VB: [CallbackComboBoxHelper.vb](./VB/Helpers/CallbackComboBoxHelper.vb))**
* [Model.cs](./CS/Models/Model.cs) (VB: [Model.vb](./VB/Models/Model.vb))
* [CountryComboBoxPartial.cshtml](./CS/Views/Home/CountryComboBoxPartial.cshtml)
* [FilterComboBox.cshtml](./CS/Views/Home/FilterComboBox.cshtml)
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to use Callback Mode for the ComboBox column
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4976)**
<!-- run online end -->


<p><strong>UPDATED:<br></strong><br>Starting with version v2016 vol 1 (v16.1), a built-in combo box editor can operate in callback mode.  You can find detailed steps by clicking the "Show Implementation Details" link below.<br><br><br><strong>For earlier versions:</strong><br>At this moment, GridView does not support Callback Mode for the built-in combobox editor in ComboBoxDataColumn: <a href="https://www.devexpress.com/Support/Center/p/S170130">GridView - Support callback mode for the built-in editor of the MVCxGridViewColumnType.ComboBox column</a>. However, in some scenarios it is required to use ComboBoxDataColumn in Callback Mode, for instance, when the ComboBox' data source is too large. In this case it is necessary to use templates. This example demonstrates how to implement Callback Mode ComboBox in Edit Form and in Auto Filter Row of the GridView. <br> <strong>See also:<br> </strong><a href="http://documentation.devexpress.com/#AspNet/CustomDocument9052"><strong>Using Callbacks</strong></a><strong><br> </strong></p>

<br/>


