namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad.
/// An <c>IOption</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description><b>Some</b>, representing an instance of the contained type;</description>
/// </item>
/// <item>
/// <description><b>None</b>, representing the absence of an instance of the contained type;</description>
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
   /// Invokes an action on the contents of the <c>IOption</c> if it as <b>some</b>, else invokes an different action on the <c>IOption</c>  is a <b>none</b>.
   /// </summary>
   /// <param name="whenSome">The action that shall be invoked with the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <param name="whenNone">The action that shall be invoked, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// The option.
   /// </returns>
   public IOption<T> Do(Action<T> whenSome,
                        Action    whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Invokes an action on the contents of the <c>IOption</c> if it as <b>some</b>, else invokes an different action on the <c>IOption</c>  is a <b>none</b>.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <param name="externalState">External state pertinent to the actions</param>
   /// <param name="whenSome">The action that shall be invoked with the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <param name="whenNone">The action that shall be invoked, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// The option.
   /// </returns>
   public IOption<T> Do<TExternalState>(TExternalState            externalState,
                                        Action<TExternalState, T> whenSome,
                                        Action<TExternalState>    whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Expands this <c>IOption</c> into an <c>IEither</c> where the <b>some</b> branch becomes a <b>left</b> branch
   /// and the <b>none</b> branch becomes a <b>right</b> branch.
   /// </summary>
   /// <typeparam name="TRight">The type of the right branch.</typeparam>
   /// <param name="whenNone">The function that will create the value that should be used, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// A <b>left</b> containing the content of this <c>IOption</c> if it is a <b>some</b>;
   /// otherwise a <b>right</b> containing the return value of <c>whenNone</c>.
   /// </returns>
   public IEither<T, TRight> ExpandSomeToLeft<TRight>(Func<TRight> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Expands this <c>IOption</c> into an <c>IEither</c> where the <b>some</b> branch becomes a <b>left</b> branch
   /// and the <b>none</b> branch becomes a <b>right</b> branch.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TRight">The type of the right branch.</typeparam>
   /// <param name="externalState">External state pertinent to the function</param>
   /// <param name="whenNone">The function that will create the value that should be used, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// A <b>left</b> containing the content of this <c>IOption</c> if it is a <b>some</b>;
   /// otherwise a <b>right</b> containing the return value of <c>whenNone</c>.
   /// </returns>
   public IEither<T, TRight> ExpandSomeToLeft<TExternalState, TRight>(TExternalState               externalState,
                                                                      Func<TExternalState, TRight> whenNone);

   /* ------------------------------------------------------------ */
   /// <summary>
   /// Expands this <c>IOption</c> into an <c>IEither</c> where the <b>some</b> branch becomes a <b>right</b> branch
   /// and the <b>none</b> branch becomes a <b>left</b> branch.
   /// </summary>
   /// <typeparam name="TLeft">The type of the left branch.</typeparam>
   /// <param name="whenNone">The function that will create the value that should be used, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// A <b>right</b> containing the content of this <c>IOption</c> if it is a <b>some</b>;
   /// otherwise a <b>left</b> containing the return value of <c>whenNone</c>.
   /// </returns>
   public IEither<TLeft, T> ExpandSomeToRight<TLeft>(Func<TLeft> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Expands this <c>IOption</c> into an <c>IEither</c> where the <b>some</b> branch becomes a <b>right</b> branch
   /// and the <b>none</b> branch becomes a <b>left</b> branch.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TLeft">The type of the left branch.</typeparam>
   /// <param name="externalState">External state pertinent to the function</param>
   /// <param name="whenNone">The function that will create the value that should be used, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <returns>
   /// A <b>right</b> containing the content of this <c>IOption</c> if it is a <b>some</b>;
   /// otherwise a <b>left</b> containing the return value of <c>whenNone</c>.
   /// </returns>
   public IEither<TLeft, T> ExpandSomeToRight<TExternalState, TLeft>(TExternalState              externalState,
                                                                     Func<TExternalState, TLeft> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is a <b>none</b>.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a <b>none</b>;
   /// <c>false</c> if it is a <b>some</b>.
   /// </returns>
   public bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IOption</c> is a <b>some</b>.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IOption</c> is a <b>some</b>;
   /// <c>false</c> if it is a <b>none</b>.
   /// </returns>
   public bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form without altering which branch it is on.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a <b>some</b>.</typeparam>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <returns>
   /// A <b>some</b> containing the content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a <b>some</b>;
   /// otherwise a <b>none</b>.
   /// </returns>
   public IOption<TNew> Map<TNew>(Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>IOption</c> into a new form without altering which branch it is on.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TNew">The type the content of this <c>IOption</c> shall be transformed into, if it is a <b>some</b>.</typeparam>
   /// <param name="externalState">External state pertinent to the function</param>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <returns>
   /// A <b>some</b> containing the content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a <b>some</b>;
   /// otherwise a <b>none</b>.
   /// </returns>
   public IOption<TNew> Map<TExternalState, TNew>(TExternalState                externalState,
                                                  Func<TExternalState, T, TNew> whenSome);

   /* ------------------------------------------------------------ */


   /// <summary>
   /// Unifies both branches of the <c>IOption</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IOption</c> shall be unified as.</typeparam>
   /// <param name="whenNone">The function that will return the value to use, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a <b>some</b>;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public TNew Unify<TNew>(Func<T, TNew> whenSome,
                           Func<TNew>    whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TNew">The type this <c>IOption</c> shall be unified as.</typeparam>
   /// <param name="externalState">External state pertinent to the functions</param>
   /// <param name="whenNone">The function that will return the value to use, if the <c>IOption</c> is a <b>none</b>.</param>
   /// <param name="whenSome">The mapping function that shall be applied to the content of the <c>IOption</c>, if it is a <b>some</b>.</param>
   /// <returns>
   /// The content of this <c>IOption</c> mapped through <c>whenSome</c> if it is a <b>some</b>;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public TNew Unify<TExternalState, TNew>(TExternalState                externalState,
                                           Func<TExternalState, T, TNew> whenSome,
                                           Func<TExternalState, TNew>    whenNone);

   /* ------------------------------------------------------------ */
}