using Coursat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coursat.Controllers
{
    public class MainController : Controller
    {
        //Controllers of Views Here :
        public ActionResult Login()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }

        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }

        public ActionResult AdminLogin()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
        public ActionResult SignUp()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }

        public ActionResult SigningUp()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
        public ActionResult RetrievePassword()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }


        public ActionResult User()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }

        public ActionResult Dashboard()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
        public ActionResult MyCourses()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
        public ActionResult AddAdmin()
        {
            return View();
        }
        public ActionResult AddCourse()
        {
            return View();
        }
        public ActionResult EditCourse()
        {
            return View();
        }
        public ActionResult ShowCourses()
        {
            return View();
        }













        //-------------------------------------------------------------------------//
        // Type Your Function Here : 

        // User Login Function :
        [HttpPost]
        public ActionResult user(WEBSITE_USER user)
        {
            try
            {

                if (user.Email == null || user.Password == null)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.EmptyLogin = true;
                    return View("Login");
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);

                    String User_Email = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();

                    String User_Pass = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Password FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();


                    if (user.Email.Equals(User_Email) && user.Password.Equals(User_Pass))
                    {
                        System.Threading.Thread.Sleep(2000);

                        return View("User");

                    }
                    else
                    {

                        ViewBag.isRight = false;
                        return View("Login");

                    }


                }
            }
            catch (Exception e)
            {

                ViewBag.Message = false;
                return View("Login");


            }

        }

        [HttpPost]
        public ActionResult AdminDashboard(WEBSITE_USER admin)
        {
            try
            {

                if (admin.Email == null || admin.Password == null)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.EmptyAdmin = true;
                    return View("AdminLogin");
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);

                    String Admin_Email = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM ADMINS WHERE Email ='" + admin.Email + "'").FirstOrDefault<String>();

                    String Admin_Pass = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Password FROM ADMINS WHERE Email ='" + admin.Email + "'").FirstOrDefault<String>();

                    if (admin.Email.Equals(Admin_Email) && admin.Password.Equals(Admin_Pass))
                    {
                        System.Threading.Thread.Sleep(2000);

                        return View("Dashboard");

                    }
                    else
                    {

                        ViewBag.isRightAdmin = false;
                        return View("AdminLogin");

                    }

                }
            }
            catch (Exception e)
            {

                ViewBag.isRightAdmin = false;
                return View("AdminLogin");


            }

        }

        [HttpPost]
        public ActionResult FinishingUp(USER user)
        {

            try
            {

                if (user.Password == null || user.RepeatPass == null || user.Email == null || user.User_name == null)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.Empty = true;
                    return View("SignUp");

                }
                else if (user.Password != user.RepeatPass)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.Pass = false;
                    return View("SignUp");

                }
                else
                {
                    String User_Email = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();

                    String User_name = new DB_CONNECTION().Database.SqlQuery<String>("SELECT User_name FROM USERS WHERE User_name ='" + user.User_name + "'").FirstOrDefault<String>();

                    if (User_Email != null)
                    {
                        System.Threading.Thread.Sleep(2000);
                        ViewBag.RepeatedEmail = true;
                        return View("SignUp");
                    }
                    else if (User_name != null)
                    {
                        System.Threading.Thread.Sleep(2000);
                        ViewBag.RepeatedUser = true;
                        return View("SignUp");
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        new DB_CONNECTION().Database.ExecuteSqlCommand
                               ("INSERT INTO USERS (Email , User_name , Password) VALUES ('" + user.Email + "'," + "'" + user.User_name + "'," + "'" + user.Password + "')");
                        return View("SigningUp");
                    }



                }




            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(2000);
                new DB_CONNECTION().Database.ExecuteSqlCommand
                           ("INSERT INTO USERS (Email , User_name , Password) VALUES ('" + user.Email + "'," + "'" + user.User_name + "'," + "'" + user.Password + "')");
                return View("SigningUp");
            }

        }

        [HttpPost]
        public ActionResult Retrievepassword(USER user)  //Dodger's function
        {
            try
            {

                if (user.Email == null || user.User_name == null)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.Empty = true;
                    return View("RetrievePassword");
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);

                    String User_Email = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();

                    String User_name = new DB_CONNECTION().Database.SqlQuery<String>("SELECT User_name FROM USERS WHERE User_name ='" + user.User_name + "'").FirstOrDefault<String>();


                    if (user.Email.Equals(User_Email) && user.User_name.Equals(User_name))
                    {
                        String Password = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Password FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();
                        ViewBag.Password = Password;
                        ViewBag.Found = true;
                        System.Threading.Thread.Sleep(2000);

                        return View("RetrievePassword");

                    }
                    else
                    {

                        ViewBag.isRight = false;
                        return View("RetrievePassword");

                    }


                }
            }
            catch (Exception e)
            {

                ViewBag.isRight = false;
                return View("RetrievePassword");


            }

        }



        [HttpPost]
        public ActionResult Addadmin(ADMIN admin)  //Kaboria's function
        {
            return View("AddAdmin");
        }

        public void Create_User_Table(String Username) // Bassem , Omar function
        {

        }






    }
}