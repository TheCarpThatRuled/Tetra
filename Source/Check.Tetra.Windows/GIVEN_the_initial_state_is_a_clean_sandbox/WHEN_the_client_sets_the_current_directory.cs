// ReSharper disable InconsistentNaming

using static Check.Constants;
using static Check.Error_messages;
using static Check.Steps;

namespace Check.GIVEN_the_initial_state_is_a_clean_sandbox;

[TestClass]
public class WHEN_the_client_sets_the_current_directory : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_sets_the_current_directory]
   public void Run
   (
      AAA_test test
   )
   {
      Log.ToStandardOutput(test.Characterisation());

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
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(the_client.Sets_the_current_directory(Path_to_the_test_sandbox))
                  .THEN(the_return_value.Is_not_in_error<Message>())
                  .And(the_file_system.Has_a_current_directory_of(Path_to_the_test_sandbox.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(the_client.Sets_the_current_directory(directory))
                  .THEN(the_return_value.Is_in_error(Predicate.Contains_the_text(Partial_DirectoryNotFound_exception(directory.Value()))))
                  .And(the_file_system.Has_a_current_directory_of(Path_to_the_test_sandbox.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .And(a_file.Exists(directory.Value()[..^1]))
                  .WHEN(the_client.Sets_the_current_directory(directory))
                  .THEN(the_return_value.Is_in_error(Predicate.Contains_the_text(Partial_directory_name_is_invalid_exception(directory.Value()))))
                  .And(the_file_system.Has_a_current_directory_of(Path_to_the_test_sandbox.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .And(a_file.Exists_and_is_locked(directory.Value()[..^1]))
                  .WHEN(the_client.Sets_the_current_directory(directory))
                  .THEN(the_return_value.Is_in_error(Predicate.Contains_the_text(Partial_directory_name_is_invalid_exception(directory.Value()))))
                  .And(the_file_system.Has_a_current_directory_of(Path_to_the_test_sandbox.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .And(a_directory.Exists(directory.Value()))
                  .WHEN(the_client.Sets_the_current_directory(directory))
                  .THEN(the_return_value.Is_not_in_error<Message>())
                  .And(the_file_system.Has_a_current_directory_of(directory.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */


      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}