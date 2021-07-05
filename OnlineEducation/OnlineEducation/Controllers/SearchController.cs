﻿using OnlineEducation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineEduDB;
using OnlineEducation.Paging;

namespace OnlineEducation.Controllers
{
    public class SearchController : Controller
    {
        CourseDAO courseDAO = new CourseDAO();
        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {   
            string textSearch = Request["txtSearch"];
            int index = 1;
            try
            {
                index = Convert.ToInt32(Request["index"]);
            }
            catch (Exception)
            {
                index = 1;
            }
            List<Course> List = courseDAO.getListCourseByName(textSearch);
            int maxItemOnPage = 3;
            int totalItem = List.Count;
            PageRequest page = new PageRequest(index, maxItemOnPage);
            int totalPage = (int)Math.Ceiling((double)totalItem / maxItemOnPage);
            List<Course> ListCourse = courseDAO.getListByOffset(page,textSearch);
            ViewBag.ListCourse = ListCourse;
            ViewBag.txtSearch = textSearch;
            ViewBag.totalPae = totalPage;
            ViewBag.totalItem = totalItem;
            return View();
        }
    }
}