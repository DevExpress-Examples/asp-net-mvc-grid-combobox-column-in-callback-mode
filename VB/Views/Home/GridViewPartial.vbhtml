@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "grid"
                                settings.KeyFieldName = "CustomerID"
                                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "UpdateGridView"}
                                settings.Settings.ShowFilterRow = True
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.Columns.Add("CustomerID").Visible = False
                                settings.Columns.Add("CustomerName")
                                settings.Columns.Add(Sub(columnCountry)
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
                                                                                                   End Sub
                                                     )
                                                     End Sub
                                )
                            End Sub
).Bind(Model).GetHtml()