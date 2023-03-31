namespace Tetra;

partial class Result<TSuccess, TFailure>
{
   internal sealed class FailureResult : IResult<TSuccess, TFailure>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public FailureResult(TFailure content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj is FailureResult failure
         && Content.Equals(failure
                             .Content);

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
             ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Failure ({Content})";

      /* ------------------------------------------------------------ */
      // IResult<TSuccess, TFailure> Methods
      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => false;

      /* ------------------------------------------------------------ */

      public IResult<TSuccess, TFailure> Do(Action<TSuccess> whenSuccess,
                                            Action<TFailure> whenFailure)
      {
         whenFailure(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, TNewSuccess> whenSuccess,
                                                                             Func<TFailure, TNewFailure> whenFailure)
         => Result<TNewSuccess, TNewFailure>
           .Failure(whenFailure(Content));

      /* ------------------------------------------------------------ */

      public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, IResult<TNewSuccess, TNewFailure>> whenSuccess,
                                                                             Func<TFailure, IResult<TNewSuccess, TNewFailure>> whenFailure)
         => whenFailure(Content);

      /* ------------------------------------------------------------ */

      public IResult<TFailure> MapSuccessToTypeless()
         => Result
           .Failure(Content);

      /* ------------------------------------------------------------ */

      public IOption<TSuccess> MapToOption()
         => Option<TSuccess>
           .None();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TSuccess, TNew> whenSuccess,
                               Func<TFailure, TNew> whenFailure)
         => whenFailure(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TFailure Content;

      /* ------------------------------------------------------------ */
   }
}