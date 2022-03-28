using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass()
      => TestSubClass(Int32(),
                      Float(),
                      Bool());

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<int> int32)
      => TestSubClass(int32,
                      Float(),
                      Bool());

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<double> @float)
      => TestSubClass(Int32(),
                      @float,
                      Bool());

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<bool> @bool)
      => TestSubClass(Int32(),
                      Float(),
                      @bool);

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<int> int32,
                                                Gen<double> @float)
      => TestSubClass(int32,
                      @float,
                      Bool());

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<int> int32,
                                                Gen<bool> @bool)
      => TestSubClass(int32,
                      Float(),
                      @bool);

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<double> @float,
                                                Gen<bool> @bool)
      => TestSubClass(Int32(),
                      @float,
                      @bool);

   /* ------------------------------------------------------------ */

   public static Gen<TestSubClass> TestSubClass(Gen<int> int32,
                                                Gen<double> @float,
                                                Gen<bool> @bool)
      => int32
        .Zip(@float.Zip(@bool),
             (i,
              t) => Testing
                   .TestSubClass
                   .Create(i,
                           t.Item1,
                           t.Item2));

   /* ------------------------------------------------------------ */
}