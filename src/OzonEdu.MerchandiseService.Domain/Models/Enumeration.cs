using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OzonEdu.MerchandiseService.Domain.Models
{
	/// <summary>
	/// Общий класс для "Перечислений". Используется, когда не хватает стандартного enum.
	/// See https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Services/Ordering/Ordering.Domain/SeedWork/Enumeration.cs
	/// </summary>
	public abstract class Enumeration : IComparable
	{
		/// <summary>
		/// Имя.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; private set; }

		protected Enumeration(int id, string name) => (Id, Name) = (id, name);

		/// <inheritdoc />
		public override string ToString() => Name;

		/// <summary>
		/// Возвращает все элементы "перечисления".
		/// </summary>
		public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
			typeof(T).GetFields(BindingFlags.Public |
								BindingFlags.Static |
								BindingFlags.DeclaredOnly)
				.Select(f => f.GetValue(null))
				.Cast<T>();

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			if (obj is not Enumeration otherValue)
			{
				return false;
			}

			var typeMatches = GetType().Equals(obj.GetType());
			var valueMatches = Id.Equals(otherValue.Id);

			return typeMatches && valueMatches;
		}

		public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
	}
}