namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad.
/// An <c>IOption</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Some, representing an instance of the contained type;</description>
/// </item>
/// <item>
/// <description>None, representing the absence of an instance of the contained type;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="T">The type of the contained object</typeparam>
public interface IOption<out T>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is a none.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a none;
   /// <c>false</c> if it is a some.
   /// </returns>
   public bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is a some.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a some;
   /// <c>false</c> if it is a none.
   /// </returns>
   public bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Invokes an action on the contents of the <c>IOption</c> if it as some, else invokes an different action on the <c>IOption</c>  is a none.
   /// </summary>
   /// <param name="whenSome">The action that shall be invoked with the content of the <c>IOption</c>, if it is a some.</param>
   /// <param name="whenNone">The action that shall be invoked, if the <c>IOption</c> is a none.</param>
   /// <returns>
   /// The option.
   /// </returns>
   public IOption<T> Do(Action<T> whenSome,
                        Action    whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a some.</typeparam>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// A some containing the content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a some.</typeparam>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public IOption<TNew> Map<TNew>(Func<T, IOption<TNew>> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type of the failure.</typeparam>
   /// <param name="whenNone">The value that should be used, if the <c>IOption</c> is a none.</param>
   /// <returns>
   /// A <c>IResult</c> containing the content of this <c>IOption</c> if it is a some;
   /// otherwise a <c>IResult</c> containing <c>whenNone</c>.
   /// </returns>
   public IResult<T, TNew> MapToResult<TNew>(TNew whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a <c>IResult</c>.
   /// </summary>
   /// <typeparam name="TNew">The type of the failure.</typeparam>
   /// <param name="whenNone">The functions that will create the value tha should be used, if the <c>IOption</c> is a none.</param>
   /// <returns>
   /// A <c>IResult</c> containing the content of this <c>IOption</c> if it is a some;
   /// otherwise a <c>IResult</c> containing <c>whenNone</c>.
   /// </returns>
   public IResult<T, TNew> MapToResult<TNew>(Func<TNew> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IOption</c> shall be unified as.</typeparam>
   /// <param name="whenNone">The function that will return the value to use, if the <c>IOption</c> is a none.</param>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<T, TNew> whenSome,
                            Func<TNew>    whenNone);

   /* ------------------------------------------------------------ */
}