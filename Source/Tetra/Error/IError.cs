namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad specialised to represent the
/// result of a fallible sinking operation.
/// An <c>IError</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Some, representing that an error has occurred and containing a message related to the error;</description>
/// </item>
/// <item>
/// <description>None, representing the no error has occurred;</description>
/// </item>
/// </list>
/// </summary>
public interface IError
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IError</c> is in the none state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IError</c> is a none;
   /// <c>false</c> if it is a some.
   /// </returns>
   public bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IError</c> is in the some state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IError</c> is a some;
   /// <c>false</c> if it is a none.
   /// </returns>
   public bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the message of the <c>IError</c> into a new form.
   /// </summary>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IError</c>, if it is a some.</param>
   /// <returns>
   /// A some containing the content of this <c>IError</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IError Map(Func<Message, Message> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the <c>IError</c> into a new form.
   /// </summary>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IError</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IError</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IError Map(Func<Message, IError> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>IError</c> into a <c>IResult</c>, that is a failure containing the contents if this is a some.
   /// </summary>
   /// <typeparam name="T">The type of the content of the <c>IResult</c> that shall be produced.</typeparam>
   /// <param name="whenNone">The value to populate the success with, if it is a none.</param>
   /// <returns>
   /// A failure containing the content of this <c>IError</c> if it is a some;
   /// otherwise a success containing <c>whenNone</c>.
   /// </returns>
   public IResult<T> MapToResult<T>(T whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>IError</c> into a <c>IResult</c>, that is a failure containing the contents if this is a some.
   /// </summary>
   /// <typeparam name="T">The type of the content of the <c>IResult</c> that shall be produced.</typeparam>
   /// <param name="whenNone">A function that creates a value to populate the success with, if it is a none.</param>
   /// <returns>
   /// A failure containing the content of this <c>IError</c> if it is a some;
   /// otherwise a success containing the return value of <c>whenNone</c>.
   /// </returns>
   public IResult<T> MapToResult<T>(Func<T> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IError</c> by providing a <c>Message</c> for the none case.
   /// </summary>
   /// <param name="whenNone">The <c>Message</c> to use, if the <c>IError</c> is a none.</param>
   /// <returns>
   /// The content of this <c>IError</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public Message Reduce(Message whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IError</c> by providing a function that will create a <c>Message</c> for the none case.
   /// </summary>
   /// <param name="whenNone">A function that will return the <c>Message</c> to use, if the <c>IError</c> is a none.</param>
   /// <returns>
   /// The content of this <c>IError</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public Message Reduce(Func<Message> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IError</c> via a mapping function.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IError</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A value to use, if the <c>IError</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IError</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IError</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public TNew Reduce<TNew>(TNew whenNone,
                            Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IError</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IError</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A function that will return the value to use, if the <c>IError</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>IError</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IError</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<TNew> whenNone,
                            Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */
}