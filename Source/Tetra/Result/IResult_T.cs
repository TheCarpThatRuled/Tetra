namespace Tetra;

/// <summary>
/// An implementation of the "either" monad specialised to represent the result of a fallible function.
/// A <c>IResult</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Success, representing the no error has occurred and containing the return value of the function;</description>
/// </item>
/// <item>
/// <description>Failure, representing that an error has occurred and containing a message related to the error;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="T">The type of the contained object</typeparam>
public interface IResult<out T> 
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>IResult</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IResult</c> shall be cast into.</typeparam>
   /// <returns>
   /// If <c>IResult</c> is a some and the cast was successful, a success of the new type;
   /// If <c>IResult</c> is a some and the cast was unsuccessful, a failure containing a standard message;
   /// otherwise a failure containing the content of this <c>IResult</c>.
   /// </returns>
   public IResult<TNew> Cast<TNew>();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>IResult</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IResult</c> shall be cast into.</typeparam>
   /// <param name="whenCastFails">The message to use if the content of this <c>IResult</c> could not be cast into the new type</param>
   /// <returns>
   /// If <c>IResult</c> is a some and the cast was successful, a success of the new type;
   /// If <c>IResult</c> is a some and the cast was unsuccessful, a failure containing <c>whenCastFails</c>;
   /// otherwise a failure containing the content of this <c>IResult</c>.
   /// </returns>
   public IResult<TNew> Cast<TNew>(Message whenCastFails);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>IResult</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IResult</c> shall be cast into.</typeparam>
   /// <param name="whenCastFails">The function that will return the message to use if the content of this <c>IResult</c> could not be cast into the new type</param>
   /// <returns>
   /// If <c>IResult</c> is a some and the cast was successful, a success of the new type;
   /// If <c>IResult</c> is a some and the cast was unsuccessful, a failure containing the return value of <c>whenCastFails</c>;
   /// otherwise a failure containing the content of this <c>IResult</c>.
   /// </returns>
   public IResult<TNew> Cast<TNew>(Func<T, Message> whenCastFails);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IResult</c> is in the failure state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IResult</c> is a failure;
   /// <c>false</c> if it is a success.
   /// </returns>
   public bool IsAFailure();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IResult</c> is in the success state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IResult</c> is a success;
   /// <c>false</c> if it is a failure.
   /// </returns>
   public bool IsASuccess();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a new form if it is a success.
   /// </summary>
   /// <typeparam name="TNew">The type the contents of this <c>IResult</c> shall be transformed into.</typeparam>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <returns>
   /// A success containing the content of this <c>IResult</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the failure containing the content of this <c>IResult</c>.
   /// </returns>
   public IResult<TNew> Map<TNew>(Func<T, TNew> whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IResult</c> into a new form if it is a failure.
   /// </summary>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <returns>
   /// A failure containing the content of this <c>IResult</c> mapped through <c>whenFailure</c> if it is a failure;
   /// otherwise the same <c>IResult</c>.
   /// </returns>
   public IResult<T> MapFailure(Func<Failure, Message> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IResult</c> into a message via a mapping function
   /// </summary>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <returns>
   /// The content of this <c>IResult</c> if it is a failure;
   /// otherwise the content of this <c>IResult</c> mapped through <c>whenSuccess</c>.
   /// </returns>
   public Message Reduce(Func<T, Message> whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IResult</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IResult</c> shall be unified as.</typeparam>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a failure.</param>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>IResult</c>, if it is a success.</param>
   /// <returns>
   /// The content of this <c>IResult</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the content of this <c>IResult</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<Failure, TNew>  whenFailure,
                            Func<T, TNew> whenSuccess);

   /* ------------------------------------------------------------ */
}