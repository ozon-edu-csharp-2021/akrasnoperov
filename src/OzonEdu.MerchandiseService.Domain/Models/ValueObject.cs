using System.Collections.Generic;
using System.Linq;

namespace OzonEdu.MerchandiseService.Domain.Models
{
	/// <summary>
	/// Общий класс для всех Value Object.
	/// See https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/ValueObject.cs
	/// </summary>
	public abstract class ValueObject
	{
		protected static bool EqualOperator(ValueObject left, ValueObject right)
		{
			if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
			{
				return false;
			}
			return ReferenceEquals(left, null) || left.Equals(right);
		}

		protected static bool NotEqualOperator(ValueObject left, ValueObject right)
		{
			return !(EqualOperator(left, right));
		}

		/// <summary>
		/// Возвращает список полей, по которым сравниваются 2 объекта.
		/// </summary>
		protected abstract IEnumerable<object> GetEqualityComponents();

		/// <inheritdoc />
		public override bool Equals(object? obj)
		{
			if (obj == null || obj.GetType() != GetType())
			{
				return false;
			}

			var other = (ValueObject)obj;

			return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return GetEqualityComponents()
				.Select(x => x != null ? x.GetHashCode() : 0)
				.Aggregate((x, y) => x ^ y);
		}

		public ValueObject GetCopy()
		{
			return MemberwiseClone() as ValueObject;
		}
	}
}