using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLayer.Repostitory
{
    public class MedicineRepository
    {
        private readonly ClinicalDbContext _context;
        public MedicineRepository() 
        {
            _context = new ClinicalDbContext();
        }

        public List<Medicine> GetAllMedicines()
        {
            return _context.Medicines.ToList();
        }

        public Medicine GetMedicineById(int medicineId)
        {
            return _context.Medicines.Find(medicineId);
        }
        public IEnumerable<Medicine> FindMedicineByName(string Name)
        {
            return _context.Medicines.Where(meds => meds.MedicineName.ToLower().Contains(Name.ToLower()));
        }

        public void AddMedicine(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
        }
        
        public void UpdateMedicine(Medicine medicine)
        {
            _context.Entry(medicine).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMedicine(int medicineId)
        {
            var medicine = _context.Medicines.Find(medicineId);
            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }
        public Admin FindAdminByEmail(string email)
        {
            return _context.Admins.FirstOrDefault(m => m.EmailId.ToLower() == email.ToLower());
        }

        public bool checkAdminLogin(Admin admin)
        {
            return _context.Admins.Any(e => e.EmailId == admin.EmailId && e.Password == admin.Password);
        }

        public void UpdateAdmin(Admin ad)
        {
            _context.Entry(ad).State = EntityState.Modified;
            _context.SaveChanges();
        }
       
        public float CalculateDiscountedPrice(float price, float tax)
        {
            float discount_amount = ((price * 10) / 100);
            tax=price * tax/100;
            return ((price + tax) - discount_amount);
        }
    }
}
