using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct()
      => TestStruct(Int32(),
                    Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct(Gen<int> int32)
      => TestStruct(int32,
                    Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct(Gen<double> @float)
      => TestStruct(Int32(),
                    @float);

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct(Gen<int> int32,
                                            Gen<double> @float)
      => int32
        .Zip(@float,
             Testing.TestStruct
                    .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct, TestStruct)> ThreeUniqueTestStructs()
      => ThreeUniqueTestStructs(TestStruct());

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct,TestStruct)> ThreeUniqueTestStructs(Gen<TestStruct> testStruct)
      => testStruct
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2,
                          tuple.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct)> TwoUniqueTestStructs()
      => TwoUniqueTestStructs(TestStruct());

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct)> TwoUniqueTestStructs(Gen<TestStruct> testStruct)
      => testStruct
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2));

   /* ------------------------------------------------------------ */
}