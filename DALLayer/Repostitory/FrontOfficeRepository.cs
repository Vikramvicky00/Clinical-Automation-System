using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALLayer.Repostitory
{
  public class FrontOfficeRepository
    {
        private ClinicalDbContext _context;
        public FrontOfficeRepository() 
        {
            _context = new ClinicalDbContext();
        }

        public List<FrontOfficeExecutive> GetAllFrontOfficeExecutives()
        {
            return _context.FrontOfficeExecutives.ToList();
        }

        public FrontOfficeExecutive GetFrontOfficeExecutiveById(int frontOfficeExecutiveId)
        {
            return _context.FrontOfficeExecutives.Find(frontOfficeExecutiveId);
        }

        public void AddFrontOfficeExecutive(FrontOfficeExecutive frontOfficeExecutive)
        {
            _context.FrontOfficeExecutives.Add(frontOfficeExecutive);
            _context.SaveChanges();
        }
        public bool checkFOLogin(FrontOfficeExecutive front)
        {
            return _context.FrontOfficeExecutives.Any(d => d.Email == front.Email && d.Password == front.Password);
        }
        public void UpdateFrontOfficeExecutive(FrontOfficeExecutive frontOfficeExecutive)
        {
            _context.Entry(frontOfficeExecutive).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteFrontOfficeExecutive(int frontOfficeExecutiveId)
        {
            var frontOfficeExecutive = _context.FrontOfficeExecutives.Find(frontOfficeExecutiveId);
            _context.FrontOfficeExecutives.Remove(frontOfficeExecutive);
            _context.SaveChanges();
        }

        public bool FrontOfficeExecutiveExists(int frontOfficeExecutiveId)
        {
            return _context.FrontOfficeExecutives.Any(e => e.FrontOffExecutiveId == frontOfficeExecutiveId);
        }

        public FrontOfficeExecutive FindFrontOfficeByEmail(string Email)
        {
            return _context.FrontOfficeExecutives.FirstOrDefault(m => m.Email.ToLower() == Email.ToLower()); ;
        }

    }
}
