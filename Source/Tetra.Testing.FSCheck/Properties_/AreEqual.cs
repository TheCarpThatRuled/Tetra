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
        .Label(Failed.Message(description,
                              expected,
                              actual));

   /* ------------------------------------------------------------ */

   public static Property AreReferenceEqual
   (
      string  description,
      object? expected,
      object? actual
   )
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.Message($"{description}: are not reference equal",
                              expected,
                              actual));

   /* ------------------------------------------------------------ */
}