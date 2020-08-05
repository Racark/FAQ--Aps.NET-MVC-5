using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using FAQ_2._0.DAL;
using FAQ_2._0.Models;


namespace FAQ_2._0.Controllers
{
    public class FAQsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: FAQs
        public ActionResult Index()
        {
            return View(db.FAQs.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save([Bind(Include = "FAQID,Pergunta,Resposta,Premium,Pos")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                fAQ.UpdateTime = DateTime.Now;


                if (fAQ.Pergunta == null || fAQ.Resposta == null)
                {
                    return RedirectToAction("Index");
                }
                     
                else
                {
                    db.FAQs.Add(fAQ);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "FAQID,Pergunta,Resposta,Premium,Pos")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                fAQ.UpdateTime = DateTime.Now;

                FAQ busca = db.FAQs.Find(fAQ.FAQID);

                if (busca != null)
                {
                    if (fAQ.Pergunta == null || fAQ.Resposta == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        db.Entry(fAQ).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }

            }


            return RedirectToAction("Index");
        }


        public ActionResult UP(int id)
        {
            FAQ fAQ = db.FAQs.Find(id);
            fAQ.Pos++;
            db.Entry(fAQ).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DOWN(int id)
        {
            FAQ fAQ = db.FAQs.Find(id);
            fAQ.Pos --;
            db.Entry(fAQ).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

 
        public ActionResult Delete(int id)
        {

            FAQ fAQ = db.FAQs.Find(id);
            db.FAQs.Remove(fAQ);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
