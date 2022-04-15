namespace Tetra;

/// <summary>
/// An implementation of the "either" monad specialised to represent the result of a fallible function.
/// A <c>Result</c> may be in one of two states:
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
public abstract partial class Result<T> : IEquatable<Result<T>>,
                                          IEquatable<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a failure.
   /// </summary>
   /// <param name="content">The value the <c>Result</c> shall contain.</param>
   /// <returns>A failure <c>Result</c> that contains <c>content</c>.</returns>
   public static Result<T> Failure(Message content)
      => new FailureResult(new Failure(content));

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a success.
   /// </summary>
   /// <param name="content">The value the <c>Result</c> shall contain.</param>
   /// <returns>A success <c>Result</c> that contains <c>content</c>.</returns>
   public static Result<T> Success(T content)
      => new SuccessResult(new Success<T>(content));

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Result<T> (Message content)
      => new FailureResult(new Failure(content));

   /* ------------------------------------------------------------ */

   public static implicit operator Result<T> (T content)
      => new SuccessResult(new Success<T>(content));

   /* ------------------------------------------------------------ */
   // IEquatable<Result<T>> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Result<T>? other);

   /* ------------------------------------------------------------ */
   // IEquatable<T> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(T? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>Result</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>Result</c> shall be cast into.</typeparam>
   /// <returns>
   /// If <c>Result</c> is a some and the cast was successful, a success of the new type;
   /// If <c>Result</c> is a some and the cast was unsuccessful, a failure containing a standard message;
   /// otherwise a failure containing the content of this <c>Result</c>.
   /// </returns>
   public abstract Result<TNew> Cast<TNew>();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>Result</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>Result</c> shall be cast into.</typeparam>
   /// <param name="whenCastFails">The message to use if the content of this <c>Result</c> could not be cast into the new type</param>
   /// <returns>
   /// If <c>Result</c> is a some and the cast was successful, a success of the new type;
   /// If <c>Result</c> is a some and the cast was unsuccessful, a failure containing <c>whenCastFails</c>;
   /// otherwise a failure containing the content of this <c>Result</c>.
   /// </returns>
   public abstract Result<TNew> Cast<TNew>(Message whenCastFails);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>Result</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>Result</c> shall be cast into.</typeparam>
   /// <param name="whenCastFails">The function that will return the message to use if the content of this <c>Result</c> could not be cast into the new type</param>
   /// <returns>
   /// If <c>Result</c> is a some and the cast was successful, a success of the new type;
   /// If <c>Result</c> is a some and the cast was unsuccessful, a failure containing the return value of <c>whenCastFails</c>;
   /// otherwise a failure containing the content of this <c>Result</c>.
   /// </returns>
   public abstract Result<TNew> Cast<TNew>(Func<Success<T>, Message> whenCastFails);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Result</c> is in the failure state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Result</c> is a failure;
   /// <c>false</c> if it is a success.
   /// </returns>
   public abstract bool IsAFailure();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Result</c> is in the success state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Result</c> is a success;
   /// <c>false</c> if it is a failure.
   /// </returns>
   public abstract bool IsASuccess();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Result</c> into a new form if it is a failure.
   /// </summary>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a failure.</param>
   /// <returns>
   /// A failure containing the content of this <c>Result</c> mapped through <c>whenFailure</c> if it is a failure;
   /// otherwise the same <c>Result</c>.
   /// </returns>
   public abstract Result<T> Map(Func<Failure, Message> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Result</c> into a new form if it is a success.
   /// </summary>
   /// <typeparam name="TNew">The type the contents of this <c>Result</c> shall be transformed into.</typeparam>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a success.</param>
   /// <returns>
   /// A success containing the content of this <c>Result</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the failure containing the content of this <c>Result</c>.
   /// </returns>
   public abstract Result<TNew> Map<TNew>(Func<Success<T>, TNew> whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Result</c> via a mapping function
   /// </summary>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a failure.</param>
   /// <returns>
   /// The content of this <c>Result</c> if it is a success;
   /// otherwise the content of this <c>Result</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public abstract T Reduce(Func<Failure, T> whenFailure);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Result</c> into a message via a mapping function
   /// </summary>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a success.</param>
   /// <returns>
   /// The content of this <c>Result</c> if it is a failure;
   /// otherwise the content of this <c>Result</c> mapped through <c>whenSuccess</c>.
   /// </returns>
   public abstract Message Reduce(Func<Success<T>, Message> whenSuccess);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Result</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Result</c> shall be unified as.</typeparam>
   /// <param name="whenFailure">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a failure.</param>
   /// <param name="whenSuccess">A mapping function that shall be applied to the content of the <c>Result</c>, if it is a success.</param>
   /// <returns>
   /// The content of this <c>Result</c> mapped through <c>whenSuccess</c> if it is a success;
   /// otherwise the content of this <c>Result</c> mapped through <c>whenFailure</c>.
   /// </returns>
   public abstract TNew Reduce<TNew>(Func<Failure, TNew> whenFailure,
                                     Func<Success<T>, TNew> whenSuccess);

   /* ------------------------------------------------------------ */
}