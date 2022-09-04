namespace Tetra;

/// <summary>
/// A container for functions related to <c>IOption&lt;T&gt;</c>
/// </summary>
public static class Option
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>IOption</c> shall contain.</param>
   /// <returns>A some <c>IOption</c> that contains <c>content</c>.</returns>
   public static IOption<T> Some<T>(T content)
      => Option<T>
        .Some(content);

   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> by providing a value for the none case.
   /// </summary>
   /// <typeparam name="T">The type of this <c>IOption</c>.</typeparam>
   /// <param name="whenNone">A value to use, if the <c>Option</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Option</c> if it is a some;
   /// otherwise <c>whenNone</c>.
   /// </returns>
   public static T Reduce<T>(this IOption<T> option,
                             T               whenNone)
      => option
        .Reduce(whenNone,
                Function.PassThrough);

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Unifies both branches of the <c>IOption</c> by providing a function that will create a value for the none case.
   /// </summary>
   /// <typeparam name="T">The type of this <c>IOption</c>.</typeparam>
   /// <param name="whenNone">A function that will return the value to use, if the <c>Option</c> is a none.</param>
   /// <returns>
   /// The content of this <c>Option</c> if it is a some;
   /// otherwise the return value of <c>whenNone</c>.
   /// </returns>
   public static T Reduce<T>(this IOption<T> option,
                             Func<T>         whenNone)
      => option
        .Reduce(whenNone,
                Function.PassThrough);

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}