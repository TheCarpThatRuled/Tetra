namespace Tetra;

partial class Result<T>
{
   private sealed class FailureResult : Result<T>
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
         || obj switch
            {
               FailureResult failure => _failure
                                       .Content()
                                       .Equals(failure
                                              ._failure
                                              .Content()),
               _ => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _failure
           .Content()
           .GetHashCode();

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Failure ({_failure.Content()})";

      /* ------------------------------------------------------------ */
      // Result<T> Methods
      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Message _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Func<Success<T>, Message> whenCastFails)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsAFailure()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override bool IsASuccess()
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<T> Map(Func<Failure, Message> whenFailure)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Map<TNew>(Func<Success<T>, TNew> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce(Func<Failure, T> whenFailure)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Success<T>, Message> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<Failure, TNew>    whenFailure,
                                        Func<Success<T>, TNew> _)
         => whenFailure(_failure);

      /* ------------------------------------------------------------ */
      // IEquatable<Result<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Result<T>? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               FailureResult failure => _failure
                                       .Content()
                                       .Equals(failure
                                              ._failure
                                              .Content()),
               _ => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => false;

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Failure _failure;

      /* ------------------------------------------------------------ */
   }
}