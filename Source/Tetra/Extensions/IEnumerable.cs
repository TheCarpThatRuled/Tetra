using System.Text;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class IEnumerable_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static IEnumerable<(T item, int index)> WithIndices<T>(this IEnumerable<T> sequence)
      where T : notnull
      => sequence
        .Select((x,
                 i) => (x, i));

   /* ------------------------------------------------------------ */
}