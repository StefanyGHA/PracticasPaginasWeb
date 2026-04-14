using HospitalProyect.Data;
using HospitalProyect.Models;

namespace HospitalProyect.Repositories
{
	public class StaffCategoryRepository
	{
		private readonly ApplicationDbContext _applicationDbContext;

		public StaffCategoryRepository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public List<SpecialtyModel> GetAll()
		{
			return _applicationDbContext.SpecialtyModel.ToList();
		}

		public SpecialtyModel GetById(int id)
		{
			return _applicationDbContext.SpecialtyModel.FirstOrDefault(p => p.Id == id);
		}

		public void Add(SpecialtyModel specialtyModel)
		{
			_applicationDbContext.SpecialtyModel.Add(specialtyModel);
			_applicationDbContext.SaveChanges();
		}

		public void Update(SpecialtyModel specialtyModel)
		{
			_applicationDbContext.SpecialtyModel.Update(specialtyModel);
			_applicationDbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var specialty = _applicationDbContext.SpecialtyModel.Find(id);

			if (specialty != null)
			{
				_applicationDbContext.SpecialtyModel.Remove(specialty);
				_applicationDbContext.SaveChanges();
			}
		}

		public void Add(StaffCategoryModel staffCategoryModel)
		{
			throw new NotImplementedException();
		}

		public void Update(StaffCategoryModel staffCategoryModel)
		{
			throw new NotImplementedException();
		}
	}
}
