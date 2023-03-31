namespace Tetra;

/// <summary>
/// An implementation of the "either" monad.
/// An <c>IEither</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Left, representing a state mutually exclusive with right and containing an instance of <c>TLeft</c>;</description>
/// </item>
/// <item>
/// <description>Right, representing a state mutually exclusive with left and containing an instance of <c>TRight</c>;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="TLeft">The type contained by a left</typeparam>
/// <typeparam name="TRight">The type contained by a right</typeparam>
public interface IEither<out TLeft, out TRight>
{
   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IEither</c> is a right.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IEither</c> is a right;
   /// <c>false</c> if it is a left.
   /// </returns>
   public bool IsARight();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>IEither</c> is a left.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>IEither</c> is a left;
   /// <c>false</c> if it is a right.
   /// </returns>
   public bool IsALeft();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Invokes an action on the contents of the <c>IEither</c> if it as left, else invokes a different action on the <c>IEither</c>  is a right.
   /// </summary>
   /// <param name="whenLeft">The action that shall be invoked with the content of the <c>IEither</c>, if it is a left.</param>
   /// <param name="whenRight">The action that shall be invoked with the content of the <c>IEither</c>, if it is a right.</param>
   /// <returns>
   /// The result.
   /// </returns>
   public IEither<TLeft, TRight> Do(Action<TLeft>  whenLeft,
                                    Action<TRight> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the content of the <c>IEither</c> into a new form via mapping functions.
   /// </summary>
   /// <typeparam name="TNewLeft">The type the left of this <c>IEither</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewRight">The type the right of this <c>IEither</c> shall be converted into.</typeparam>
   /// <param name="whenLeft">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a left.</param>
   /// <param name="whenRight">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a right.</param>
   /// <returns>
   /// A left containing content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise a right containing content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, TNewLeft>   whenLeft,
                                                                Func<TRight, TNewRight> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the content of the <c>IEither</c> into a new form via mapping functions.
   /// </summary>
   /// <typeparam name="TNewLeft">The type the left of this <c>IEither</c> shall be converted into.</typeparam>
   /// <typeparam name="TNewRight">The type the right of this <c>IEither</c> shall be converted into.</typeparam>
   /// <param name="whenLeft">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a left.</param>
   /// <param name="whenRight">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a right.</param>
   /// <returns>
   /// The content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise the content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public IEither<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<TLeft, IEither<TNewLeft, TNewRight>>  whenLeft,
                                                                Func<TRight, IEither<TNewLeft, TNewRight>> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the <c>IEither</c> into an <c>IOption</c>.
   /// </summary>
   /// <returns>
   /// The content of this <c>IEither</c> if it is a left;
   /// otherwise a none.
   /// </returns>
   public IOption<TLeft> MapLeftToOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the <c>IEither</c> into an <c>IOption</c>.
   /// </summary>
   /// <returns>
   /// The content of this <c>IEither</c> if it is a right;
   /// otherwise a none.
   /// </returns>
   public IOption<TRight> MapRightToOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IEither</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>IEither</c> shall be unified as.</typeparam>
   /// <param name="whenLeft">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a left.</param>
   /// <param name="whenRight">The mapping function that shall be applied to the content of the <c>IEither</c>, if it is a right.</param>
   /// <returns>
   /// The content of this <c>IEither</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise the content of this <c>IEither</c> mapped through <c>whenRight</c>.
   /// </returns>
   public TNew Reduce<TNew>(Func<TLeft, TNew>  whenLeft,
                            Func<TRight, TNew> whenRight);

   /* ------------------------------------------------------------ */
}