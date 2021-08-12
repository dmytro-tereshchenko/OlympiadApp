using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OlympiadLibrary
{
	public class JoinedEnumerable<T> : IEnumerable<T>
	{
		public readonly IEnumerable<T> Source;
		public bool IsOuter;

		public JoinedEnumerable(IEnumerable<T> source) { Source = source; }

		IEnumerator<T> IEnumerable<T>.GetEnumerator() { return Source.GetEnumerator(); }
		IEnumerator IEnumerable.GetEnumerator() { return Source.GetEnumerator(); }
	}
	public static class JoinedEnumerable
	{
		public static JoinedEnumerable<TElement> Inner<TElement>(this IEnumerable<TElement> source)
		{
			return Wrap(source, false);
		}

		public static JoinedEnumerable<TElement> Outer<TElement>(this IEnumerable<TElement> source)
		{
			return Wrap(source, true);
		}

		public static JoinedEnumerable<TElement> Wrap<TElement>(IEnumerable<TElement> source, bool isOuter)
		{
			JoinedEnumerable<TElement> joinedSource
				= source as JoinedEnumerable<TElement> ??
					new JoinedEnumerable<TElement>(source);
			joinedSource.IsOuter = isOuter;
			return joinedSource;
		}
	}
}
