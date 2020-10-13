using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Financitos.Models;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace Financitos.Controllers
{
    public class accountController : Controller
    {
        private Financistoconex _Context;
        public accountController(Financistoconex context)
        {   
            _Context = context;
        }
        [HttpGet] 
        public ViewResult index()
        {
            ViewBag.accounts = _Context.Accounts.ToList();
            return View("Index");
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View("create", new Account());
        }
        [HttpPost]
        public ActionResult create(Account account)
        {
           // if(account.Name == null || account.Name == "")
            //ModelState.AddModelError("Name", "El campo es requerido");
            
            if(ModelState.IsValid)
            {
                _Context.Accounts.Add(account);
                _Context.SaveChanges();

                return RedirectToAction("index");
            }
            return View("create", account);
       
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Types = new List<string> { "Efectivo", "Debito" , "Credito" };
         
            var account  = _Context.Accounts.Where(o => o.id == id).FirstOrDefault();
            return View("Edit", account);

        }
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            //Este metodo se utiliza ara alterr Cmpos especificos, no se necesita
            //enviar todos los datos
            //var a = _Context.Accounts.Where(o => o.id == account.id).FirstOrDefault();
            // a.Name = account.Name;
            //este metodo se utiliza para editar todos lso campos, es requerido enviar todos los campos
            if (ModelState.IsValid)
            {
                _Context.Accounts.Update(account);
                _Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Account = account;
            return RedirectToAction("Edit",account);

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = _Context.Accounts.Where(o => o.id == id).FirstOrDefault();
            _Context.Accounts.Remove(account);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
   

    
    
}
