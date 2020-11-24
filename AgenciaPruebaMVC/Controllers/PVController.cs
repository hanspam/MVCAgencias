using AgenciaPruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AgenciaPruebaMVC.Controllers
{
    public class PVController : Controller
    {
        // GET: PV
        public ActionResult Index()
        {
            IEnumerable<pvModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ClienteViajes").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<pvModel>>().Result;
            return View(empList);
        }

        public ActionResult Add()
        {
            AgenciaViajeEntitiesDDL1 db = new AgenciaViajeEntitiesDDL1();
            ViewBag.Cedulas = new SelectList(db.Clientes, "Id", "Cedula");

            AgenciaViajeEntitiesDDL2 db2 = new AgenciaViajeEntitiesDDL2();
            ViewBag.CodViaje = new SelectList(db2.Viajes, "CodigodeViaje", "Destino");
            
            return View(new pvModel());

        }

        //public ActionResult myDDList()
        //{


        //    return View();
        //}



        [HttpPost]
        public ActionResult Add(pvModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("ClienteViajes", emp).Result;
            TempData["SuccessMessage"] = "Saved Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("ClienteViajes/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<pvModel>().Result);
        }

        [HttpPost]
        public ActionResult Edit(pvModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("ClienteViajes/" + emp.id, emp).Result;
            TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("ClienteViajes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}