using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E4425.Helpers {
    public static class CallbackComboBoxHelper {
        private static ComboBoxSettings callbackComboBox;

       public static MVCxColumnComboBoxProperties CreateComboBoxColumnProperties() {
			MVCxColumnComboBoxProperties p = new MVCxColumnComboBoxProperties();
				p.CallbackRouteValues = new { Controller = "Home", Action = "CountryComboBox" };
				p.ValueField = "CountryID";
				p.TextField = "CountryName";
				p.ValueType = typeof(int);
				p.CallbackPageSize = 20;
				p.DropDownStyle = DropDownStyle.DropDown;
				p.BindList(E4425.Models.DataProvider.GetCountries());
			return p;
		}

    }
}
