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

         var initialCurrentDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("INITIAL_CURRENT_DIRECTORY");
         var parentDirectory         = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("PARENT_DIRECTORY");
         var errorMessage            = AAA_property_test.Parameter<Message>.Create("ERROR_MESSAGE");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .AbsoluteDirectoryPath()
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(initialCurrentDirectory,
                                                   x)
                                         .Register(parentDirectory,
                                                   x.Parent()
                                                    .Unify(Function.PassThrough,
                                                           () => throw Failed.InTestSetup($"Could not retrieve the parent of {initialCurrentDirectory}, it doesn't have one?")))
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_configured_setting_the_current_directory_to_succeed(initialCurrentDirectory))
                     .WHEN(the_client.sets_the_current_directory(parentDirectory))
                     .THEN(the_return_value.is_not_in_error<Message>())
                     .And(the_current_directory.@is(parentDirectory))
                     .And(the_file_system.contains_a_directory_and_all_its_ancestors(initialCurrentDirectory))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         var newCurrentDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("NEW_CURRENT_DIRECTORY");

         yield return AAA_property_test
                     .LIBRARY(Generators
                             .TwoUniqueAbsoluteDirectoryPaths()
                             .Combine(Generators.Message(),
                                      (
                                            a,
                                            b
                                         ) => (a.Item1, a.Item2, b))
                             .Select(x => AAA_property_test
                                         .Parameters
                                         .Factory()
                                         .Register(initialCurrentDirectory,
                                                   x.Item1)
                                         .Register(newCurrentDirectory,
                                                   x.Item2)
                                         .Register(errorMessage,
                                                   x.Item3)
                                         .Create())
                             .ToArbitrary())
                     .GIVEN(the_client.has_configured_setting_the_current_directory_to_succeed(initialCurrentDirectory))
                     .WHEN(the_client.sets_the_current_directory(newCurrentDirectory))
                     .THEN(the_return_value.is_in_error(Predicate.Contains_the_text(Error_messages.Partial_DirectoryNotFound_exception(newCurrentDirectory))))
                     .And(the_current_directory.@is(initialCurrentDirectory))
                     .And(the_file_system.contains_a_directory_and_all_its_ancestors(initialCurrentDirectory))
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