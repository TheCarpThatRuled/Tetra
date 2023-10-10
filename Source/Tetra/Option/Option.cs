namespace Tetra;

/// <summary>
///    A container for functions related to <c>IOption&lt;T&gt;</c>
/// </summary>
public static class Option
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   ///    Creates a <b>some</b>.
   /// </summary>
   /// <typeparam name="T">The type of the contained object</typeparam>
   /// <param name="content">The value the <c>IOption</c> shall contain.</param>
   /// <returns>A <b>some</b> <c>IOption</c> that contains <c>content</c>.</returns>
   public static IOption<T> Some<T>
   (
      T content
   )
      => new Option<T>.SomeOption(content);

   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="sequence"></param>
   /// <returns></returns>
   public static IOption<Sequence<T>> AllAreSome<T>
   (
      this Sequence<IOption<T>> sequence
   )
      => throw Exceptions.NotImplemented();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="sequence"></param>
   /// <returns></returns>
   public static Sequence<T> JustSomes<T>
   (
      this IEnumerable<IOption<T>> sequence
   )
      => throw Exceptions.NotImplemented();

   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   /* ------------------------------------------------------------ */
}