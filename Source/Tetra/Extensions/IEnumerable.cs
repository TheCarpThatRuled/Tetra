namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class IEnumerable_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static ISequence<T> Materialise<T>
   (
      this IEnumerable<T> sequence
   )
      => sequence switch
         {
            Sequence<T> s => s,
            T[] array     => new((T[]) array.Clone()),
            List<T> list  => new(list.ToArray()),
            _             => new(sequence.ToArray()),
         };

   /* ------------------------------------------------------------ */

   public static IEnumerable<(T item, int index)> WithIndices<T>
   (
      this IEnumerable<T> sequence
   )
      => sequence
        .Select(
            (
                  x,
                  i
               ) => (x, i));

   /* ------------------------------------------------------------ */
}