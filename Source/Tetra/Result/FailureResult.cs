namespace Tetra;

partial class Result<T>
{
   private sealed class FailureResult : IResult<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public FailureResult(Failure failure)
         => _failure = failure;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj is FailureResult failure
         && _failure
           .Content()
           .Equals(failure
                  ._failure
                  .Content());

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _failure
           .Content()
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Failure ({_failure.Content()})";

      /* ------------------------------------------------------------ */
      // IResult<T> Methods
      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>()
         => new Result<TNew>
            .FailureResult(_failure);

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Message _)
         => new Result<TNew>
            .FailureResult(_failure);

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Func<ISuccess<T>, Message> _)
         => new Result<TNew>
            .FailureResult(_failure);

      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => true;

      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => false;

      /* ------------------------------------------------------------ */

      public IResult<T> Map(Func<Failure, Message> whenFailure)
         => new FailureResult(new(whenFailure(_failure)));

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<ISuccess<T>, TNew> _)
         => new Result<TNew>
            .FailureResult(_failure);

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<ISuccess<T>, Message> _)
         => _failure
           .Content();

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<Failure, TNew>             whenFailure,
                               Func<ISuccess<T>, TNew> _)
         => whenFailure(_failure);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Failure _failure;

      /* ------------------------------------------------------------ */
   }
}