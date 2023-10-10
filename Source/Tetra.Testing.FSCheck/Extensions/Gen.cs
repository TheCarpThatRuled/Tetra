using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
public static class Gen_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static Gen<T2> Combine<T0, T1, T2>
   (
      this Gen<T0>     source0,
      Gen<T1>          source1,
      Func<T0, T1, T2> map
   )
      => Gen
        .Zip(source0,
             source1)
        .Select(tuple => map(tuple.Item1,
                             tuple.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<T3> Combine<T0, T1, T2, T3>
   (
      this Gen<T0>         source0,
      Gen<T1>              source1,
      Gen<T2>              source2,
      Func<T0, T1, T2, T3> map
   )
      => Gen
        .Zip(source0,
             source1,
             source2)
        .Select(tuple => map(tuple.Item1,
                             tuple.Item2,
                             tuple.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<T4> Combine<T0, T1, T2, T3, T4>
   (
      this Gen<T0>             source0,
      Gen<T1>                  source1,
      Gen<T2>                  source2,
      Gen<T3>                  source3,
      Func<T0, T1, T2, T3, T4> map
   )
      => Gen
        .Zip(source0,
             source1,
             source2)
        .Zip(source3)
        .Select(tuple => map(tuple.Item1.Item1,
                             tuple.Item1.Item2,
                             tuple.Item1.Item3,
                             tuple.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second, T third, T four)> FourValueTuples<T>
   (
      this Gen<T> source
   )
      => source
        .Four()
        .Select(x => (x.Item1, x.Item2, x.Item3, x.Item4));

   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second, T third)> ThreeValueTuples<T>
   (
      this Gen<T> source
   )
      => source
        .Three()
        .Select(x => (x.Item1, x.Item2, x.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<(T first, T second)> TwoValueTuples<T>
   (
      this Gen<T> source
   )
      => source
        .Two()
        .Select(x => (x.Item1, x.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<(T0 first, T1 second)> ZipValueTuples<T0, T1>
   (
      this Gen<T0> first,
      Gen<T1>      second
   )
      => first
        .Zip(second)
        .Select(x => (x.Item1, x.Item2));

   /* ------------------------------------------------------------ */

   public static Gen<(T0 first, T1 second, T2 third)> ZipValueTuples<T0, T1, T2>
   (
      this Gen<T0> first,
      Gen<T1>      second,
      Gen<T2>      third
   )
      => first
        .Zip(second,
             third)
        .Select(x => (x.Item1, x.Item2, x.Item3));

   /* ------------------------------------------------------------ */
}