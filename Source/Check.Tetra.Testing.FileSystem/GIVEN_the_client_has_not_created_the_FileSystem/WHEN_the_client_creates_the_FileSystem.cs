using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_not_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_creates_the_FileSystem
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [Scenarios]
   public void Run
   (
      AAA_property_test test
   )
      => Property_test<AAA_property_test.Parameters>
        .Register(test.Library)
        .Run(parameters =>
         {
            using var given = test.Create(parameters);

            var when = given.Arrange();

            var then = when.Act();

            return then.Assert();
         });

   /* ------------------------------------------------------------ */
   // Scenarios
   /* ------------------------------------------------------------ */

   private sealed class Scenarios : AAAPropertyTestSource
   {

      /* ------------------------------------------------------------ */
      // Protected Overridden AAAPropertyTestDataSourceAttribute<string> Methods
      /* ------------------------------------------------------------ */

      protected override IEnumerable<AAA_property_test> GetTests()
      {
         /* ------------------------------------------------------------ */

         var currentDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("CURRENT_DIRECTORY");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .AbsoluteDirectoryPath()
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(currentDirectory,
                                                   x)
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_not_created_the_file_system())
                     .WHEN(the_client.creates_the_file_system(currentDirectory))
                     .THEN(the_file_system.contains_a_directory_and_all_its_ancestors(currentDirectory))
                     .And(the_current_directory.@is(currentDirectory))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         // ReSharper disable once RedundantJumpStatement
         yield break;

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}