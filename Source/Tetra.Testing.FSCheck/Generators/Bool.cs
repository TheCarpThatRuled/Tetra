using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<bool> Bool()
      => Arb.Default
            .Bool()
            .Generator;

   /* ------------------------------------------------------------ */
}