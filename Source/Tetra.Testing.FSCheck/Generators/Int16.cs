namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<short> Int16()
      => Arb.Default
            .Int16()
            .Generator;

   /* ------------------------------------------------------------ */
}