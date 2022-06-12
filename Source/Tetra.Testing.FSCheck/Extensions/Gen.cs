using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Gen_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second)> TwoValueTuples<T>(this Gen<T> source)
      => source
        .Two()
        .Select(x => (x.Item1, x.Item2));

   /* ------------------------------------------------------------ */
}