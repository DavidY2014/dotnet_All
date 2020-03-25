using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advanced.Framework.MVC5.Models;

namespace Advanced.Framework.MVC5.Controllers
{
    public class FirstController : Controller
    {
        private List<User> _userList = new List<User>();

        public FirstController()
        {
            _userList.Add(new User() { Id = 1, Name = "jack" });
        }

        /// <summary>
        /// viewdata和viewbag的区别
        /// viewdata的类型是个字典,内部数值需要类型转换
        /// TempData也是一个字典,但是可以在一个session中跨action传值,其实也就是通过session传值的
        /// viewbag是个dynamic类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id=1)
        {
            User currentUser = this._userList.FirstOrDefault(item => item.Id == 1);
            base.ViewData["CurrentUserViewBag"] = this._userList[0];
            base.ViewBag.CurrentUserViewBag = this._userList[0];
            base.TempData["TestProp"] = "tank";

            if (id < 10)
                return View(currentUser);
            else
                return base.RedirectToAction("TempDataShow");
        }

        /// <summary>
        /// 此时上面的tempdata数据可以传过来
        /// </summary>
        /// <returns></returns>
        public ActionResult TempDataShow()
        {
            return View();
        }


        /// <summary>
        /// 前端可以不用传参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult IndexIdNull(int? id)
        {
            return View();
        }

        /// <summary>
        /// 不用返回视图，可以直接获取string值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string StringName(string name)
        {
            return $"This is {name}";
        }

        /// <summary>
        /// 没有行为设置会导致访问不了
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult JsonResult(int id,string name)
        {
            return new JsonResult()
            {
                Data = new
                {
                    Id = id,
                    Name = name
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        //public FilePathResult GetFileResult()
        //{
        //    return new File(@"C:\Users\Administrator\Desktop\mysqlpassowdl.txt");
        //}



    }
}