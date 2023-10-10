namespace Tetra;

/// <summary>
///    An implementation of the "either" monad.
///    An <c>IEither</c> may be in one of two states:
///    <list type="bullet">
///       <item>
///          <description>
///             <b>Left</b>, representing a state mutually exclusive with <b>right</b> and containing an instance
///             of <c>TLeft</c>;
///          </description>
///       </item>
///       <item>
///          <description>
///             <b>Right</b>, representing a state mutually exclusive with <b>left</b> and containing an instance
///             of <c>TRight</c>;
///          </description>
///       </item>
///    </list>
/// </summary>
/// <typeparam name="TLeft">The type contained by a <b>left</b></typeparam>
/// <typeparam name="TRight">The type contained by a <b>right</b></typeparam>
public interface IEither<out TLeft, out TRight>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Identifies if this <c>IEither</c> is a <b>right</b>.
   /// </summary>
   /// <returns>
   ///    <c>true</c> if this <c>IEither</c> is a <b>right</b>;
   ///    <c>false</c> if it is a <b>left</b>.
   /// </returns>
   public bool IsARight();

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Identifies if this <c>IEither</c> is a <b>left</b>.
   /// </summary>
   /// <returns>
   ///    <c>true</c> if this <c>IEither</c> is a <b>left</b>;
   ///    <c>false</c> if it is a <b>right</b>.
   /// </returns>
   public bool IsALeft();

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Invokes an action on the contents of the <c>IEither</c> if it as <b>left</b>, else invokes a different action on the
   ///    <c>IEither</c>  is a <b>right</b>.
   /// </summary>
   /// <param name="whenLeft">The action that shall be invoked with the content of the <c>IEither</c>, if it is a <b>left</b>.</param>
   /// <param name="whenRight">
   ///    The action that shall be invoked with the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    The result.
   /// </returns>
   public IEither<TLeft, TRight> Do
   (
      Action<TLeft>  whenLeft,
      Action<TRight> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Invokes an action on the contents of the <c>IEither</c> if it as <b>left</b>, else invokes a different action on the
   ///    <c>IEither</c>  is a <b>right</b>.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <param name="externalState">External state pertinent to the actions</param>
   /// <param name="whenLeft">The action that shall be invoked with the content of the <c>IEither</c>, if it is a <b>left</b>.</param>
   /// <param name="whenRight">
   ///    The action that shall be invoked with the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    The result.
   /// </returns>
   public IEither<TLeft, TRight> Do<TExternalState>
   (
      TExternalState                 externalState,
      Action<TExternalState, TLeft>  whenLeft,
      Action<TExternalState, TRight> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Maps the content of the <c>IEither</c> into a new form via mapping functions without altering which branch it is on.
   /// </summary>
   /// <typeparam name="TNewLeft">The type the <b>left</b> of this <c>IEither</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewRight">The type the <b>right</b> of this <c>IEither</c> shall be converted into.</typeparam>
   /// <param name="whenLeft">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>left</b>.
   /// </param>
   /// <param name="whenRight">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    A <b>left</b> containing content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a <b>left</b>;
   ///    otherwise a <b>right</b> containing content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>
   (
      Func<TLeft, TNewLeft>   whenLeft,
      Func<TRight, TNewRight> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Maps the content of the <c>IEither</c> into a new form via mapping functions without altering which branch it is on.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TNewLeft">The type the <b>left</b> of this <c>IEither</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewRight">The type the <b>right</b> of this <c>IEither</c> shall be converted into.</typeparam>
   /// <param name="externalState">External state pertinent to the functions</param>
   /// <param name="whenLeft">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>left</b>.
   /// </param>
   /// <param name="whenRight">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    A <b>left</b> containing content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a <b>left</b>;
   ///    otherwise a <b>right</b> containing content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public IEither<TNewLeft, TNewRight> Map<TExternalState, TNewLeft, TNewRight>
   (
      TExternalState                          externalState,
      Func<TExternalState, TLeft, TNewLeft>   whenLeft,
      Func<TExternalState, TRight, TNewRight> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Unifies both branches of the <c>IEither</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IEither</c> shall be unified as.</typeparam>
   /// <param name="whenLeft">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>left</b>.
   /// </param>
   /// <param name="whenRight">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    The content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a <b>left</b>;
   ///    otherwise the content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public TNew Unify<TNew>
   (
      Func<TLeft, TNew>  whenLeft,
      Func<TRight, TNew> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Unifies both branches of the <c>IEither</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TExternalState">The type of the external state.</typeparam>
   /// <typeparam name="TNew">The type this <c>IEither</c> shall be unified as.</typeparam>
   /// <param name="externalState">External state pertinent to the functions</param>
   /// <param name="whenLeft">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>left</b>.
   /// </param>
   /// <param name="whenRight">
   ///    The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a
   ///    <b>right</b>.
   /// </param>
   /// <returns>
   ///    The content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a <b>left</b>;
   ///    otherwise the content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public TNew Unify<TExternalState, TNew>
   (
      TExternalState                     externalState,
      Func<TExternalState, TLeft, TNew>  whenLeft,
      Func<TExternalState, TRight, TNew> whenRight
   );

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Reduces this <c>IOption</c> into an <c>IEither</c> where the <b>left</b> branch becomes a <b>some</b> branch
   ///    and the <b>right</b> branch becomes a <b>none</b> branch.
   /// </summary>
   /// <returns>
   ///    The content of this <c>IEither</c> if it is a <b>left</b>;
   ///    otherwise a <b>none</b>.
   /// </returns>
   public IOption<TLeft> ReduceLeftToOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Reduces this <c>IOption</c> into an <c>IEither</c> where the <b>some</b> branch becomes a <b>left</b> branch
   ///    and the <b>none</b> branch becomes a <b>right</b> branch.
   /// </summary>
   /// <returns>
   ///    The content of this <c>IEither</c> if it is a <b>right</b>;
   ///    otherwise a <b>none</b>.
   /// </returns>
   public IOption<TRight> ReduceRightToOption();

   /* ------------------------------------------------------------ */
}