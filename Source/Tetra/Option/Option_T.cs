namespace Tetra;

/// <summary>
/// An implementation of the "option" (Aka "maybe") monad. An option may be in one of two states:
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
public abstract partial class Option<T> : IEquatable<Option<T>>,
                                          IEquatable<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>A none <c>Option</c>.</returns>
   public static Option<T> None()
      => new NoneOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <param name="content">The value the <c>Option</c> shall contain.</param>
   /// <returns>A some <c>Option</c> that contains <c>content</c>.</returns>
   public static Option<T> Some(T content)
      => new SomeOption(content);

   /* ------------------------------------------------------------ */
   // Implicit Operator
   /* ------------------------------------------------------------ */

   public static implicit operator Option<T>(None _)
      => new NoneOption();

   /* ------------------------------------------------------------ */

   public static implicit operator Option<T>(T content)
      => new SomeOption(content);

   /* ------------------------------------------------------------ */
   // IEquatable<Option<T>> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(Option<T>? other);

   /* ------------------------------------------------------------ */
   // IEquatable<T> Methods
   /* ------------------------------------------------------------ */

   public abstract bool Equals(T? other);

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Casts the content of this <c>Option</c> to the new type.
   /// </summary>
   /// <typeparam name="TNew">The type the content of this <c>Option</c> shall be cast into.</typeparam>
   /// <returns>
   /// If <c>Option</c> is a some and the cast was successful, a some of the new type;
   /// otherwise a none.
   /// </returns>
   public abstract Option<TNew> Cast<TNew>();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Option</c> is in the none case.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Option</c> is a none;
   /// <c>false</c> if it is a some.
   /// </returns>
   public abstract bool IsANone();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Identifies if this <c>Option</c> is in the some case.
   /// </summary>
   /// <returns>
   /// <c>true</c> if this <c>Option</c> is a some;
   /// <c>false</c> if it is a none.
   /// </returns>
   public abstract bool IsASome();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Option</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Option</c> shall be transformed into.</typeparam>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Option</c>, if it is a some.</param>
   /// <returns>
   /// A some containing the content of this <c>Option</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public abstract Option<TNew> Map<TNew>(Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Maps the contents of the <c>Option</c> into a new form.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Option</c> shall be transformed into.</typeparam>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Option</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Option</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise a none.
   /// </returns>
   public abstract Option<TNew> Map<TNew>(Func<T, Option<TNew>> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Option</c> by providing a value for the none case.
   /// </summary>
   /// <param name="whenNone">A value to use, if the <c>Option</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Option</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public abstract T Reduce(T whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Option</c> by providing a function that will create a value for the none case.
   /// </summary>
   /// <param name="whenNone">A function that will return the value to use, if the <c>Option</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Option</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public abstract T Reduce(Func<T> whenNone);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Option</c> via a mapping function.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Option</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A value to use, if the <c>Option</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Option</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Option</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public abstract TNew Reduce<TNew>(TNew whenNone,
                                     Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>Option</c> via mapping functions.
   /// </summary>
   /// <typeparam name="TNew">The type this <c>Option</c> shall be unified as.</typeparam>
   /// <param name="whenNone">A function that will return the value to use, if the <c>Option</c> is a none.</param>
   /// <param name="whenSome">A mapping function that shall be applied to the content of the <c>Option</c>, if it is a some.</param>
   /// <returns>
   /// The content of this <c>Option</c> mapped through <c>whenSome</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public abstract TNew Reduce<TNew>(Func<TNew> whenNone,
                                     Func<T, TNew> whenSome);

   /* ------------------------------------------------------------ */
}