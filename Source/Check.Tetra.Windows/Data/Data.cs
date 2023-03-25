using System.Reflection;

namespace Check;
internal static class Data
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static ISequence<string> Variable_casings(string path)
      => Sequence
        .From(path,
              path.ToUpperInvariant(),
              path.ToLowerInvariant());

   /* ------------------------------------------------------------ */
}