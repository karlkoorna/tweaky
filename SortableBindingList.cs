using System;
using System.Collections.Generic;
using System.ComponentModel;

class SortableBindingList<T> : BindingList<T> {

	PropertyDescriptor sortProperty;
	ListSortDirection sortDirection;
	bool isSorted = false;
	
	protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction) {
		((List<T>) Items).Sort(new Comparison<T>((T x, T y) => ((IComparable) property.GetValue(x)).CompareTo(property.GetValue(y)) * (direction == ListSortDirection.Ascending ? -1 : 1)));

		sortProperty = property;
		sortDirection = direction;
		isSorted = true;
	}

	protected override void RemoveSortCore() {
		sortProperty = null;
		sortDirection = ListSortDirection.Ascending;
		isSorted = false;
	}

	protected override bool SupportsSortingCore {
		get { return true; }
	}

	protected override ListSortDirection SortDirectionCore {
		get { return sortDirection; }
	}

	protected override PropertyDescriptor SortPropertyCore {
		get { return sortProperty; }
	}

	protected override bool IsSortedCore {
		get { return isSorted; }
	}

}
