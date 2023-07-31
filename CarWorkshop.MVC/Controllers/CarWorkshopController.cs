﻿using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await _carWorkshopService.GetAll();

            return View(carWorkshops);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _carWorkshopService.Create(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
