namespace Tetra;

static partial class Option<T>
{
   internal sealed class NoneOption : IOption<T>
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
      // IOption<T> Methods
      /* ------------------------------------------------------------ */

      public bool IsANone()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASome()
         => false;

      /* ------------------------------------------------------------ */

      public IOption<T> Do(Action<T> whenSome,
                           Action    whenNone)
      {
         whenNone();

         return this;
      }

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome)
         => new Option<TNew>.NoneOption();

      /* ------------------------------------------------------------ */

      public IResult<T, TNew> MapToResult<TNew>(TNew whenNone)
         => new Result<T, TNew>.FailureResult(whenNone);

      /* ------------------------------------------------------------ */

      public IResult<T, TNew> MapToResult<TNew>(Func<TNew> whenNone)
         => new Result<T, TNew>.FailureResult(whenNone());

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<T, TNew> whenSome,
                               Func<TNew>    whenNone)
         => whenNone();

      /* ------------------------------------------------------------ */
   }
}