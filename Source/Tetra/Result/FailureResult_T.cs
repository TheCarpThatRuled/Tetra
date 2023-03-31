namespace Tetra;

partial class Result<T>
{
   internal sealed class FailureResult : IResult<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public FailureResult(T content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               FailureResult failure => Equals(Content,
                                               failure.Content),
               T content => Equals(Content,
                                   content),
               _ => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
             ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Failure ({Content})";

      /* ------------------------------------------------------------ */
      // IError<T> Methods
      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => true;

      /* ------------------------------------------------------------ */

      public IResult<T> Do(Action    whenSuccess,
                           Action<T> whenFailure)
      {
         whenFailure(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<T, TNew> whenFailure)
         => new Result<TNew>.FailureResult(whenFailure(Content));
      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<T, IResult<TNew>> whenFailure)
         => whenFailure(Content);

      /* ------------------------------------------------------------ */

      public IResult<TNew, T> MapSuccessToType<TNew>(TNew whenSuccess)
         => new Result<TNew, T>.FailureResult(Content);

      /* ------------------------------------------------------------ */

      public IResult<TNew, T> MapSuccessToType<TNew>(Func<TNew> whenSuccess)
         => new Result<TNew, T>.FailureResult(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TNew>    whenSuccess,
                               Func<T, TNew> whenFailure)
         => whenFailure(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly T Content;

      /* ------------------------------------------------------------ */
   }
}