using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestClass> TestClass()
      => TestClass(Int32(),
                   Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestClass> TestClass(Gen<int> int32)
      => TestClass(int32,
                   Float());

   /* ------------------------------------------------------------ */

   public static Gen<TestClass> TestClass(Gen<double> @float)
      => TestClass(Int32(),
                   @float);

   /* ------------------------------------------------------------ */

   public static Gen<TestClass> TestClass(Gen<int> int32,
                                          Gen<double> @float)
      => int32
        .Zip(@float,
             Testing.TestClass
                    .Create);

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass, TestClass)> ThreeUniqueTestClasses()
      => ThreeUniqueTestClasses(TestClass());

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass, TestClass)> ThreeUniqueTestClasses(Gen<TestClass> testStruct)
      => testStruct
        .ThreeValueTuples()
        .Where(tuple => tuple.first  != tuple.second
                     && tuple.first  != tuple.third
                     && tuple.second != tuple.third);

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass)> TwoUniqueTestClasses()
      => TwoUniqueTestClasses(TestClass());

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass)> TwoUniqueTestClasses(Gen<TestClass> testStruct)
      => testStruct
        .TwoValueTuples()
        .Where(tuple => tuple.first != tuple.second);

   /* ------------------------------------------------------------ */
}