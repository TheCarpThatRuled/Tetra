namespace Tetra;

/// <summary>
/// An implementation of the "either" monad.
/// An <c>Either</c> may be in one of two states:
/// <list type="bullet">
/// <item>
/// <description>Left, representing a state mutually exclusive with right and containing an instance of <c>TLeft</c>;</description>
/// </item>
/// <item>
/// <description>Right, representing a state mutually exclusive with left and containing an instance of <c>TRight</c>;</description>
/// </item>
/// </list>
/// </summary>
/// <typeparam name="TLeft">The type of the contained object if this is a left</typeparam>
/// <typeparam name="TRight">The type of the contained object if this is a right</typeparam>
public abstract partial class Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a left.
   /// </summary>
   /// <param name="content">The value the <c>Either</c> shall contain.</param>
   /// <returns>A left <c>Either</c> that contains <c>content</c>.</returns>
   public static Either<TLeft, TRight> Left(TLeft content)
      => new LeftEither(new(content));

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a right.
   /// </summary>
   /// <param name="content">The value the <c>Either</c> shall contain.</param>
   /// <returns>A right <c>Either</c> that contains <c>content</c>.</returns>
   public static Either<TLeft, TRight> Right(TRight content)
      => new RightEither(new(content));

   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Either<TLeft, TRight>(Left<TLeft> left)
      => new LeftEither(left);

   /* ------------------------------------------------------------ */

   public static implicit operator Either<TLeft, TRight>(Right<TRight> right)
      => new RightEither(right);

   /* ------------------------------------------------------------ */
   // IEquatable<Either<TLeft, TRight>> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Either<TLeft, TRight>? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Either</c> is in the left state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Either</c> is a left;
   /// <c>false</c> if it is a right.
   /// </returns>
   public abstract bool IsALeft();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Either</c> is in the right state.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Either</c> is a right;
   /// <c>false</c> if it is a left.
   /// </returns>
   public abstract bool IsARight();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Either</c> into a new form if it is a left.
   /// </summary>
   /// <typeparam name="TNewLeft">The type the contents of this <c>Either</c> shall be transformed into if it is a left.</typeparam>
   /// <param name="whenLeft">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a left.</param>
   /// <returns>
   /// A left containing the content of this <c>Either</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise a right containing the contents of this <c>Either</c>.
   /// </returns>
   public abstract Either<TNewLeft, TRight> Map<TNewLeft>(Func<Left<TLeft>, TNewLeft> whenLeft);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Either</c> into a new form if it is a right.
   /// </summary>
   /// <typeparam name="TNewRight">The type the contents of this <c>Either</c> shall be transformed into if it is a right.</typeparam>
   /// <param name="whenRight">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a right.</param>
   /// <returns>
   /// A right containing the content of this <c>Either</c> mapped through <c>whenRight</c> if it is a right;
   /// otherwise a left containing the contents of this <c>Either</c>.
   /// </returns>
   public abstract Either<TLeft, TNewRight> Map<TNewRight>(Func<Right<TRight>, TNewRight> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Either</c> into a new form.
   /// </summary>
   /// <typeparam name="TNewLeft">The type the contents of this <c>Either</c> shall be transformed into if it is a left.</typeparam>
   /// <typeparam name="TNewRight">The type the contents of this <c>Either</c> shall be transformed into if it is a right.</typeparam>
   /// <param name="whenLeft">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a left.</param>
   /// <param name="whenRight">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a right.</param>
   /// <returns>
   /// A left containing the content of this <c>Either</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise a right containing the content of this <c>Either</c> mapped through <c>whenRight</c>.
   /// </returns>
   public abstract Either<TNewLeft, TNewRight> Map<TNewLeft, TNewRight>(Func<Left<TLeft>, TNewLeft> whenLeft,
                                                                        Func<Right<TRight>, TNewRight> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Either</c> to the left type via a mapping function
   /// NOTE: for some reason, the type inference system cannot disambiguate between this and the <c>public abstract TRight Reduce(Func<Left<TLeft>, TRight> whenLeft)</c> overload
   /// </summary>
   /// <param name="whenRight">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a right.</param>
   /// <returns>
   /// The content of this <c>Either</c> if it is a left;
   /// otherwise the content of this <c>Either</c> mapped through <c>whenRight</c>.
   /// </returns>
   public abstract TLeft Reduce(Func<Right<TRight>, TLeft> whenRight);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Either</c> to the right type via a mapping function
   /// NOTE: for some reason, the type inference system cannot disambiguate between this and the <c>public abstract TLeft Reduce(Func<Right<TRight>, TLeft> whenRight)</c> overload
   /// </summary>
   /// <param name="whenLeft">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a left.</param>
   /// <returns>
   /// The content of this <c>Either</c> if it is a right;
   /// otherwise the content of this <c>Either</c> mapped through <c>whenLeft</c>.
   /// </returns>
   public abstract TRight Reduce(Func<Left<TLeft>, TRight> whenLeft);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Either</c> via mapping functions.
   /// </summary>
   /// <typeparam name="T">The type this <c>Either</c> shall be unified as.</typeparam>
   /// <param name="whenLeft">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a left.</param>
   /// <param name="whenRight">A mapping function that shall be applied to the content of the <c>Either</c>, if it is a right.</param>
   /// <returns>
   /// The content of this <c>Either</c> mapped through <c>whenLeft</c> if it is a left;
   /// otherwise the content of this <c>Either</c> mapped through <c>whenRight</c>.
   /// </returns>
   public abstract T Reduce<T>(Func<Left<TLeft>,T> whenLeft,
                               Func<Right<TRight>, T> whenRight);

   /* ------------------------------------------------------------ */
}