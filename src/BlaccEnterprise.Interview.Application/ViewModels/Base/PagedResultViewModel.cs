using System;
using System.Collections.Generic;

using BlaccEnterprise.Interview.Application.ViewModels.Base.Interfaces;

namespace BlaccEnterprise.Interview.Application.ViewModels.Base
{
    public class PagedResultViewModel<T>
	{
		private IReadOnlyList<T> _items;
		public IReadOnlyList<T> Items
		{
			get { return _items ??= new List<T>(); }
			set { _items = value; }
		}

		public int TotalCount { get; private set; }

		public bool HasPrevious { get; private set; }
		public bool HasNext { get; private set; }

		public PagedResultViewModel(IReadOnlyList<T> items, int totalCount, IPagedAndSortedResultViewModelBase input)
		{
			TotalCount = totalCount;
			Items = items;

			HasPrevious = input.SkipCount > 0;
			HasNext = input.SkipCount + input.MaxResultCount > TotalCount;
		}
	}
}