using static Tetra.TetraMessages;

namespace Tetra;

partial class Result<T>
{
   private sealed class SuccessResult : Result<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SuccessResult(Success<T> success)
         => _success = success;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SuccessResult success => Equals(_success.Content(),
                                               success._success
                                                      .Content()),
               T success => Equals(_success.Content(),
                                   success),
               _ => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _success
           .Content()
          ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Success ({_success.Content()})";

      /* ------------------------------------------------------------ */
      // Result<T> Methods
      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>()
         => _success.Content() is TNew content
               ? Result<TNew>.Success(content)
               : Result<TNew>.Failure(CastFailed<T, TNew>());

      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Message whenCastFails)
         => _success.Content() is TNew content
               ? Result<TNew>.Success(content)
               : Result<TNew>.Failure(whenCastFails);

      /* ------------------------------------------------------------ */

      public override Result<TNew> Cast<TNew>(Func<Success<T>, Message> whenCastFails)
         => _success.Content() is TNew content
               ? Result<TNew>.Success(content)
               : Result<TNew>.Failure(whenCastFails(_success));

      /* ------------------------------------------------------------ */

      public override bool IsAFailure()
         => false;

      /* ------------------------------------------------------------ */

      public override bool IsASuccess()
         => true;

      /* ------------------------------------------------------------ */

      public override Result<T> Map(Func<Failure, Message> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Result<TNew> Map<TNew>(Func<Success<T>, TNew> whenSuccess)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override T Reduce(Func<Failure, T> _)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override Message Reduce(Func<Success<T>, Message> whenSuccess)
         => throw new NotImplementedException();

      /* ------------------------------------------------------------ */

      public override TNew Reduce<TNew>(Func<Failure, TNew> _,
                                        Func<Success<T>, TNew> whenSuccess)
         => whenSuccess(_success);

      /* ------------------------------------------------------------ */
      // IEquatable<Result<T>> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(Result<T>? other)
         => ReferenceEquals(this,
                            other)
         || other switch
            {
               SuccessResult success => Equals(_success.Content(),
                                               success._success
                                                      .Content()),
               _ => false,
            };

      /* ------------------------------------------------------------ */
      // IEquatable<T> Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(T? other)
         => Equals(_success.Content(),
                   other);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Success<T> _success;

      /* ------------------------------------------------------------ */
   }
}