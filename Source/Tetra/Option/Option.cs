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
   /// <param name="content">The value the <c>Option</c> shall contain.</param>
   /// <returns>A some <c>Option</c> that contains <c>content</c>.</returns>
   public static IOption<T> Some<T>(T content)
      => Option<T>
        .Some(content);

   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static T Reduce<T>(this IOption<T> option,
                             T               whenFailure)
      => option
        .Reduce(whenFailure,
                x => x);

   /* ------------------------------------------------------------ */

   public static T Reduce<T>(this IOption<T> option,
                             Func<T>         whenFailure)
      => option
        .Reduce(whenFailure,
                x => x);

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}