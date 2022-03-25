namespace Tetra;

partial class Option<T>
{
   private sealed class NoneOption : Option<T>
   {
      /* ------------------------------------------------------------ */
      // IEquatable<Option<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Option<T>? other)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> whenNone,
                                        Func<T, TNew> _)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}