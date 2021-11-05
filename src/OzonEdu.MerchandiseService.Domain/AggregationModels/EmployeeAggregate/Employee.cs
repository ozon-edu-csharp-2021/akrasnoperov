using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
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
		/// Электронная почта.
		/// </summary>
		public Email Email { get; }

		/// <summary>
		/// Список выданного мерча сотруднику <see cref="IssuedMerch"/>.
		/// </summary>
		public ICollection<IssuedMerch> IssuedMerches { get; set; }

		/// <summary>
		/// .ctor
		/// </summary>
		public Employee(
			ClothingSize clothingSize,
			Email email)
		{
			ClothingSize = clothingSize;
			Email = email;
			IssuedMerches = new HashSet<IssuedMerch>();
		}

		/// <summary>
		/// Проверяет, что мерч подходит по размеру сотруднику, если у мерча есть размер.
		/// Если у мерча нет размера, то считаем, что мерч подходит.
		/// </summary>
		/// <param name="merch"></param>
		/// <returns>True, если мерч подходит по размеру.</returns>
		public bool IsMerchFit(Merch merch)
		{
			return merch.ClothingSize is null || ClothingSize.Equals(merch.ClothingSize);
		}

		/// <summary>
		/// Проверяет, выдавался ли такой же мерч сотруднику меньше года назад.
		/// </summary>
		/// <param name="merch">Новый мерч для выдачи сотруднику <see cref="Merch"/>.</param>
		/// <param name="issueDate">Дата выдачи нового мерча.</param>
		/// <returns>True, если выдавался такой же мерч меньше года назад.</returns>
		public bool HasIssuedMerch(
			Merch merch,
			DateTimeOffset issueDate)
		{
			var issuedMerch = IssuedMerches
				.Where(_ => _.MerchId == merch.Id)
				.OrderByDescending(_ => _.IssueDate)
				.FirstOrDefault();
			if (issuedMerch is null)
			{
				return false;
			}

			// Такой же мерч выдавался сотруднику меньше года назад.
			return issuedMerch.IssueDate.AddYears(1) > issueDate;
		}
	}
}