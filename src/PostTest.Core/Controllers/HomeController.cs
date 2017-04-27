using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PostTest.Core.Data;
using PostTest.Core.Entities;
using PostTest.Core.Models;

namespace PostTest.Core.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(PostDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var parcels = _dbContext
                .Parcels
                .Include(r => r.Recipient)
                .Include(s => s.Sender)
                .ToList();

            ViewBag.Parcels = _mapper.Map<IEnumerable<Parcel>, IEnumerable<ParcelViewModel>>(parcels);
            ViewBag.Register = new ParcelRegisterViewModel();

            return View();
        }

        [HttpGet]
        public ActionResult ParcelRegister()
        {
            var parcel = new ParcelRegisterViewModel();

            return PartialView("_ParcelRegister", parcel);
        }

        [HttpPost]
        public IActionResult ParcelRegister([FromBody]ParcelRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var parcel = Mapper.Map<ParcelRegisterViewModel, Parcel>(model);

                _dbContext.Parcels.Add(parcel);
                _dbContext.SaveChanges();

                return Ok(true);
                //return PartialView("_ParcelRegister", new ParcelRegisterViewModel());
            }

            return Ok(false);
            //return PartialView("_ParcelRegister", model);

            //var parcels =_mapper.Map<IEnumerable<Parcel>, IEnumerable<ParcelViewModel>>(_dbContext.Parcels.ToList());
            //return PartialView("_ParselSearch", parcels);
        }

        [HttpGet]
        public ActionResult ParcelSearch(string search = null)
        {
            var parcels = _dbContext
                 .Parcels
                 .Include(r => r.Recipient)
                 .Include(s => s.Sender)
                 .ToList();

            var result = Mapper.Map<IEnumerable<Parcel>, IEnumerable<ParcelViewModel>>(parcels);

            if (string.IsNullOrEmpty(search))
            {
                return PartialView("_ParcelSearch", result);
            }

            var filterResult = result
                                .Where(x =>
                                        x.RecipientAdress.Contains(search) ||
                                        x.SenderAdress.Contains(search) ||
                                        x.RecipientFullName.Contains(search) ||
                                        x.SenderFullName.Contains(search))
                                .ToList();

            return PartialView("_ParcelSearch", filterResult);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
