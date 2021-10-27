﻿using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Faculty.DataAccessLayer.Models;
using Faculty.BusinessLayer.Interfaces;
using Faculty.DataAccessLayer.Repository;
using Faculty.BusinessLayer.Dto.Specialization;

namespace Faculty.BusinessLayer.Services
{
    /// <summary>
    /// Specialization service.
    /// </summary>
    public class SpecializationService : ISpecializationService
    {
        /// <summary>
        /// Model repository.
        /// </summary>
        private readonly IRepository<Specialization> _repositorySpecialization;

        /// <summary>
        /// Auto mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for init repository.
        /// </summary>
        /// <param name="repositorySpecialization">Model repository.</param>
        /// <param name="mapper">Mapper.</param>
        public SpecializationService(IRepository<Specialization> repositorySpecialization, IMapper mapper)
        {
            _repositorySpecialization = repositorySpecialization;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for receive set of entity.
        /// </summary>
        /// <returns>Dto set.</returns>
        public IEnumerable<SpecializationDisplayModifyDto> GetAll()
        {
            var models = _repositorySpecialization.GetAll().ToList();
            return _mapper.Map<IEnumerable<Specialization>, IEnumerable<SpecializationDisplayModifyDto>>(models); ;
        }

        /// <summary>
        /// Method for creating a new entity.
        /// </summary>
        /// <param name="dto">Add Dto.</param>
        public void Create(SpecializationAddDto dto)
        {
            _repositorySpecialization.Insert(_mapper.Map<SpecializationAddDto, Specialization>(dto));
        }

        /// <summary>
        /// Method for receive dto set.
        /// </summary>
        /// <param name="id">Id exist entity.</param>
        /// <returns>Modify Dto.</returns>
        public void Delete(int id)
        {
            var model = _repositorySpecialization.GetById(id);
            _repositorySpecialization.Delete(model);
        }

        /// <summary>
        /// Method for receive dto.
        /// </summary>
        /// <param name="id">Id exist entity.</param>
        /// <returns>Modify Dto.</returns>
        public SpecializationDisplayModifyDto GetById(int id)
        {
            var model = _repositorySpecialization.GetById(id);
            return _mapper.Map<Specialization, SpecializationDisplayModifyDto>(model);
        }

        /// <summary>
        /// Method for changing a exist entity.
        /// </summary>
        /// <param name="dto">Modify Dto.</param>
        public void Edit(SpecializationDisplayModifyDto dto)
        {
            _repositorySpecialization.Update(_mapper.Map<SpecializationDisplayModifyDto, Specialization>(dto));
        }
    }
}