﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }
        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(seller => seller.Id == id);
        }

        public void RemoveById(int id)
        {
            var seller = _context.Seller.Find(id);
            if (seller == null) return;

            _context.Seller.Remove(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
                throw new NotFoundException("Id Not Found!");

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
