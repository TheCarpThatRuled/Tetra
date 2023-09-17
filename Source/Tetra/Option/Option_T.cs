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
   /// Creates a <b>none</b>.
   /// </summary>
   /// <returns>A <b>none</b> <c>IOption</c>.</returns>
   public static IOption<T> None()
      => new NoneOption();

   /* ------------------------------------------------------------ */

   /// <summary>
   /// Creates a <b>some</b>.
   /// </summary>
   /// <param name="content">The value the <c>IOption</c> shall contain.</param>
   /// <returns>A <b>some</b> <c>IOption</c> that contains <c>content</c>.</returns>
   public static IOption<T> Some(T content)
      => new SomeOption(content);

   /* ------------------------------------------------------------ */
}