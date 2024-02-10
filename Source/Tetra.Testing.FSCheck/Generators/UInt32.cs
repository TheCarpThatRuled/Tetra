namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<uint> UInt32()
      => Arb.Default
            .UInt32()
            .Generator;

   /* ------------------------------------------------------------ */
}