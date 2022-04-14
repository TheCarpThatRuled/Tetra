namespace Tetra;

public abstract partial class Condition
{
   private sealed class FalseCondition : Condition
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => base.Equals(obj);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => base.GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => base.ToString();

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
         => false;

      /* ------------------------------------------------------------ */
      // IEquatable<bool> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(bool other)
         => false;

      /* ------------------------------------------------------------ */
   }
}