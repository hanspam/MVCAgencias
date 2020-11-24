using AgenciaPruebaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AgenciaPruebaMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            IEnumerable<PersonaModel> empList;
            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Clientes").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<PersonaModel>>().Result;
            return View(empList);

        }

        public ActionResult AddorEdit()
        {
            //if (id == 0)int id = 0
            //{
            return View(new PersonaModel());
            //}
            //else
            //{ 
            //    HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Clientes/" + id.ToString()).Result;
            //    return View(response.Content.ReadAsAsync<PersonaModel>().Result);
            //}

        }

        [HttpPost]
        public ActionResult AddorEdit(PersonaModel emp)
        {
            //if (emp.Cedula == 0)
            //{
                HttpResponseMessage response = GlobalVariables.webApiClient.PostAsJsonAsync("Clientes", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            //}
            //else
            //{
            //    HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Clientes/" + emp.id, emp).Result;
            //    TempData["SuccessMessage"] = "Updated Successfully";
            //}
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.GetAsync("Clientes/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<PersonaModel>().Result);


        }

        [HttpPost]
        public ActionResult Edit(PersonaModel emp)
        {

            HttpResponseMessage response = GlobalVariables.webApiClient.PutAsJsonAsync("Clientes/" + emp.Cedula, emp).Result;
            TempData["SuccessMessage"] = "Updated Successfully";

            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.webApiClient.DeleteAsync("Clientes/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}