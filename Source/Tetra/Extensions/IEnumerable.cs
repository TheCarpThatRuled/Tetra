using System.Text;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class IEnumerable_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static ISequence<T> Materialise<T>(this IEnumerable<T> sequence)
      => null;

   /* ------------------------------------------------------------ */

   public static IEnumerable<(T item, int index)> WithIndices<T>(this IEnumerable<T> sequence)
      => sequence
        .Select((x,
                 i) => (x, i));

   /* ------------------------------------------------------------ */
}