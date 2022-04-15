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
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2,
                          tuple.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<(int, int)> TwoUniqueInt32s()
      => TwoUniqueInt32s(Int32());

   /* ------------------------------------------------------------ */

   public static Gen<(int, int)> TwoUniqueInt32s(Gen<int> int32)
      => int32
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2));

   /* ------------------------------------------------------------ */
}