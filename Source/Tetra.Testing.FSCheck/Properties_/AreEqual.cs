using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreEqual(object? expected,
                                   object? actual)
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.ExpectedActual(expected,
                                     actual));

   /* ------------------------------------------------------------ */

   public static Property AreEqual(string message,
                                   object? expected,
                                   object? actual)
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.Message(message,
                              expected,
                              actual));

   /* ------------------------------------------------------------ */

   public static Property AreReferenceEqual(object? expected,
                                            object? actual)
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.Message("Are not reference equal",
                              expected,
                              actual));

   /* ------------------------------------------------------------ */

   public static Property AreReferenceEqual(string  message,
                                            object? expected,
                                            object? actual)
      => AsProperty(() => Equals(expected,
                                 actual))
        .Label(Failed.Message($"{message}: are not reference equal",
                              expected,
                              actual));

   /* ------------------------------------------------------------ */
}