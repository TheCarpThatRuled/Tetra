namespace Tetra;

public abstract partial class Condition
{
   private sealed class FalseCondition : Condition
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               FalseCondition => true,
               bool condition => Equals(condition),
               _              => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => false
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => "False";

      /* ------------------------------------------------------------ */
      // Condition Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Reduce()
         => false;

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(T whenFalse,
                                  T whenTrue)
         => default;

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(T whenFalse,
                                  Func<T> whenTrue)
         => default;

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(Func<T> whenFalse,
                                  T whenTrue)
         => default;

      /* ------------------------------------------------------------ */

      public override T Reduce<T>(Func<T> whenFalse,
                                  Func<T> whenTrue)
         => default;

      /* ------------------------------------------------------------ */
      // IEquatable<Condition> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Condition? other)
         => other is FalseCondition;

      /* ------------------------------------------------------------ */
      // IEquatable<bool> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(bool other)
         => !other;

      /* ------------------------------------------------------------ */
   }
}