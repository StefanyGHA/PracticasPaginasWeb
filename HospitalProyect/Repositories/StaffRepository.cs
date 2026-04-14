using HospitalProyect.Data;
using HospitalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalProyect.Repositories
{
	public class StaffRepository
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public StaffRepository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public List<StaffModel> GetAll()
		{
			return _applicationDbContext.StaffModel
				.Include(s => s.StaffCategory)
				.Include(s => s.Specialty)
				.ToList();
		}

		public StaffModel GetById(int id)
		{
			return _applicationDbContext.StaffModel
				.Include(s => s.StaffCategory)
				.Include(s => s.Specialty)
				.FirstOrDefault(sm => sm.Id == id);
		}

		public void Add(StaffModel staffModel)
		{
			if (staffModel.StaffCategoryId <= 0)
			{
				throw new Exception("Debe seleccionar una categoría válida.");
			}

			var categoryExists = _applicationDbContext.StaffCategoryModel
				.Any(c => c.Id == staffModel.StaffCategoryId);

			if (!categoryExists)
			{
				throw new Exception($"No existe una categoría con Id = {staffModel.StaffCategoryId}");
			}

			_applicationDbContext.StaffModel.Add(staffModel);
			_applicationDbContext.SaveChanges();
		}

		public void Update(StaffModel StaffModel)
		{
			_applicationDbContext.StaffModel.Update(StaffModel);
			_applicationDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var staff = _applicationDbContext.StaffModel.Find(id);

			if (staff != null)
			{
				_applicationDbContext.StaffModel.Remove(staff);
				_applicationDbContext.SaveChanges();
			}
		}
	}
}
