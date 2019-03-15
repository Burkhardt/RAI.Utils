using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// from http://www.blackbeltcoder.com/Articles/linq/extending-linq-with-random-operations

namespace RaiUtilsCore
{
	public static class RandomExtensions
	{
		/// <summary>
		/// Returns a random element from a list, or null if the list is empty.
		/// </summary>
		/// <param name="rand">An instance of a random number generator</param>
		/// <param name="list">todo: describe list parameter on Random</param>
		/// <typeparam name="T">The type of object being enumerated</typeparam>
		/// <returns>A random element from a list, or null if the list is empty</returns>
		public static T Random<T>(this IEnumerable<T> list, Random rand)
		{
			if (list != null && list.Count() > 0)
				return list.ElementAt(rand.Next(list.Count()));
			return default(T);
		}
		/// <summary>
		/// Returns a shuffled IEnumerable.
		/// </summary>
		/// <param name="source">todo: describe source parameter on Shuffle</param>
		/// <typeparam name="T">The type of object being enumerated</typeparam>
		/// <returns>A shuffled shallow copy of the source items</returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.Shuffle(new Random());
		}
		/// <summary>
		/// Returns a shuffled IEnumerable.
		/// </summary>
		/// <param name="rand">An instance of a random number generator</param>
		/// <param name="source">todo: describe source parameter on Shuffle</param>
		/// <typeparam name="T">The type of object being enumerated</typeparam>
		/// <returns>A shuffled shallow copy of the source items</returns>
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rand)
		{
			var list = source.ToList();
			list.Shuffle(rand);
			return list;
		}
		/// <summary>
		/// Shuffles an IList in place.
		/// </summary>
		/// <param name="list">todo: describe list parameter on Shuffle</param>
		/// <typeparam name="T">The type of elements in the list</typeparam>
		public static void Shuffle<T>(this IList<T> list)
		{
			list.Shuffle(new Random());
		}
		/// <summary>
		/// Shuffles an IList in place.
		/// </summary>
		/// <param name="rand">An instance of a random number generator</param>
		/// <param name="list">todo: describe list parameter on Shuffle</param>
		/// <typeparam name="T">The type of elements in the list</typeparam>
		public static void Shuffle<T>(this IList<T> list, Random rand)
		{
			var count = list.Count;
			while (count > 1)
			{
				var i = rand.Next(count--);
				var temp = list[count];
				list[count] = list[i];
				list[i] = temp;
			}
		}
		// added by RSB
		/// <summary>
		/// takes a given number of elements randomly
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="take">number of elements to take; if this number is close to the total number of elements in source
		/// this function will create duplicates; use Distinct() on the result set to eliminate them (which of course can lead to a smaller count in the result set)
		/// </param>
		/// <remarks>ImageController implements a solution for this</remarks>
		/// <returns>take elements randomly picked (or less)</returns>
		public static IEnumerable<T> TakeAny<T>(this IEnumerable<T> source, int take)
		{
			var rand = new Random();
			var count = source.Count();
			while (take-- > 0)
				yield return source.ElementAt(rand.Next(count));
		}
	}
}
