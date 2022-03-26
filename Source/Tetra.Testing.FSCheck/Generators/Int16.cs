using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

public static partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<short> Int16()
      => Arb
        .Default
        .Int16()
        .Generator;

   /* ------------------------------------------------------------ */
}