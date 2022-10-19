﻿using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public interface IEnrollment
    {
        public IEnumerable<Enrollment> GetAll();
        public Enrollment GetById(int id);
        public Enrollment Insert(Enrollment enrollment);
        public Enrollment Update(Enrollment enrollment);
        public void Delete(int id);

    }
}