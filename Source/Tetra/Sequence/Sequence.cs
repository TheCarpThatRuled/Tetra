namespace Tetra;

public static class Sequence
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static ISequence<T> From<T>
   (
      params T[] array
   )
      => new Sequence<T>(array);

   /* ------------------------------------------------------------ */
}