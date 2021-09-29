﻿using AutoMapper;
using System.Collections.Generic;
using Faculty.DataAccessLayer.Models;
using Faculty.BusinessLayer.Interfaces;
using Faculty.BusinessLayer.Dto.Curator;
using Faculty.DataAccessLayer.Repository;

namespace Faculty.BusinessLayer.Services
{
    public class CuratorService : ICuratorService
    {
        private readonly IRepository<Curator> _repositoryCurator;

        public CuratorService(IRepository<Curator> repositoryCurator)
        {
            _repositoryCurator = repositoryCurator;
        }

        public IEnumerable<CuratorDisplayModifyDto> GetAll()
        {
            var models = _repositoryCurator.GetAll();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new SourceMappingProfile()));
            var mapper = new Mapper(mapperConfiguration);
            return mapper.Map<IEnumerable<Curator>, IEnumerable<CuratorDisplayModifyDto>>(models);
        }

        public void Create(CuratorAddDto modelDto)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new SourceMappingProfile()));
            var mapper = new Mapper(mapperConfiguration);
            _repositoryCurator.Insert(mapper.Map<CuratorAddDto, Curator>(modelDto));
        }

        public void Delete(int id)
        {
            var model = _repositoryCurator.GetById(id);
            _repositoryCurator.Delete(model);
        }

        public CuratorDisplayModifyDto GetById(int id)
        {
            var model = _repositoryCurator.GetById(id);
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new SourceMappingProfile()));
            var mapper = new Mapper(mapperConfiguration);
            return mapper.Map<Curator, CuratorDisplayModifyDto>(model);
        }

        public void Edit(CuratorDisplayModifyDto modelDto)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new SourceMappingProfile()));
            var mapper = new Mapper(mapperConfiguration);
            _repositoryCurator.Update(mapper.Map<CuratorDisplayModifyDto, Curator>(modelDto));
        }
    }
}
