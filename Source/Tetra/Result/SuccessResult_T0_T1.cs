namespace Tetra;

partial class Result<TSuccess, TFailure>
{
   internal sealed class SuccessResult : IResult<TSuccess, TFailure>
   {
      /* ------------------------------------------------------------ */
      // Constructors
      /* ------------------------------------------------------------ */

      public SuccessResult(TSuccess content)
         => Content = content;

      /* ------------------------------------------------------------ */
      // object Overridden Methods
      /* ------------------------------------------------------------ */

      public override bool Equals(object? obj)
         => ReferenceEquals(this,
                            obj)
         || obj switch
            {
               SuccessResult success => Equals(Content,
                                               success.Content),
               TSuccess success => Equals(Content,
                                          success),
               _ => false,
            };

      /* ------------------------------------------------------------ */

      public override int GetHashCode()
         => Content
             ?.GetHashCode()
         ?? 0;

      /* ------------------------------------------------------------ */

      public override string ToString()
         => $"Success ({Content})";

      /* ------------------------------------------------------------ */
      // IResult<TSuccess, TFailure> Methods
      /* ------------------------------------------------------------ */

      public bool IsAFailure()
         => false;

      /* ------------------------------------------------------------ */

      public bool IsASuccess()
         => true;

      /* ------------------------------------------------------------ */

      public IResult<TSuccess, TFailure> Do(Action<TSuccess> whenSuccess,
                                            Action<TFailure> whenFailure)
      {
         whenSuccess(Content);

         return this;
      }

      /* ------------------------------------------------------------ */

      public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, TNewSuccess> whenSuccess,
                                                                             Func<TFailure, TNewFailure> whenFailure)
         => Result<TNewSuccess, TNewFailure>
           .Success(whenSuccess(Content));

      /* ------------------------------------------------------------ */

      public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, IResult<TNewSuccess, TNewFailure>> whenSuccess,
                                                                             Func<TFailure, IResult<TNewSuccess, TNewFailure>> whenFailure)
         => whenSuccess(Content);

      /* ------------------------------------------------------------ */

      public IResult<TFailure> MapSuccessToTypeless()
         => Result<TFailure>
           .Success();

      /* ------------------------------------------------------------ */

      public IOption<TSuccess> MapToOption()
         => Option<TSuccess>
           .Some(Content);

      /* ------------------------------------------------------------ */

      public TNew Reduce<TNew>(Func<TSuccess, TNew> whenSuccess,
                               Func<TFailure, TNew> whenFailure)
         => whenSuccess(Content);

      /* ------------------------------------------------------------ */
      // Internal Fields
      /* ------------------------------------------------------------ */

      internal readonly TSuccess Content;

      /* ------------------------------------------------------------ */
   }
}