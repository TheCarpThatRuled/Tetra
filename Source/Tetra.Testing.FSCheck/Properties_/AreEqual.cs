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
}