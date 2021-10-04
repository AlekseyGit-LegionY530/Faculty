﻿using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Faculty.AspUI.ViewModels.Curator;
using Faculty.BusinessLayer.Interfaces;
using Faculty.BusinessLayer.Dto.Curator;

namespace Faculty.AspUI.Controllers
{
    public class CuratorController : Controller
    {
        private readonly ICuratorService _curatorService;
        private readonly IMapper _mapper;

        public CuratorController(ICuratorService curatorService, IMapper mapper)
        {
            _curatorService = curatorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var modelsDto = _curatorService.GetAll();
            var models = _mapper.Map<IEnumerable<CuratorDisplayModifyDto>, IEnumerable<CuratorDisplayModify>>(modelsDto);
            return View(models.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CuratorAdd model)
        {
            var modelDto = _mapper.Map<CuratorAdd, CuratorAddDto>(model);
            _curatorService.Create(modelDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var modelDto = _curatorService.GetById(id);
            if (modelDto is null) return RedirectToAction("Index");
            var model = _mapper.Map<CuratorDisplayModifyDto, CuratorDisplayModify>(modelDto);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(CuratorDisplayModify model)
        {
            _curatorService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var modelDto = _curatorService.GetById(id);
            if (modelDto is null) return RedirectToAction("Index");
            var model = _mapper.Map<CuratorDisplayModifyDto, CuratorDisplayModify>(modelDto);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CuratorDisplayModify model)
        {
            var modelDto = _mapper.Map<CuratorDisplayModify, CuratorDisplayModifyDto>(model);
            _curatorService.Edit(modelDto);
            return RedirectToAction("Index");
        }
    }
}
