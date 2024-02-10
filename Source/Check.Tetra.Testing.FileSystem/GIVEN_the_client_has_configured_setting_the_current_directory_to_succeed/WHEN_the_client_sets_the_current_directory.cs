using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_client_has_configured_setting_the_current_directory_to_succeed;

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
         // Again this should fail, as the new directory won't exist
         // See the SetCurrentDirectory tests for detail

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
                     .GIVEN(the_client.has_configured_setting_the_current_directory_to_succeed(initialCurrentDirectory))
                     .WHEN(the_client.sets_the_current_directory(newCurrentDirectory))
                     .THEN(the_return_value.is_not_in_error<Message>())
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