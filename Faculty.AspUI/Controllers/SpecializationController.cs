﻿using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Faculty.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Faculty.AspUI.ViewModels.Specialization;
using Faculty.BusinessLayer.Dto.Specialization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Faculty.AspUI.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "administrator")]
    public class SpecializationController : Controller
    {
        private readonly ISpecializationService _specializationService;
        private readonly IMapper _mapper;

        public SpecializationController(ISpecializationService specializationService, IMapper mapper)
        {
            _specializationService = specializationService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var modelsDto = _specializationService.GetAll();
            var models = _mapper.Map<IEnumerable<SpecializationDisplayModifyDto>, IEnumerable<SpecializationDisplayModify>>(modelsDto);
            return View(models.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SpecializationAdd model)
        {
            if (ModelState.IsValid == false) return View(model);
            var modelDto = _mapper.Map<SpecializationAdd, SpecializationAddDto>(model);
            _specializationService.Create(modelDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var modelDto = _specializationService.GetById(id);
            if (modelDto is null) return RedirectToAction("Index");
            var model = _mapper.Map<SpecializationDisplayModifyDto, SpecializationDisplayModify>(modelDto);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SpecializationDisplayModify model)
        {
            _specializationService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var modelDto = _specializationService.GetById(id);
            if (modelDto is null) return RedirectToAction("Index");
            var model = _mapper.Map<SpecializationDisplayModifyDto, SpecializationDisplayModify>(modelDto);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SpecializationDisplayModify model)
        {
            if (ModelState.IsValid == false) return View(model);
            var modelDto = _mapper.Map<SpecializationDisplayModify, SpecializationDisplayModifyDto>(model);
            _specializationService.Edit(modelDto);
            return RedirectToAction("Index");
        }
    }
}