namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<double> Float()
      => Arb.Default
            .Float()
            .Generator;

   /* ------------------------------------------------------------ */
}