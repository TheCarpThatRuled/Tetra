using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_sets_the_current_directory
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
         //This test is wrong and should fail.
         //This test should expect the call to fail as the directory does not exist.
         //The positive case should be for a change to a parent directory.

         var initialCurrentDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("INITIAL_CURRENT_DIRECTORY");
         var newCurrentDirectory     = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("NEW_CURRENT_DIRECTORY");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .TwoUniqueAbsoluteDirectoryPaths()
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(initialCurrentDirectory,
                                                   x.Item1)
                                         .Register(newCurrentDirectory,
                                                   x.Item2)
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_created_the_file_system(initialCurrentDirectory))
                     .WHEN(the_client.sets_the_current_directory(newCurrentDirectory))
                     .THEN(the_file_system.contains_a_directory_and_all_its_ancestors(initialCurrentDirectory))
                     .And(the_current_directory.@is(newCurrentDirectory))
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