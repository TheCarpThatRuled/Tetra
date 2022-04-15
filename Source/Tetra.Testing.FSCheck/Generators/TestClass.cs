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
        .Three()
        .Where(tuple => tuple.Item1 != tuple.Item2
                     && tuple.Item1 != tuple.Item3
                     && tuple.Item2 != tuple.Item3)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2,
                          tuple.Item3));

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass)> TwoUniqueTestClasses()
      => TwoUniqueTestClasses(TestClass());

   /* ------------------------------------------------------------ */

   public static Gen<(TestClass, TestClass)> TwoUniqueTestClasses(Gen<TestClass> testStruct)
      => testStruct
        .Two()
        .Where(tuple => tuple.Item1 != tuple.Item2)
        .Select(tuple => (tuple.Item1,
                          tuple.Item2));

   /* ------------------------------------------------------------ */
}