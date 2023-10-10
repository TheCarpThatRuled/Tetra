namespace Tetra;

partial class Condition
{
   private sealed class FalseCondition : ICondition
   {
      /* ------------------------------------------------------------ */
      // ICondition Methods
      /* ------------------------------------------------------------ */

      public bool Reduce()
         => false;

      /* ------------------------------------------------------------ */

      public T Reduce<T>
      (
         T whenFalse,
         T whenTrue
      )
         => whenFalse;

      /* ------------------------------------------------------------ */

      public T Reduce<T>
      (
         T       whenFalse,
         Func<T> whenTrue
      )
         => whenFalse;

      /* ------------------------------------------------------------ */

      public T Reduce<T>
      (
         Func<T> whenFalse,
         T       whenTrue
      )
         => whenFalse();

      /* ------------------------------------------------------------ */

      public T Reduce<T>
      (
         Func<T> whenFalse,
         Func<T> whenTrue
      )
         => whenFalse();

      /* ------------------------------------------------------------ */
      // IEquatable<ICondition> Methods
      /* ------------------------------------------------------------ */

      public bool Equals
      (
         ICondition? other
      )
         => other is FalseCondition;

      /* ------------------------------------------------------------ */
      // IEquatable<bool> Methods
      /* ------------------------------------------------------------ */

      public bool Equals
      (
         bool other
      )
         => !other;
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals
      (
         object? obj
      )
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
   }
}