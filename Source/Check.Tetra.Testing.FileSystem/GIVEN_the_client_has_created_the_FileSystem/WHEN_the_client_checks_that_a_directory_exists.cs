using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_created_the_FileSystem;

[TestClass]
public class WHEN_the_client_checks_that_a_directory_exists
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
                     .GIVEN(the_client.has_created_the_file_system(currentDirectory))
                     .WHEN(the_client.checks_that_a_directory_exists(currentDirectory))
                     .THEN(the_return_value.is_true())
                     .Crystallise();

         /* ------------------------------------------------------------ */

         var otherDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("OTHER_DIRECTORY");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .TwoUniqueAbsoluteDirectoryPaths()
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(currentDirectory,
                                                   x.Item1)
                                         .Register(otherDirectory,
                                                   x.Item2)
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_created_the_file_system(currentDirectory))
                     .WHEN(the_client.checks_that_a_directory_exists(otherDirectory))
                     .THEN(the_return_value.is_false())
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