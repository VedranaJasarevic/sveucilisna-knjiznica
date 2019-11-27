using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SVEUCILISNA_KNJIZNICA.Models;

namespace SVEUCILISNA_KNJIZNICA.Controllers
{
    public class AccountController : Controller
    {
        private Entities db = new Entities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            Korisnik objKorisnik = new Korisnik();
            return View(objKorisnik);
        }

        [HttpPost]
        public ActionResult Register(Korisnik objKorisnikModel)
        {

            
            if (ModelState.IsValid)
            {
                Korisnik objKorisnik = new Korisnik();
                
                objKorisnik.Ime = objKorisnikModel.Ime;
                objKorisnik.Prezime = objKorisnik.Prezime;
                objKorisnik.Mejl = objKorisnikModel.Mejl;
                objKorisnik.Lozinka = objKorisnikModel.Lozinka;
                //objKorisnik.UlogaID = 3;
                objKorisnik.UlogaID = objKorisnikModel.UlogaID = 3;
                db.Korisniks.Add(objKorisnikModel);
                try { db.SaveChanges(); }
                
                
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting
                                // the current instance as InnerException
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                
                objKorisnikModel.SuccesMessage = "Uspješna registracija";
                return RedirectToAction("Index", "Home");
            }


            return View();
        }

        public ActionResult Login()
        {
            LoginModel login=new LoginModel();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {
                if (db.Korisniks.Where(m => m.Mejl == loginModel.Mejl && m.Lozinka == loginModel.Lozinka)
                        .FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Nepostojeći E-mail ili lozinka");
                    return View();
                }

                else
                {
                    Session["Email"] = loginModel.Mejl;
                    return RedirectToAction("Index", "Home");

                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}