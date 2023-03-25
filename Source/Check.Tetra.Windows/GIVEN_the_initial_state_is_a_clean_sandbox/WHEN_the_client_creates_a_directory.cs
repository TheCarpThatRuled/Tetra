// ReSharper disable InconsistentNaming

using static Check.Constants;
using static Check.Data;
using static Check.Error_messages;

namespace Check.GIVEN_the_initial_state_is_a_clean_sandbox;

[TestClass]
public class WHEN_the_client_creates_a_directory : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_creates_a_directory]
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

      var directory     = Path_to_the_test_sandbox.Append(DirectoryComponent.Create("Dir"));
      var sub_directory = directory.Append(DirectoryComponent.Create("SubDir"));

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Is_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Creates_a_directory(sub_directory))
                  .THEN(The_return_value.Is_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .And(The_file_system.Contains_a_directory(sub_directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      foreach (var existing_path in Variable_casings(directory.Value()))
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_directory.Exists(existing_path))
                     .WHEN(The_client.Creates_a_directory(directory))
                     .THEN(The_return_value.Is_not_in_error())
                     .And(The_file_system.Contains_a_directory(directory.Value()))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_directory.Exists(existing_path))
                     .WHEN(The_client.Creates_a_directory(sub_directory))
                     .THEN(The_return_value.Is_not_in_error())
                     .And(The_file_system.Contains_a_directory(directory.Value()))
                     .And(The_file_system.Contains_a_directory(sub_directory.Value()))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_file.Exists(existing_path[..^1]))
                     .WHEN(The_client.Creates_a_directory(directory))
                     .THEN(The_return_value.Is_in_error(Predicate.Contains_the_text(Partial_cannot_create_exception(directory.Value()[..^1]))))
                     .And(The_file_system.Contains_a_file(directory.Value()[..^1]))
                     .Crystallise();

         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(The_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                     .And(A_file.Exists(existing_path[..^1]))
                     .WHEN(The_client.Creates_a_directory(sub_directory))
                     .THEN(The_return_value.Is_in_error(Predicate.Contains_the_text(Partial_cannot_create_exception(directory.Value()[..^1]))))
                     .And(The_file_system.Contains_a_file(directory.Value()[..^1]))
                     .And(The_file_system.Does_not_contains_a_directory(sub_directory.Value()))
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