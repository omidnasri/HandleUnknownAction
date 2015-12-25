using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandlingUnknownActions.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// صفحه ساز
        /// </summary>
        /// <param name="txtTitle"></param>
        /// <param name="txtPage"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Post(string txtTitle, string txtPage)
        {
            // مسیر فایل
            string fileLoc = Server.MapPath("~") + "\\Views\\Home\\" + txtTitle + ".cshtml";
            // در صورتی که قبلا این صفحه وجود داشته باشد، آن را حذف خواهیم کرد
            if (System.IO.File.Exists(fileLoc))
            {
                // حذف
                System.IO.File.Delete(fileLoc);
            }
            // ذخیره صفحه
            System.IO.FileStream fs = System.IO.File.Open(fileLoc, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.Write(txtPage);
            sw.Close();
            // برگشت به خانه
            return RedirectToAction("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionName"></param>
        protected override void HandleUnknownAction(string actionName)
        {
            this.View(actionName).ExecuteResult(this.ControllerContext);
        }
    }
}