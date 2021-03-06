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
      // Option Overridden Methods
      /* ------------------------------------------------------------ */

      public override Option<TNew> Cast<TNew>()
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public override bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public override bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public override Option<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public override Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public override Result<T> MapToResult(Message whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public override Result<T> MapToResult(Func<Message> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public override T Reduce(T whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public override T Reduce(Func<T> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(TNew whenNone,
                                        Func<T, TNew> _)
         => whenNone;

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<TNew> whenNone,
                                        Func<T, TNew> _)
         => whenNone();

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
   }
}