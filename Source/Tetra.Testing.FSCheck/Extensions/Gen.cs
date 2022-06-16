using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Gen_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Gen<T2> Combine<T0, T1, T2>(this Gen<T0>     source0,
                                             Gen<T1>          source1,
                                             Func<T0, T1, T2> map)
      => Gen
        .Zip(source0,
             source1)
        .Select(tuple => map(tuple.Item1,
                             tuple.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second, T third)> ThreeValueTuples<T>(this Gen<T> source)
      => source
        .Three()
        .Select(x => (x.Item1, x.Item2, x.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second)> TwoValueTuples<T>(this Gen<T> source)
      => source
        .Two()
        .Select(x => (x.Item1, x.Item2));

   /* ------------------------------------------------------------ */
}