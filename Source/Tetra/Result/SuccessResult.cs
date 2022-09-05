using static Tetra.TetraMessages;

namespace Tetra;

partial class Result<T>
{
   private sealed class SuccessResult : IResult<T>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SuccessResult(T content)
         => _content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SuccessResult success => Equals(_content,
                                               success._content),
               T success => Equals(_content,
                                   success),
               _ => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => _content
          ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Success ({_content})";

      /* ------------------------------------------------------------ */
      // Result<T> Methods
      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>()
         => _content is TNew content
               ? new Result<TNew>.SuccessResult(content)
               : new Result<TNew>.FailureResult(new(CastFailed<T, TNew>()));

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Message whenCastFails)
         => _content is TNew content
               ? new Result<TNew>.SuccessResult(content)
               : new Result<TNew>.FailureResult(new(whenCastFails));

      /* ------------------------------------------------------------ */

      public IResult<TNew> Cast<TNew>(Func<T, Message> whenCastFails)
         => _content is TNew content
               ? new Result<TNew>.SuccessResult(content)
               : new Result<TNew>.FailureResult(new(whenCastFails(_content)));

      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => true;

      /* ------------------------------------------------------------ */

      public IResult<T> MapFailure(Func<Failure, Message> _)
         => this;

      /* ------------------------------------------------------------ */

      public IResult<TNew> Map<TNew>(Func<T, TNew> whenSuccess)
         => new Result<TNew>
            .SuccessResult(whenSuccess(_content));

      /* ------------------------------------------------------------ */

      public Message Reduce(Func<T, Message> whenSuccess)
         => whenSuccess(_content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<Failure, TNew>             _,
                               Func<T, TNew> whenSuccess)
         => whenSuccess(_content);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly T _content;

      /* ------------------------------------------------------------ */
   }
}