using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostTest.Core.Data;

namespace PostTest.Core.Controllers
{
    public class BaseController : Controller
    {
        protected PostDbContext _dbContext;

        public BaseController()
        {
            //_dbContext = new PostDbContext();
        }
    }
}
