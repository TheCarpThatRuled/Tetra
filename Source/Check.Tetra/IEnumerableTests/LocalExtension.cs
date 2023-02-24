namespace Check.IEnumerableTests;
internal static class LocalExtension
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static IEnumerable<T> ToEnumerable<T>(this T[] array)
   {
      // ReSharper disable once LoopCanBeConvertedToQuery
      foreach (var item in array)
      {
         yield return item;
      }
   }

   /* ------------------------------------------------------------ */
}
