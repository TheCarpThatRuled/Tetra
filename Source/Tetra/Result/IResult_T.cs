namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad specialised to represent the
/// result of a fallible sinking operation.
/// An <c>IResult</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Failure, representing that an error has occurred;</description>
/// </item>
/// <item>
/// <description>Success, representing the no error has occurred;</description>
/// </item>
/// </list>
/// </summary>
public interface IResult<out T>
{
   /* ------------------------------------------------------------ */
   // Methods
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
   /// Identifies if this <c>IResult</c> is a failure.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IResult</c> is a failure;
   /// <c>false</c> if it is a success.
   /// </returns>
   public bool IsAFailure();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Invokes an action on the contents of the <c>IResult</c> if it as failure, else invokes an different action on the <c>IResult</c> is a success.
   /// </summary>
   /// <param name="whenSuccess">An action that shall be invoked, if the <c>IResult</c> is a success.</param>
   /// <param name="whenFailure">An action that shall be invoked with the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The error.
   /// </returns>
   public IResult<T> Do(Action    whenSuccess,
                        Action<T> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IResult</c> shall be transformed into, if it is a failure.</typeparam>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// A failure containing the content of this <c>IResult</c> mapped through <c>whenFailure</c> if it is a failure;
   /// otherwise a success.
   /// </returns>
   public IResult<TNew> Map<TNew>(Func<T, TNew> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IResult</c> shall be transformed into, if it is a failure.</typeparam>
   /// <param name="whenFailure">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>IResult</c> mapped through <c>whenFailure</c> if it is a failure;
   /// otherwise a success.
   /// </returns>
   public IResult<TNew> Map<TNew>(Func<T, IResult<TNew>> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type of the failure.</typeparam>
   /// <param name="whenSuccess">The value that should be used, if the <c>IResult</c> is a success.</param>
   /// <returns>
   /// A <c>IResult</c> containing the content of this <c>IResult</c> if it is a failure;
   /// otherwise a <c>IResult</c> containing <c>whenSuccess</c>.
   /// </returns>
   public IResult<TNew, T> MapSuccessToType<TNew>(TNew whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type of the failure.</typeparam>
   /// <param name="whenSuccess">The functions that will create the value tha should be used, if the <c>IResult</c> is a success.</param>
   /// <returns>
   /// A <c>IResult</c> containing the content of this <c>IResult</c> if it is a failure;
   /// otherwise a <c>IResult</c> containing <c>whenSuccess</c>.
   /// </returns>
   public IResult<TNew, T> MapSuccessToType<TNew>(Func<TNew> whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IResult</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IResult</c> shall be unified as.</typeparam>
   /// <param name="whenSuccess">The function that will return the value to use, if the <c>IResult</c> is a success.</param>
   /// <param name="whenFailure">The mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>IResult</c> mapped through <c>whenFailure</c> if it is a failure;
   /// otherwise the return value of <c>whenSuccess</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<TNew>    whenSuccess,
                            Func<T, TNew> whenFailure);

   /* ------------------------------------------------------------ */
}