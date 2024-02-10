namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreEqual
   (
      string  description,
      object? expected,
      object? actual
   )
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.InTheAsserts(description,
                              Failed.Expected(expected),
                              Failed.Actual(actual)));

   /* ------------------------------------------------------------ */

   public static Property AreReferenceEqual
   (
      string  description,
      object? expected,
      object? actual
   )
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.InTheAsserts($"{description}: are not reference equal",
                                   Failed.Expected(expected),
                                   Failed.Actual(actual)));

   /* ------------------------------------------------------------ */
}