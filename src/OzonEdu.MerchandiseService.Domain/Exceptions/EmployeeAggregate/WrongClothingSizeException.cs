using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate
{
	/// <summary>
	/// Исключение для ситуаций, когда размер мерча и размер одежды сотрудника не совпадают.
	/// </summary>
	public class WrongClothingSizeException : Exception
	{
		/// <summary>
		/// .ctor
		/// </summary>
		public WrongClothingSizeException(
			ClothingSize employeeClothingSize,
			ClothingSize merchClothingSize)
			: base($"Размер одежды сотрудника {employeeClothingSize} не совпадает с размером мерча {merchClothingSize}.")
		{
		}
	}
}