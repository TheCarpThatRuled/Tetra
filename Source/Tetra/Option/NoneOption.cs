namespace Tetra;

static partial class Option<T>
{
   private sealed class NoneOption : IOption<T>
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
      // IEquatable<IOption<T>> Methods
      /* ------------------------------------------------------------ */

      public bool Equals(IOption<T>? other)
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

      public bool Equals(T? other)
         => false;

      /* ------------------------------------------------------------ */
      // IOption Methods
      /* ------------------------------------------------------------ */

      public IOption<TNew> Cast<TNew>()
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public Result<T> MapToResult(Message whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public Result<T> MapToResult(Func<Message> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public T Reduce(T whenNone)
         => whenNone;

      /* ------------------------------------------------------------ */

      public T Reduce(Func<T> whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(TNew          whenNone,
                               Func<T, TNew> _)
         => whenNone;

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew>    whenNone,
                               Func<T, TNew> _)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}