namespace Tetra;

partial class Condition
{
   public sealed class TrueCondition : ICondition
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
      // ICondition Methods
      /* ------------------------------------------------------------ */

      public bool Reduce()
         => false;

      /* ------------------------------------------------------------ */

      public T Reduce<T>(T whenFalse,
                         T whenTrue)
         => whenTrue;

      /* ------------------------------------------------------------ */

      public T Reduce<T>(T       whenFalse,
                         Func<T> whenTrue)
         => whenTrue();

      /* ------------------------------------------------------------ */

      public T Reduce<T>(Func<T> whenFalse,
                         T       whenTrue)
         => whenTrue;

      /* ------------------------------------------------------------ */

      public T Reduce<T>(Func<T> whenFalse,
                         Func<T> whenTrue)
         => whenTrue();

      /* ------------------------------------------------------------ */
      // IEquatable<ICondition> Methods
      /* ------------------------------------------------------------ */

      public bool Equals(ICondition? other)
         => other is TrueCondition;

      /* ------------------------------------------------------------ */
      // IEquatable<bool> Methods
      /* ------------------------------------------------------------ */

      public bool Equals(bool other)
         => other;

      /* ------------------------------------------------------------ */
   }
}