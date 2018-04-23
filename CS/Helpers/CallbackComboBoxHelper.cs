using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E4425.Helpers {
    public static class CallbackComboBoxHelper {
        private static ComboBoxSettings callbackComboBox;
        public static ComboBoxSettings CreateCommonComboBoxSettings() {
            callbackComboBox = new ComboBoxSettings();
            callbackComboBox.Properties.TextField = "CountryName";
            callbackComboBox.Properties.ValueField = "CountryID";
            callbackComboBox.Properties.ValueType = typeof(int);
            callbackComboBox.Properties.DropDownStyle = DropDownStyle.DropDown;
            callbackComboBox.Properties.CallbackPageSize = 20;
            return callbackComboBox;
        }
        public static ComboBoxSettings CreateComboBoxSettings(bool isInEditForm) {
            callbackComboBox = CreateCommonComboBoxSettings();
            if (isInEditForm) {
                callbackComboBox.Name = "CountryID";
                callbackComboBox.CallbackRouteValues = new { Controller = "Home", Action = "CountryComboBoxPartial" };
            } else {
                callbackComboBox.Name = "FilterCountryID";
                callbackComboBox.CallbackRouteValues = new { Controller = "Home", Action = "FilterComboBox" };
                callbackComboBox.Properties.ClientSideEvents.SelectedIndexChanged = "OnSelectedIndexChanged";
            }
            return callbackComboBox;
        }

    }

}
