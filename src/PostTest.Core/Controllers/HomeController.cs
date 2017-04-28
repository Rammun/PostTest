using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View();
        }
        
        [HttpPost]
        public IActionResult ParcelRegister([FromBody]ParcelRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Ok(false);
            }

            try
            {
                var parcel = Mapper.Map<ParcelRegisterViewModel, Parcel>(model);

                _dbContext.Parcels.Add(parcel);
                _dbContext.SaveChanges();

                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult ParcelSearch(string search = null)
        {
            try
            {
                var parcels = _dbContext
                    .Parcels
                    .Include(r => r.Recipient)
                    .Include(s => s.Sender);

                IEnumerable<Parcel> answer = parcels;

                if (!string.IsNullOrEmpty(search))
                {
                    answer = parcels
                        .Where(x =>
                            x.Recipient.Address.Contains(search) ||
                            x.Recipient.FirstName.Contains(search) ||
                            x.Recipient.LastName.Contains(search) ||
                            x.Recipient.Patronymic.Contains(search) ||
                            x.Sender.Address.Contains(search) ||
                            x.Sender.FirstName.Contains(search) ||
                            x.Sender.LastName.Contains(search) ||
                            x.Sender.Patronymic.Contains(search));
                }

                var result = Mapper.Map<IEnumerable<Parcel>, IEnumerable<ParcelViewModel>>(answer.ToList());
                return PartialView("_ParcelSearch", result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
