using FsCheck;
// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<int> Int32()
      => Arb
        .Default
        .Int32()
        .Generator;

   /* ------------------------------------------------------------ */

   public static Gen<(int, int, int)> ThreeUniqueInt32s()
      => ThreeUniqueInt32s(Int32());

   /* ------------------------------------------------------------ */

   public static Gen<(int, int, int)> ThreeUniqueInt32s(Gen<int> int32)
      => int32
        .ThreeValueTuples()
        .Where(tuple => tuple.first  != tuple.second
                     && tuple.first  != tuple.third
                     && tuple.second != tuple.third);

   /* ------------------------------------------------------------ */

   public static Gen<(int, int)> TwoUniqueInt32s()
      => TwoUniqueInt32s(Int32());

   /* ------------------------------------------------------------ */

   public static Gen<(int, int)> TwoUniqueInt32s(Gen<int> int32)
      => int32
        .TwoValueTuples()
        .Where(tuple => tuple.first != tuple.second);

   /* ------------------------------------------------------------ */
}