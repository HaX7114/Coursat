﻿using Coursat.Models;
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
            int i;
            String COURSE_NAME = null;
            String COURSE_PLACE = null;
            String COURSE_DAY = null;
            int COURSE_HOUR = 0;
            int COURSE_MIN = 0;
            int COURSE_ID = 0;
            int MAX_STD_NUM = 0;

            try
            {


                int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(Course_ID) FROM COURSEs").FirstOrDefault<int>();

                int[] ID = new int[n];

                new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO TEMP(ID)(SELECT Course_ID FROM COURSEs)");

                for (i = 0; i < n; i++)
                {
                    ID[i] = new DB_CONNECTION().Database.SqlQuery<int>("SELECT TOP 1 ID FROM TEMP").FirstOrDefault<int>();

                    new DB_CONNECTION().Database.ExecuteSqlCommand("DELETE TOP (1) FROM TEMP");

                }

                List<COURSE> COURSE_LIST = new List<COURSE>();

                for (i = 0; i < n; i++)
                {
                    COURSE_ID = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<int>();
                    COURSE_NAME = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Name FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<String>();
                    COURSE_HOUR = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Hours FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<int>();
                    COURSE_MIN = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Min FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<int>();
                    COURSE_DAY = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Day FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<String>();
                    COURSE_PLACE = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Place FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<String>();
                    MAX_STD_NUM = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Max_Students_Number FROM COURSEs WHERE Course_ID = " + ID[i]).FirstOrDefault<int>();


                    COURSE_LIST.Add(new COURSE
                    {
                        Course_ID = COURSE_ID,
                        Course_Name = COURSE_NAME,
                        Course_Hours = COURSE_HOUR,
                        Course_Min = COURSE_MIN,
                        Course_Day = COURSE_DAY,
                        Course_Place = COURSE_PLACE,
                        Max_Students_Number = MAX_STD_NUM

                    });



                }

                ViewBag.Empty = false;

                ViewBag.Courses = COURSE_LIST;

                return View();

            }
            catch (Exception e)
            {
                ViewBag.Empty = true;

                return View();
            }

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

                        

                                Create_User_Table(user.User_name);

                        return View("SigningUp");
                    }



                }




            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(2000);
                new DB_CONNECTION().Database.ExecuteSqlCommand
                           ("INSERT INTO USERS (Email , User_name , Password) VALUES ('" + user.Email + "'," + "'" + user.User_name + "'," + "'" + user.Password + "')");

               

                Create_User_Table(user.User_name);

                return View("SigningUp");
            }

        }

        [HttpPost]
        public ActionResult Retrievepassword(USER user)  
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
        public ActionResult Addadmin(ADMIN admin)  
        {
            return View("AddAdmin");
        }

        public void Create_User_Table(String Username) 
        {

            

            new DB_CONNECTION().Database.ExecuteSqlCommand
                    ("CREATE TABLE " + Username + "(ID int ,COURSE_NAME varchar(50))");



        }

        public JsonResult Add_Course(String Course_ID , String Course_Name , String Course_Hours , String Course_Min , String Course_Day , String Course_Place , String Max_Students_Number)
        {
            bool ADDED = false;

            if(Course_ID == null || Course_Name == null || Course_Hours == null || Course_Min == null || Course_Day == null || Course_Place == null || Max_Students_Number == null)
            {
                return Json(ADDED,JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {

                    new DB_CONNECTION().Database.ExecuteSqlCommand(

                        "INSERT INTO COURSEs (Course_ID , Course_Name , Course_Hours , Course_Min , Course_Day , Course_Place , Max_Students_Number)" +
                        "VALUES(" + int.Parse(Course_ID) + "," + "'" + Course_Name + "'" + "," + int.Parse(Course_Hours) + "," + int.Parse(Course_Min) +
                        "," + "'" + Course_Day + "'" + "," + "'" + Course_Place + "'" + "," + int.Parse(Max_Students_Number) + ")"

                        );

                    ADDED = true;
                    return Json(ADDED, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    
                    return Json(ADDED, JsonRequestBehavior.AllowGet);

                }
            }


        }
        public JsonResult Edit_Course(String Course_ID , String Course_Name , String Course_Hours , String Course_Min , String Course_Day , String Course_Place , String Max_Students_Number)
        {
            bool EDITED = false;

            if(Course_ID == null || Course_Name == null || Course_Hours == null || Course_Min == null || Course_Day == null || Course_Place == null || Max_Students_Number == null)
            {
                return Json(EDITED, JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {

                    new DB_CONNECTION().Database.ExecuteSqlCommand(

                        "UPDATE COURSEs SET Course_ID = " + int.Parse(Course_ID) + "," + "Course_Name = '" + Course_Name + "'" + ","
                        + "Course_Hours = " + int.Parse(Course_Hours) + "," + "Course_Min = " + int.Parse(Course_Min) + "," 
                        + "Course_Day = '" + Course_Day + "'" + "," + "Course_Place = '" + Course_Place + "'" + "," 
                        + "Max_Students_Number = " + int.Parse(Max_Students_Number) + " WHERE Course_ID = " + int.Parse(Course_ID)

                        );

                    EDITED = true;
                    return Json(EDITED, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    
                    return Json(EDITED, JsonRequestBehavior.AllowGet);

                }
            }


        }
        /*Kaboria
        public JsonResult Search_Course()
        {

            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete_Course()
        {

            return Json(JsonRequestBehavior.AllowGet);
        }
        
        */

        //Un essential functions that used for ajax checking//
        public JsonResult Check_ID(int Course_ID)
        {

            int ID = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + Course_ID).FirstOrDefault<int>();

            bool resid;

            if (ID == Course_ID)
                resid = false;
            else
                resid = true;
          

            return Json(resid,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Check_Name(String Course_Name)
        {
            String Name = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Name FROM COURSEs WHERE Course_Name = '" + Course_Name + "'").FirstOrDefault<String>();

            bool resname;

            if (Name == Course_Name)
                resname = false;
            else
                resname = true;


            return Json(resname, JsonRequestBehavior.AllowGet);
        }

        
        //END OF un essential functions//







    }
}