using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct, TestStruct, TestStruct)> FourUniqueTestStructs()
      => FourUniqueTestStructs(TestStruct());

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct, TestStruct, TestStruct)> FourUniqueTestStructs
   (
      Gen<TestStruct> testStruct
   )
      => testStruct
        .FourValueTuples()
        .Where(tuple => tuple.first  != tuple.second
                     && tuple.first  != tuple.third
                     && tuple.first  != tuple.four
                     && tuple.second != tuple.third
                     && tuple.second != tuple.four
                     && tuple.third  != tuple.four);

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct()
      => TestStruct(Int32(),
                    Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct
   (
      Gen<int> int32
   )
      => TestStruct(int32,
                    Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct
   (
      Gen<double> @float
   )
      => TestStruct(Int32(),
                    @float);

   /* ------------------------------------------------------------ */

   public static Gen<TestStruct> TestStruct
   (
      Gen<int>    int32,
      Gen<double> @float
   )
      => int32
        .Zip(@float,
             Testing.TestStruct
                    .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct, TestStruct)> ThreeUniqueTestStructs()
      => ThreeUniqueTestStructs(TestStruct());

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct, TestStruct)> ThreeUniqueTestStructs
   (
      Gen<TestStruct> testStruct
   )
      => testStruct
        .ThreeValueTuples()
        .Where(tuple => tuple.first  != tuple.second
                     && tuple.first  != tuple.third
                     && tuple.second != tuple.third);

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct)> TwoUniqueTestStructs()
      => TwoUniqueTestStructs(TestStruct());

   /* ------------------------------------------------------------ */

   public static Gen<(TestStruct, TestStruct)> TwoUniqueTestStructs
   (
      Gen<TestStruct> testStruct
   )
      => testStruct
        .TwoValueTuples()
        .Where(tuple => tuple.first != tuple.second);

   /* ------------------------------------------------------------ */
}