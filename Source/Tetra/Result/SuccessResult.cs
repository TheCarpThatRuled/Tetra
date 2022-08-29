using static Tetra.TetraMessages;

namespace Tetra;

partial class Result<T>
{
   private sealed class SuccessResult : IResult<T>
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

      public IResult<TNew> Cast<TNew>()
         => _success.Content() is TNew content
               ? new Result<TNew>.SuccessResult(new(content))
               : new Result<TNew>.FailureResult(new(CastFailed<T, TNew>()));

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Message whenCastFails)
         => _success.Content() is TNew content
               ? new Result<TNew>.SuccessResult(new(content))
               : new Result<TNew>.FailureResult(new(whenCastFails));

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Func<ISuccess<T>, Message> whenCastFails)
         => _success.Content() is TNew content
               ? new Result<TNew>.SuccessResult(new(content))
               : new Result<TNew>.FailureResult(new(whenCastFails(_success)));

      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => true;

      /* ------------------------------------------------------------ */

      public IResult<T> Map(Func<Failure, Message> _)
         => this;

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<ISuccess<T>, TNew> whenSuccess)
         => new Result<TNew>
            .SuccessResult(new(whenSuccess(_success)));

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<ISuccess<T>, Message> whenSuccess)
         => whenSuccess(_success);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<Failure, TNew>             _,
                               Func<ISuccess<T>, TNew> whenSuccess)
         => whenSuccess(_success);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Success<T> _success;

      /* ------------------------------------------------------------ */
   }
}