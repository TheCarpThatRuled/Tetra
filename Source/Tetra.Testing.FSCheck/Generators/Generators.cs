using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

public static partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<T> NonNull<T>(Gen<T> source)
      where T : class
      => source
        .Where(x => x is not null);

   /* ------------------------------------------------------------ */

   public static Gen<(T, T, T)> Transitive<T>(Gen<(T, T)> source)
      where T : notnull
      => source
        .Apply(Gen.Elements<Func<(T a, T b), (T, T, T)>>
               (
                  //If a == b && b == c
                  tuple => (tuple.a, tuple.a, tuple.a),
                  //If a == b && b != c
                  tuple => (tuple.a, tuple.a, tuple.b),
                  //If a != b && b == c
                  tuple => (tuple.a, tuple.b, tuple.b)
                  //If a != b && b != c then the the equality of a to c cannot be predicted via the transitive property
               ));

   /* ------------------------------------------------------------ */

   public static Gen<(T0, T1, T1)> Transitive<T0, T1>(Gen<(T1, T1)> source,
                                                      Func<T1, T0> map)
      where T0 : notnull, IEquatable<T1>
      where T1 : notnull
      => source
        .Apply(Gen.Elements<Func<(T1 a, T1 b), (T0, T1, T1)>>
               (
                  //If a == b && b == c
                  tuple => (map(tuple.a), tuple.a, tuple.a),
                  //If a == b && b != c
                  tuple => (map(tuple.a), tuple.a, tuple.b),
                  //If a != b && b == c
                  tuple => (map(tuple.a), tuple.b, tuple.b)
                  //If a != b && b != c then the the equality of a to c cannot be predicted via the transitive property
               ));

   /* ------------------------------------------------------------ */
}