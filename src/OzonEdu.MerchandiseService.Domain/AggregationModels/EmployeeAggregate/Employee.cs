using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	/// <summary>
	/// Entity, описывающая Employee.
	/// </summary>
	public class Employee : Entity
	{
		/// <summary>
		/// <see cref="MerchAggregate.ClothingSize"/>.
		/// </summary>
		public ClothingSize ClothingSize { get; }

		/// <summary>
		/// Список выданного Merch сотруднику <see cref="Merch"/>.
		/// Ключ - <see cref="Merch"/>, значение - дата выдачи.
		/// </summary>
		public IDictionary<Merch, DateTimeOffset> IssuedMerches { get; set; }

		/// <summary>
		/// .ctor
		/// </summary>
		public Employee(ClothingSize clothingSize)
		{
			ClothingSize = clothingSize;
			IssuedMerches = new Dictionary<Merch, DateTimeOffset>();
		}

		/// <summary>
		/// Выдает <paramref name="merch"/> сотруднику, добавляя его в коллекцию <see cref="IssuedMerches"/>.
		/// </summary>
		/// <param name="merch"><see cref="Merch"/> для выдачи сотруднику.</param>
		/// <param name="issueDate">Дата выдачи мерча.</param>
		/// <exception cref="IssueIssuedMerchException"></exception>
		public void AddIssuedMerch(
			Merch merch,
			DateTimeOffset issueDate)
		{
			// Размер одежды сотрудника и размер мерча не совпадают.
			if (merch.ClothingSize is not null &&
				!merch.ClothingSize.Equals(ClothingSize))
			{
				throw new WrongClothingSizeException(ClothingSize, merch.ClothingSize);
			}
			var (issuedMerch, issuedMerchIssueDate) = IssuedMerches
				.Where(_ => _.Key.Sku.Equals(merch.Sku))
				.OrderByDescending(_ => _.Value).FirstOrDefault();
			if (issuedMerch is not null)
			{
				// Такой же мерч выдавался сотруднику меньше года назад.
				if (issuedMerchIssueDate.AddYears(1) > issueDate)
				{
					throw new IssueIssuedMerchException(merch.MerchType);
				}
			}
			IssuedMerches.Add(merch, issueDate);
		}

		/// <summary>
		/// Возвращает выданный сотруднику мерч.
		/// </summary>
		/// <returns>Список выданного мерча <see cref="Merch"/>.</returns>
		public IReadOnlyDictionary<Merch, DateTimeOffset> GetIssuedMerches()
		{
			return IssuedMerches.ToDictionary(_ => _.Key, _ => _.Value);
		}
	}
}