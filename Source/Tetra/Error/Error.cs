namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad specialised to represent the
/// result of a fallible sinking operation.
/// An <c>Error</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Some, representing that an error has occurred and containing a message related to the error;</description>
/// </item>
/// <item>
/// <description>None, representing the no error has occurred;</description>
/// </item>
/// </list>
/// </summary>
public abstract partial class Error : IEquatable<Error>,
                                      IEquatable<Message>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>A none <c>Error</c>.</returns>
   public static Error None()
      => new NoneError();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <param name="content">The message the <c>Error</c> shall contain.</param>
   /// <returns>A some <c>Error</c> that contains <c>content</c>.</returns>
   public static Error Some(Message content)
      => new SomeError(content);

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Error(Message content)
      => new SomeError(content);

   /* ------------------------------------------------------------ */
   // IEquatable<Error> Methods
   /* ------------------------------------------------------------ */
   public abstract bool Equals(Error? other);

   /* ------------------------------------------------------------ */
   // IEquatable<Message> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Message? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Error</c> is in the none state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Error</c> is a none;
   /// <c>false</c> if it is a some.
   /// </returns>
   public abstract bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Error</c> is in the some state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Error</c> is a some;
   /// <c>false</c> if it is a none.
   /// </returns>
   public abstract bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the message of the <c>Error</c> into a new form.
   /// </summary>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Error</c>, if it is a some.</param>
   /// <returns>
   /// A some containing the content of this <c>Error</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public abstract Error Map(Func<Message, Message> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the <c>Error</c> into a new form.
   /// </summary>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Error</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Error</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public abstract Error Map(Func<Message, Error> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>Error</c> into a <c>Result</c>, that is a failure containing the contents if this is a some.
   /// </summary>
   /// <typeparam name="T">The type of the content of the <c>Result</c> that shall be produced.</typeparam>
   /// <param name="whenNone">The value to populate the success with, if it is a none.</param>
   /// <returns>
   /// A failure containing the content of this <c>Error</c> if it is a some;
   /// otherwise a success containing <c>whenNone</c>.
   /// </returns>
   public abstract Result<T> MapToResult<T>(T whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Converts this <c>Error</c> into a <c>Result</c>, that is a failure containing the contents if this is a some.
   /// </summary>
   /// <typeparam name="T">The type of the content of the <c>Result</c> that shall be produced.</typeparam>
   /// <param name="whenNone">A function that creates a value to populate the success with, if it is a none.</param>
   /// <returns>
   /// A failure containing the content of this <c>Error</c> if it is a some;
   /// otherwise a success containing the return value of <c>whenNone</c>.
   /// </returns>
   public abstract Result<T> MapToResult<T>(Func<T> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Error</c> by providing a <c>Message</c> for the none case.
   /// </summary>
   /// <param name="whenNone">The <c>Message</c> to use, if the <c>Error</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Error</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public abstract Message Reduce(Message whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Error</c> by providing a function that will create a <c>Message</c> for the none case.
   /// </summary>
   /// <param name="whenNone">A function that will return the <c>Message</c> to use, if the <c>Error</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Error</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public abstract Message Reduce(Func<Message> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Error</c> via a mapping function.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Error</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A value to use, if the <c>Error</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Error</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Error</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public abstract TNew Reduce<TNew>(TNew whenNone,
                                     Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Error</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Error</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A function that will return the value to use, if the <c>Error</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Error</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Error</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public abstract TNew Reduce<TNew>(Func<TNew> whenNone,
                                     Func<Message, TNew> whenSome);

   /* ------------------------------------------------------------ */
}