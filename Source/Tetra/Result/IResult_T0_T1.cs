namespace Tetra;

/// <summary>
/// An implementation of the "either" monad specialised to represent the result of a fallible function.
/// A <c>IResult</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Success, representing the no error has occurred and containing the return value of the function;</description>
/// </item>
/// <item>
/// <description>Failure, representing that an error has occurred and containing a type related to the error;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="TSuccess">The type on a success</typeparam>
/// <typeparam name="TFailure">The type on a failure</typeparam>
public interface IResult<out TSuccess, out TFailure>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IResult</c> is a failure.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IResult</c> is a failure;
   /// <c>false</c> if it is a success.
   /// </returns>
   public bool IsAFailure();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IResult</c> is a success.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IResult</c> is a success;
   /// <c>false</c> if it is a failure.
   /// </returns>
   public bool IsASuccess();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Invokes an action on the contents of the <c>IResult</c> if it as success, else invokes a different action on the <c>IResult</c>  is a failure.
   /// </summary>
   /// <param name="whenSuccess">The action that shall be invoked with the content of the <c>IResult</c>, if it is a success.</param>
   /// <param name="whenFailure">The action that shall be invoked with the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The result.
   /// </returns>
   public IResult<TSuccess, TFailure> Do(Action<TSuccess> whenSuccess,
                                         Action<TFailure> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the content of the <c>IResult</c> into a new form via mapping functions.
   /// </summary>
   /// <typeparam name="TNewSuccess">The type the success of this <c>IResult</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewFailure">The type the failure of this <c>IResult</c> shall be converted into.</typeparam>
   /// <param name="whenSuccess">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <param name="whenFailure">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// A success containing content of this <c>IResult</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise a failure containing content of this <c>IResult</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, TNewSuccess> whenSuccess,
                                                                          Func<TFailure, TNewFailure> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the content of the <c>IResult</c> into a new form via mapping functions.
   /// </summary>
   /// <typeparam name="TNewSuccess">The type the success of this <c>IResult</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewFailure">The type the failure of this <c>IResult</c> shall be converted into.</typeparam>
   /// <param name="whenSuccess">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <param name="whenFailure">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>IResult</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the content of this <c>IResult</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public IResult<TNewSuccess, TNewFailure> Map<TNewSuccess, TNewFailure>(Func<TSuccess, IResult<TNewSuccess, TNewFailure>> whenSuccess,
                                                                          Func<TFailure, IResult<TNewSuccess, TNewFailure>> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the <c>IResult</c> into an <c>IError</c>.
   /// </summary>
   /// <returns>
   /// The content of this <c>IResult</c> if it is a failure;
   /// otherwise a none.
   /// </returns>
   public IResult<TFailure> MapSuccessToTypeless();

   /* ------------------------------------------------------------ */
   /// <summary>
   /// Maps the <c>IResult</c> into an <c>IOption</c>.
   /// </summary>
   /// <returns>
   /// The content of this <c>IResult</c> if it is a success;
   /// otherwise a none.
   /// </returns>
   public IOption<TSuccess> MapToOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IResult</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IResult</c> shall be unified as.</typeparam>
   /// <param name="whenSuccess">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <param name="whenFailure">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>IResult</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the content of this <c>IResult</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<TSuccess, TNew> whenSuccess,
                            Func<TFailure, TNew> whenFailure);

   /* ------------------------------------------------------------ */
}