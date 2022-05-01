﻿using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Faculty.DataAccessLayer.Models;
using Faculty.BusinessLayer.Interfaces;
using Faculty.Common.Dto.Student;
using Faculty.DataAccessLayer.Repository;

namespace Faculty.BusinessLayer.Services
{
    /// <summary>
    /// Student service.
    /// </summary>
    public class StudentService : IStudentService
    {
        /// <summary>
        /// Model repository.
        /// </summary>
        private readonly IRepository<Student> _repositoryStudent;

        /// <summary>
        /// Auto mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for init repository.
        /// </summary>
        /// <param name="repositoryStudent">Model repository.</param>
        /// <param name="mapper">Mapper.</param>
        public StudentService(IRepository<Student> repositoryStudent, IMapper mapper)
        {
            _repositoryStudent = repositoryStudent;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for receive set of entity.
        /// </summary>
        /// <returns>Dto set.</returns>
        public IEnumerable<StudentDto> GetAll()
        {
            var models = _repositoryStudent.GetAll().ToList();
            return _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(models);
        }

        /// <summary>
        /// Method for creating a new entity.
        /// </summary>
        /// <param name="dto">Add Dto.</param>
        public StudentDto Create(StudentDto dto)
        {
            var specialization = _repositoryStudent.Insert(_mapper.Map<StudentDto, Student>(dto));
            var specializationDto = _mapper.Map<Student, StudentDto>(specialization);
            return specializationDto;
        }

        /// <summary>
        /// Method for receive dto set.
        /// </summary>
        /// <param name="id">Id exist entity.</param>
        /// <returns>Modify Dto.</returns>
        public void Delete(int id)
        {
            var model = _repositoryStudent.GetById(id);
            _repositoryStudent.Delete(model);
        }

        /// <summary>
        /// Method for receive dto.
        /// </summary>
        /// <param name="id">Id exist entity.</param>
        /// <returns>Modify Dto.</returns>
        public StudentDto GetById(int id)
        {
            var model = _repositoryStudent.GetById(id);
            return _mapper.Map<Student, StudentDto>(model);
        }

        /// <summary>
        /// Method for changing a exist entity.
        /// </summary>
        /// <param name="dto">Modify Dto.</param>
        public void Edit(StudentDto dto)
        {
            _repositoryStudent.Update(_mapper.Map<StudentDto, Student>(dto));
        }
    }
}