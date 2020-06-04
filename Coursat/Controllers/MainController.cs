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


        public ActionResult User(COURSE user)
        {
            System.Threading.Thread.Sleep(2000);

            ViewBag.USERNAME = user.Course_Name;

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


                int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(Course_ID) FROM COURSEs WHERE Course_ID NOT IN (SELECT Course_ID FROM " + user.Course_Name + ") AND Max_Students_Number != 0 ").FirstOrDefault<int>();

                if (n != 0)
                {
                    int[] ID = new int[n];

                    new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO TEMP(ID)(SELECT Course_ID FROM COURSEs WHERE Course_ID NOT IN (SELECT Course_ID FROM " + user.Course_Name + ") AND Max_Students_Number != 0 )");

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

                    return View("User");
                }
                else
                {
                    ViewBag.Empty = true;

                    return View("User");

                }


            }
            catch (Exception e)
            {
                ViewBag.Empty = true;

                return View("User");
            }
        }

        public ActionResult Dashboard()
        {
            System.Threading.Thread.Sleep(2000);
            return View();
        }
        
        public ActionResult MyCourses(COURSE user) 
        {
            ViewBag.USERNAMEE = user.Course_Name;

            int i;
            String COURSE_NAME = null;
            String COURSE_PLACE = null;
            String COURSE_DAY = null;
            int COURSE_HOUR = 0;
            int COURSE_MIN = 0;
            int COURSE_ID = 0;

            try
            {


                int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(Course_ID) FROM " + user.Course_Name).FirstOrDefault<int>();

                if (n != 0)
                {
                    int[] ID = new int[n];

                    new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO TEMP(ID)(SELECT Course_ID FROM " + user.Course_Name + ")");

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


                        COURSE_LIST.Add(new COURSE
                        {
                            Course_ID = COURSE_ID,
                            Course_Name = COURSE_NAME,
                            Course_Hours = COURSE_HOUR,
                            Course_Min = COURSE_MIN,
                            Course_Day = COURSE_DAY,
                            Course_Place = COURSE_PLACE

                        });



                    }

                    ViewBag.EmptyEnrolled = false;

                    ViewBag.UserCourses = COURSE_LIST;

                    return View();
                }
                else
                {
                    ViewBag.EmptyEnrolled = true;

                    return View();

                }


            }
            catch (Exception e)
            {
                ViewBag.EmptyEnrolled = true;

                return View();
            }
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
        public ActionResult ShowUsers()
        {
            int i;

            int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(User_name) FROM USERs").FirstOrDefault<int>();

            if (n != 0)
            {
                String[] User_name = new String[n];
                String[] User_Email = new String[n];
                int[] Courses_Num = new int[n];


                new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO STRING_TEMP(String)(SELECT User_name FROM USERs)");

                for (i = 0; i < n; i++)
                {
                    User_name[i] = new DB_CONNECTION().Database.SqlQuery<String>("SELECT TOP 1 String FROM STRING_TEMP").FirstOrDefault<String>();

                    new DB_CONNECTION().Database.ExecuteSqlCommand("DELETE TOP (1) FROM STRING_TEMP");

                }



                for (i = 0; i < n; i++)
                {
                    Courses_Num[i] = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(COURSE_ID) FROM " + User_name[i]).FirstOrDefault<int>();

                    User_Email[i] = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM USERs WHERE User_name = '" + User_name[i] + "'").FirstOrDefault<String>();

                }

                ViewBag.Empty = false;

                ViewBag.COUNTER = n;

                ViewBag.USERNAMES = User_name;

                ViewBag.USEREMAILS = User_Email;

                ViewBag.COURSESNUM = Courses_Num;

                return View();
            }
            else
            {
                ViewBag.Empty = true;

                return View();

            }






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
        public ActionResult user_login(WEBSITE_USER user)
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

                    String User_Name = new DB_CONNECTION().Database.SqlQuery<String>("SELECT User_name FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();

                    String User_Pass = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Password FROM USERS WHERE Email ='" + user.Email + "'").FirstOrDefault<String>();


                    if (user.Email.Equals(User_Email) && user.Password.Equals(User_Pass))
                    {
                        System.Threading.Thread.Sleep(2000);

                        ViewBag.USERNAME = User_Name;



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


                            int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(Course_ID) FROM COURSEs WHERE Course_ID NOT IN (SELECT Course_ID FROM " + User_Name + ") AND Max_Students_Number != 0").FirstOrDefault<int>();

                            if (n != 0)
                            {
                                int[] ID = new int[n];

                                new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO TEMP(ID)(SELECT Course_ID FROM COURSEs WHERE Course_ID NOT IN (SELECT Course_ID FROM " + User_Name + ") AND Max_Students_Number != 0)");

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

                                return View("User");
                            }
                            else
                            {
                                ViewBag.Empty = true;

                                return View("User");

                            }


                        }
                        catch (Exception e)
                        {
                            ViewBag.Empty = true;

                            return View("User");
                        }



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
            ViewBag.ERROR = false;

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
                        try
                        {
                            Create_User_Table(user.User_name);

                            new DB_CONNECTION().Database.ExecuteSqlCommand
                                   ("INSERT INTO USERS (Email , User_name , Password) VALUES ('" + user.Email + "'," + "'" + user.User_name + "'," + "'" + user.Password + "')");

                            return View("SigningUp");
                        }
                        catch
                        {
                            ViewBag.ERROR = true;

                            return View("SignUp");
                        }
                        
                    }



                }




            }
            catch (Exception e)
            {

                ViewBag.ERROR = true;

                return View("SignUp");
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
            try
            {

                if (admin.Email == null || admin.Password == null)
                {
                    System.Threading.Thread.Sleep(2000);
                    ViewBag.Empty = true;
                    return View("AddAdmin");
                }
                else
                {
                    System.Threading.Thread.Sleep(2000);

                    String Admin_Email = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Email FROM ADMINS WHERE Email ='" + admin.Email + "'").FirstOrDefault<String>();

                    String password = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Password FROM ADMINS WHERE Password ='" + admin.Password + "'").FirstOrDefault<String>();


                    if (admin.Email.Equals(Admin_Email) && admin.Password.Equals(password))
                    {

                        ViewBag.Found = true;
                        System.Threading.Thread.Sleep(2000);

                        return View("AddAdmin");

                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000);
                        new DB_CONNECTION().Database.ExecuteSqlCommand
                                   ("INSERT INTO ADMINS (Email , Password) VALUES ('" + admin.Email + "'," + "'" + admin.Password + "')");

                        ViewBag.isRight = true;

                        return View("AddAdmin");

                    }


                }
            }
            catch (Exception e)
            {

                System.Threading.Thread.Sleep(2000);
                new DB_CONNECTION().Database.ExecuteSqlCommand
                           ("INSERT INTO ADMINS (Email , Password) VALUES ('" + admin.Email + "'," + "'" + admin.Password + "')");

                ViewBag.isRight = true;

                return View("AddAdmin");



            }

        }

        public void Create_User_Table(String Username)
        {



            new DB_CONNECTION().Database.ExecuteSqlCommand
                    ("CREATE TABLE " + Username + "(COURSE_ID int primary key)");



        }

        public ActionResult Search_Course_User(COURSE Course)
        {

            try
            {
                int ID = 0;
                int ID2 = 0;
                ID = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + Course.Course_ID + "AND Course_ID NOT IN (SELECT COURSE_ID FROM " + Course.Course_Name + ")").FirstOrDefault<int>();
                String USERNAME = new DB_CONNECTION().Database.SqlQuery<String>("SELECT User_name FROM USERs WHERE User_name = '" + Course.Course_Name + "'").FirstOrDefault<String>();

                if (ID != 0)
                {
                    ID2 = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + ID + "AND Max_Students_Number != 0 ").FirstOrDefault<int>();

                    if (ID2 != 0)
                    {
                        int COURSE_MIN = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Min FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<int>();
                        
                        String COURSE_DAY = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Day FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<String>();
                        
                        String COURSE_PLACE = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Place FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<String>();
                        
                        int MAX_STD_NUM = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Max_Students_Number FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<int>();
                        
                        int COURSE_ID = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<int>();
                        
                        String COURSE_NAME = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Name FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<String>();
                        
                        int COURSE_HOUR = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Hours FROM COURSEs WHERE Course_ID = " + Course.Course_ID).FirstOrDefault<int>();
                        
                        ViewBag.USERNAME = USERNAME;

                        List<COURSE> COURSE_LIST = new List<COURSE>();

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

                        ViewBag.Empty = false;

                        ViewBag.Courses = COURSE_LIST;

                        return View("User");
                    }
                    else
                    {
                        ViewBag.USERNAME = USERNAME;

                        ViewBag.Empty = true;

                        return View("User");
                    }

                }
                else
                {
                    ViewBag.USERNAME = USERNAME;

                    ViewBag.Empty = true;

                    return View("User");
                }
            }
            catch (Exception e)
            {
                ViewBag.Empty = true;

                return View("User");
            }
        }
        public JsonResult Add_Course(String Course_ID, String Course_Name, String Course_Hours, String Course_Min, String Course_Day, String Course_Place, String Max_Students_Number)
        {
            bool ADDED = false;

            if (Course_ID == null || Course_Name == null || Course_Hours == null || Course_Min == null || Course_Day == null || Course_Place == null || Max_Students_Number == null)
            {
                return Json(ADDED, JsonRequestBehavior.AllowGet);
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
        public JsonResult Edit_Course(String Course_ID, String Course_Name, String Course_Hours, String Course_Min, String Course_Day, String Course_Place, String Max_Students_Number)
        {
            bool EDITED = false;

            if (Course_ID == null || Course_Name == null || Course_Hours == null || Course_Min == null || Course_Day == null || Course_Place == null || Max_Students_Number == null)
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

        
        public JsonResult Enroll_Course(int Course_ID, String User_Name) 
        {
            
            bool IS_ENROLLED;

            try
            {
                int Enrolled_Courses = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(Course_ID) FROM " + User_Name).FirstOrDefault<int>();

                if (Enrolled_Courses == 7)
                {
                    IS_ENROLLED = false;

                    return Json(IS_ENROLLED, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO " + User_Name + "(COURSE_ID) VALUES(" + Course_ID + ")");

                    new DB_CONNECTION().Database.ExecuteSqlCommand("UPDATE COURSEs SET Max_Students_Number = Max_Students_Number - 1 WHERE Course_ID = " + Course_ID);

                    IS_ENROLLED = true;

                    return Json(IS_ENROLLED,JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                IS_ENROLLED = false;

                return Json(IS_ENROLLED, JsonRequestBehavior.AllowGet);

            }
            
        }
        
        public JsonResult Drop_Course(int Course_ID, String User_Name) 
        {
            bool DROPPED = false;

            try
            {
                new DB_CONNECTION().Database.ExecuteSqlCommand("DELETE FROM " + User_Name + " WHERE Course_ID =" + Course_ID);

                new DB_CONNECTION().Database.ExecuteSqlCommand("UPDATE COURSEs SET Max_Students_Number = Max_Students_Number + 1 WHERE Course_ID = " + Course_ID);

                DROPPED = true;

                return Json(DROPPED,JsonRequestBehavior.AllowGet);

            }
            catch
            {
                

                return Json(DROPPED,JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult Search_Course(int Course_ID)
        {
            Object[] array = new Object[7];
            try
            {
                int id = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM Courses WHERE Course_ID = " + Course_ID  ).FirstOrDefault<int>();
                if (Course_ID == id )
                {
                    string name = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Name FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<String>();
                    int hours = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Hours FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<int>();
                    int min = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_Min FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<int>(); 
                    string day = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Day FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<String>(); 
                    string place = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Place FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<String>(); 
                    int stdnum = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Max_Students_Number FROM Courses WHERE Course_ID = " + Course_ID).FirstOrDefault<int>();

                    array[0] = id;
                    array[1] = name;
                    array[2] = hours;
                    array[3] = min;
                    array[4] = day;
                    array[5] = place;
                    array[6] = stdnum;
                    return Json(array,JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(array, JsonRequestBehavior.AllowGet);
                }
            }

            catch (Exception e)
            {
                return Json(array, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult Delete_Course(int Course_ID)
        {
            bool deleted = false;
            if (Course_ID != 0)
            {
                try
                {
                    new DB_CONNECTION().Database.ExecuteSqlCommand("Delete From Courses Where Course_ID =  " + Course_ID);
                    deleted = true;
                    return Json(deleted, JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {
                    return Json(deleted, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(deleted, JsonRequestBehavior.AllowGet);
            }

        }

        //Un essential functions//
        public JsonResult Check_ID(int Course_ID)
        {

            int ID = new DB_CONNECTION().Database.SqlQuery<int>("SELECT Course_ID FROM COURSEs WHERE Course_ID = " + Course_ID).FirstOrDefault<int>();

            bool resid;

            if (ID == Course_ID)
                resid = false;
            else
                resid = true;


            return Json(resid, JsonRequestBehavior.AllowGet);
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


        public JsonResult Course_Details(String Username)
        {

            int i;

            int n = new DB_CONNECTION().Database.SqlQuery<int>("SELECT COUNT(COURSE_ID) FROM " + Username).FirstOrDefault<int>();

            String[] User_Courses = new String[n];

            if (n != 0)
            {
                
                int[] Courses_IDS = new int[n];

                new DB_CONNECTION().Database.ExecuteSqlCommand("INSERT INTO TEMP(ID)(SELECT COURSE_ID FROM " + Username + ")");

                for (i = 0; i < n; i++)
                {
                    Courses_IDS[i] = new DB_CONNECTION().Database.SqlQuery<int>("SELECT TOP 1 ID FROM TEMP").FirstOrDefault<int>();

                    new DB_CONNECTION().Database.ExecuteSqlCommand("DELETE TOP (1) FROM TEMP");

                }



                for (i = 0; i < n; i++)
                {

                    User_Courses[i] = new DB_CONNECTION().Database.SqlQuery<String>("SELECT Course_Name FROM COURSEs WHERE Course_ID = " + Courses_IDS[i]).FirstOrDefault<String>();

                }

                return Json(User_Courses, JsonRequestBehavior.AllowGet);

            }
            else
            {
                

                return Json(User_Courses, JsonRequestBehavior.AllowGet);
            }


        }
    }
}