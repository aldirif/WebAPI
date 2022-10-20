﻿using Microsoft.EntityFrameworkCore;
using MyBackendProject.DAL;
using MyBackendProject.Models;

namespace MyBackendProject.DAL
{
    public class EnrollmentEF : IEnrollment
    {
        private AppDbContext _dbcontext;
        public EnrollmentEF(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Delete(int id)
        {
            var deleteEnrollment = GetById(id);
            if (deleteEnrollment == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            try
            {
                _dbcontext.Remove(deleteEnrollment);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Enrollment> GetAll()
        {
            var results = _dbcontext.Enrollments.OrderBy(s => s.EnrollmentID).ToList();
            return results;
        }

        public Enrollment GetById(int id)
        {
            var result = _dbcontext.Enrollments.FirstOrDefault(s => s.EnrollmentID == id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            return result;
        }
        public Enrollment Insert(Enrollment enrollment)
        {
            try
            {
                _dbcontext.Enrollments.Add(enrollment);
                _dbcontext.SaveChanges();
                return enrollment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}