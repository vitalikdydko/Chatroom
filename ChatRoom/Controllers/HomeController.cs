﻿using ChatRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoom.Controllers
{
     [Authorize]
    public class HomeController : Controller
    {
        
        
        
        public ActionResult About()
        {
            return View();
        }

    }
        }

   
