// ReSharper disable InconsistentNaming

using Tetra;
using static Tetra.Testing.AAA_property_test<Check.Actions, Check.Asserts>;
using static Tetra.Testing.AAA_property_test;

namespace Check;

partial class Steps
{
   public sealed class TheCurrentDirectory
   {
      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal TheCurrentDirectory() { }

      /* ------------------------------------------------------------ */
      // Asserts
      /* ------------------------------------------------------------ */

      public IAssert @is
      (
         Parameter<AbsoluteDirectoryPath> expected
      )
         => AtomicAssert
           .Create($"{nameof(the_current_directory)}.{nameof(@is)}: {expected}",
                   (
                      parameters,
                      environment
                   ) => environment
                       .FileSystem
                       .TheCurrentDirectoryIs(parameters.Retrieve(expected))
                       .Next());

      /* ------------------------------------------------------------ */
   }
}