using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HospitalProyect.Models
{
	public class SpecialtyModel
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]

		public string Name { get; set; }

		public ICollection<StaffModel> StaffMembers { get; set; }
	}
}
