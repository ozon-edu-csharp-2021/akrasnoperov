using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.IssuedMerchAggregate
{
	/// <summary>
	/// Entity, описывающая выданный мерч сотруднику.
	/// </summary>
	public class IssuedMerch : Entity
	{
		/// <summary>
		/// Дата и время выдачи мерча.
		/// </summary>
		public DateTimeOffset IssueDate { get; set; }

		/// <summary>
		/// <see cref="IssuedMerchAggregate.Quantity"/>.
		/// </summary>
		public Quantity Quantity { get; set; }

		/// <summary>
		/// <see cref="IssuedMerchAggregate.Status"/>.
		/// </summary>
		public Status Status { get; set; }

		/// <summary>
		/// Идентификатор <see cref="Merch"/>.
		/// </summary>
		public int MerchId { get; set; }

		/// <summary>
		/// <see cref="MerchAggregate.Merch"/>.
		/// </summary>
		public Merch Merch { get; set; }

		/// <summary>
		/// Идентификатор <see cref="Employee"/>.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// <see cref="EmployeeAggregate.Employee"/>.
		/// </summary>
		public Employee Employee { get; set; }

		/// <summary>
		/// .ctor
		/// </summary>
		public IssuedMerch(
			DateTimeOffset issueDate,
			Quantity quantity,
			Status status,
			Merch merch,
			Employee employee)
		{
			IssueDate = issueDate;
			Quantity = quantity;
			Status = status;
			MerchId = merch.Id;
			Merch = merch;
			EmployeeId = employee.Id;
			Employee = employee;
		}
	}
}