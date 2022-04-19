namespace Tetra;

public abstract partial class Condition
{
   public sealed class TrueCondition : Condition
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               TrueCondition  => true,
               bool condition => Equals(condition),
               _              => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => true
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => "True";

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
         => other is TrueCondition;

      /* ------------------------------------------------------------ */
      // IEquatable<bool> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(bool other)
         => other;

      /* ------------------------------------------------------------ */
   }
}