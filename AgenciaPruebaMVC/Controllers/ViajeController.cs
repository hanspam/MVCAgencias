using AgenciaPruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AgenciaPruebaMVC.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            IEnumerable<ViajeModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Viajes").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<ViajeModel>>().Result;
            return View(empList);
        }

        public ActionResult Add()
        {

            return View(new ViajeModel());

        }
        [HttpPost]
        public ActionResult Add(ViajeModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Viajes", emp).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Viajes/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<ViajeModel>().Result);


        }

        [HttpPost]
        public ActionResult Edit(ViajeModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Viajes/" + emp.CodigodeViaje, emp).Result;
            TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Viajes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}