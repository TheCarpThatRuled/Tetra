using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Generators
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