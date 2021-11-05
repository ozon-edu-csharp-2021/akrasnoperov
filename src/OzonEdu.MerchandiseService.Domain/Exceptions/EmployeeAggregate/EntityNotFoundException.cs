using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate
{
	/// <summary>
	/// Исключение для ситуаций, когда не смогли найти Entity.
	/// </summary>
	public class EntityNotFoundException : Exception
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public EntityNotFoundException(string message) : base(message)
		{
		}
	}
}