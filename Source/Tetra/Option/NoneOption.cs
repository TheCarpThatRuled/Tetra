namespace Tetra;

partial class Option<T>
{
   private sealed class NoneOption : Option<T>
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               NoneOption => true,
               _          => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => typeof(T)
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"None of {typeof(T).Name}";

      /* ------------------------------------------------------------ */
      // IEquatable<Option<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Option<T>? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               NoneOption => true,
               _          => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => false;

      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> whenNone,
                                        Func<T, TNew> _)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}