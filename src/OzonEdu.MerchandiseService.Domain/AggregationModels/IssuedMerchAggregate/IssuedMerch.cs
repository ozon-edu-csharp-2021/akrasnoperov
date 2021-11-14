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
		public DateTimeOffset IssueDate { get; }

		/// <summary>
		/// <see cref="IssuedMerchAggregate.Quantity"/>.
		/// </summary>
		public Quantity Quantity { get; }

		/// <summary>
		/// <see cref="IssuedMerchAggregate.Status"/>.
		/// </summary>
		public Status Status { get; }

		/// <summary>
		/// Идентификатор <see cref="Merch"/>.
		/// </summary>
		public long MerchId { get; }

		/// <summary>
		/// <see cref="MerchAggregate.Merch"/>.
		/// </summary>
		public Merch Merch { get; }

		/// <summary>
		/// Идентификатор <see cref="Employee"/>.
		/// </summary>
		public long EmployeeId { get; }

		/// <summary>
		/// <see cref="EmployeeAggregate.Employee"/>.
		/// </summary>
		public Employee Employee { get; }

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