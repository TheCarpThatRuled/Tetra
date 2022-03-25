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