using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_creates_a_directory
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
         var newDirectory     = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("NEW_DIRECTORY");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .TwoUniqueAbsoluteDirectoryPaths()
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(currentDirectory,
                                                   x.Item1)
                                         .Register(newDirectory,
                                                   x.Item2)
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_created_the_file_system(currentDirectory))
                     .WHEN(the_client.creates_a_directory(newDirectory))
                     .THEN(the_return_value.is_not_in_error<Message>())
                     .And(the_file_system.contains_a_directory_and_all_its_ancestors(newDirectory))
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