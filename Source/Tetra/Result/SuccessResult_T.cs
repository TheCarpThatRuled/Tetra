namespace Tetra;

partial class Result<T>
{
   internal sealed class SuccessResult : IResult<T>
   {
      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SuccessResult => true,
               _            => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => typeof(T)
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Success of {typeof(T).Name}";

      /* ------------------------------------------------------------ */
      // IError<T> Methods
      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => false;

      /* ------------------------------------------------------------ */

      public IResult<T> Do(Action    whenSuccess,
                           Action<T> whenFailure)
      {
         whenSuccess();

         return this;
      }

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<T, TNew> whenFailure)
         => new Result<TNew>.SuccessResult();

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<T, IResult<TNew>> whenFailure)
         => new Result<TNew>.SuccessResult();

      /* ------------------------------------------------------------ */

      public IResult<TNew, T> MapSuccessToType<TNew>(TNew whenSuccess)
         => new Result<TNew, T>.SuccessResult(whenSuccess);

      /* ------------------------------------------------------------ */

      public IResult<TNew, T> MapSuccessToType<TNew>(Func<TNew> whenSuccess)
         => new Result<TNew, T>.SuccessResult(whenSuccess());

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew>    whenSuccess,
                               Func<T, TNew> whenFailure)
         => whenSuccess();


      /* ------------------------------------------------------------ */
   }
}