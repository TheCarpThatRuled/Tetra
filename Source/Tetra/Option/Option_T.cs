namespace Tetra;

/// <summary>
/// A container for functions related to <c>IOption&lt;T&gt;</c>
/// </summary>
public static partial class Option<T>
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a none.
   /// </summary>
   /// <returns>A none <c>IOption</c>.</returns>
   public static IOption<T> None()
      => new NoneOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a some.
   /// </summary>
   /// <param name="content">The value the <c>IOption</c> shall contain.</param>
   /// <returns>A some <c>IOption</c> that contains <c>content</c>.</returns>
   public static IOption<T> Some(T content)
      => new SomeOption(content);

   /* ------------------------------------------------------------ */
}