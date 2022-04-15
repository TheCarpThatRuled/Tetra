using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Equals Functions
   /* ------------------------------------------------------------ */

   public static Property EqualsIsReflexive<T>(T original,
                                               T copy)
      where T : notnull
      => AsProperty(() => ((object)original).Equals(original))
        .Label("object.Equals is not reflexive: Comparing against the same instance is not equal")
        .And(AsProperty(() => ((object)original).Equals(copy))
               .Label("object.Equals is not reflexive: Comparing against an identical instance is not equal"));

   /* ------------------------------------------------------------ */

   public static Property EqualsIsReflexive<T0, T1>(T0 original,
                                                    T0 copy,
                                                    T1 otherType)
      where T0 : notnull, IEquatable<T1>
      => AsProperty(() => ((object)original).Equals(original))
        .Label("object.Equals is not reflexive: Comparing against the same instance is not equal")
        .And(AsProperty(() => ((object)original).Equals(copy))
               .Label("object.Equals is not reflexive: Comparing against an identical instance is not equal"))
        .And(AsProperty(() => ((object)original).Equals(otherType))
               .Label(
                   "object.Equals is not pseudo-reflexive: Comparing against an identical instance of a different type is not equal"));

   /* ------------------------------------------------------------ */

   public static Property EqualsIsSymmetric<T>(T first,
                                               T second)
      where T : notnull
      => AsProperty(() =>
         {
            var firstEqualsSecond = ((object)first).Equals(second);
            var secondEqualsFirst = ((object)second).Equals(first);

            return firstEqualsSecond == secondEqualsFirst;
         })
        .Label("object.Equals is not symmetric");

   /* ------------------------------------------------------------ */

   public static Property EqualsIsTransitive<T>((T a, T b, T c) values)
      where T : notnull
   {
      var aEqualB = ((object)values.a).Equals(values.b);
      var bEqualC = ((object)values.b).Equals(values.c);
      var aEqualC = ((object)values.a).Equals(values.c);

      return ((aEqualB == bEqualC) == aEqualC)
        .Label($"object.Equals is not transitive: a == b: {aEqualB}, b == c: {bEqualC}, a == c: {aEqualC}");
   }

   /* ------------------------------------------------------------ */

   public static Property EqualsIsTransitive<T0, T1>((T0 a, T1 b, T1 c) values)
      where T0 : notnull, IEquatable<T1>
      where T1 : notnull
   {
      var aEqualB = ((object)values.a).Equals(values.b);
      var bEqualC = ((object)values.b).Equals(values.c);
      var aEqualC = ((object)values.a).Equals(values.c);

      return ((aEqualB == bEqualC) == aEqualC)
        .Label($"object.Equals is not transitive: a == b: {aEqualB}, b == c: {bEqualC}, a == c: {aEqualC}");
   }

   /* ------------------------------------------------------------ */
   // IEquatable Functions
   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Property IEquatableIsReflexive<T>(T original,
                                                   T copy)
      where T : notnull, IEquatable<T>
      => AsProperty(() => original.Equals(original))
        .Label("Comparing against the same instance is not equal")
        .And(AsProperty(() => original.Equals(copy))
               .Label("Comparing against an identical instance is not equal"));

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Property IEquatableIsSymmetric<T>(T first,
                                                   T second)
      where T : notnull, IEquatable<T>
      => AsProperty(() =>
         {
            var firstEqualsSecond = first.Equals(second);
            var secondEqualsFirst = second.Equals(first);

            return firstEqualsSecond == secondEqualsFirst;
         })
        .Label($"IEquatable<{typeof(T).Name}>.Equals is not symmetric");

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Property IEquatableIsTransitive<T>((T a, T b, T c) values)
      where T : notnull, IEquatable<T>
   {
      var aEqualB = values.a.Equals(values.b);
      var bEqualC = values.b.Equals(values.c);
      var aEqualC = values.a.Equals(values.c);

      return ((aEqualB == bEqualC) == aEqualC)
        .Label($"object.Equals is not transitive: a == b: {aEqualB}, b == c: {bEqualC}, a == c: {aEqualC}");
   }

   /* ------------------------------------------------------------ */

   // ReSharper disable once InconsistentNaming
   public static Property IEquatableIsTransitive<T0, T1>((T0 a, T1 b, T1 c) values)
      where T0 : notnull, IEquatable<T1>
      where T1 : notnull
   {
      var aEqualB = values.a.Equals(values.b);
      var bEqualC = values.b.Equals(values.c);
      var aEqualC = values.a.Equals(values.c);

      return ((aEqualB == bEqualC) == aEqualC)
        .Label($"object.Equals is not transitive: a == b: {aEqualB}, b == c: {bEqualC}, a == c: {aEqualC}");
   }

   /* ------------------------------------------------------------ */
}