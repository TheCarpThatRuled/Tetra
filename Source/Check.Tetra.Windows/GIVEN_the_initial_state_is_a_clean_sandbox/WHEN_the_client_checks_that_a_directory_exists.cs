// ReSharper disable InconsistentNaming

using static Check.Constants;
using static Check.Data;

namespace Check.GIVEN_the_initial_state_is_a_clean_sandbox;

[TestClass]
public class WHEN_the_client_checks_that_a_directory_exists : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_checks_that_a_directory_exists]
   public void Run(AAA_test test)
   {
      Log.ToStandardOutput(test.FullCharacterisation());

      using var given = test.Create();

      var when = given.Arrange();

      var then = when.Act();

      then.Assert();
   }

   /* ------------------------------------------------------------ */
   // Overridden AAATestDataSource Methods
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */

      var directory = Path_to_the_test_sandbox.Append(DirectoryComponent.Create("Dir"));

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Checks_that_a_directory_exists(directory))
                  .THEN(The_return_value.Is(false))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      foreach (var existing_path in Variable_casings(directory.Value()))
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_directory.Exists(existing_path))
                     .WHEN(The_client.Checks_that_a_directory_exists(directory))
                     .THEN(The_return_value.Is(true))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_file.Exists(existing_path[..^1]))
                     .WHEN(The_client.Checks_that_a_directory_exists(directory))
                     .THEN(The_return_value.Is(false))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_file.Exists_and_is_locked(existing_path[..^1]))
                     .WHEN(The_client.Checks_that_a_directory_exists(directory))
                     .THEN(The_return_value.Is(false))
                     .Crystallise();

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}