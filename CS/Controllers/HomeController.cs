using System.Web.Mvc;
using E4425.Models;
using DevExpress.Web.Mvc;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace E4425.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            return View(DataProvider.GetCustomers());
        }
        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            return PartialView(DataProvider.GetCustomers());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateGridView([ModelBinder(typeof(DevExpressEditorsBinder))] Customer customerInfo) {
            if (ModelState.IsValid)
                DataProvider.UpdateCustomer(customerInfo);
            return PartialView("GridViewPartial", DataProvider.GetCustomers());
        }
        public ActionResult CountryComboBox() {
            MVCxColumnComboBoxProperties p = E4425.Helpers.CallbackComboBoxHelper.CreateComboBoxColumnProperties();
            return GridViewExtension.GetComboBoxCallbackResult(p); 
        } 
    }
}