using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;
using static Tetra.Testing.Properties;

// ReSharper disable InconsistentNaming

namespace Check.GIVEN_a_directory_exists;

[TestClass]
public class WHEN_the_client_creates_a_directory : AAAPropertyTestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_creates_a_directory]
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
   // Protected Overridden AAAPropertyTestDataSourceAttribute<string> Methods
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAA_property_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      var currentDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("CURRENT_DIRECTORY");
      var extantDirectory  = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("EXTANT_DIRECTORY");

      yield return AAA_property_test
                  .LIBRARY(Generators
                          .TwoUniqueAbsoluteDirectoryPaths()
                          .Select(x => AAA_property_test
                                      .Parameters
                                      .Factory()
                                      .Register(currentDirectory,
                                                x.Item1)
                                      .Register(extantDirectory,
                                                x.Item2)
                                      .Create())
                          .ToArbitrary())
                  .GIVEN(the_client.has_created_the_directory(currentDirectory,
                                                              extantDirectory))
                  .WHEN(the_client.creates_a_directory(extantDirectory))
                  .THEN(the_return_value.is_not_in_error<Message>())
                  .And(the_file_system.contains_a_directory_and_all_its_ancestors(extantDirectory))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var newDirectory = AAA_property_test.Parameter<AbsoluteDirectoryPath>.Create("NEW_DIRECTORY");

      yield return AAA_property_test
                  .LIBRARY(Generators
                          .ThreeUniqueAbsoluteDirectoryPaths()
                          .Select(x => AAA_property_test
                                      .Parameters
                                      .Factory()
                                      .Register(currentDirectory,
                                                x.Item1)
                                      .Register(extantDirectory,
                                                x.Item2)
                                      .Register(newDirectory,
                                                x.Item3)
                                      .Create())
                          .ToArbitrary())
                  .GIVEN(the_client.has_created_the_directory(currentDirectory,
                                                              extantDirectory))
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