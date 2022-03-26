using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

public static partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<string> String()
      => Arb
        .Default
        .String()
        .Generator;

   /* ------------------------------------------------------------ */
}