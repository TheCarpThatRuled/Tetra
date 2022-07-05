using FsCheck;

namespace Tetra.Testing;

partial class Properties
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>(IEnumerable<T>? expected,
                                              IEnumerable<T>? actual)
      => AreSequenceEqual(expected?.ToArray(),
                          actual?.ToArray());

   /* ------------------------------------------------------------ */

   public static Property AreSequenceEqual<T>(IReadOnlyCollection<T>? expected,
                                              IReadOnlyCollection<T>? actual)
      => AsProperty(() => expected is null
                             ? actual is null
                             : actual is not null
                            && expected.SequenceEqual(actual))
        .Label(Failed.ExpectedActual(expected,
                                     actual));

   /* ------------------------------------------------------------ */
}