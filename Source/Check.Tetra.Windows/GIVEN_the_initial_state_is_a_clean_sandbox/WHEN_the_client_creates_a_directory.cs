// ReSharper disable InconsistentNaming

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

      var directory = Constants.Path_to_the_test_sandbox.Append(DirectoryComponent.Create("Dir"));

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Was_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .And(A_directory.Exists(directory.Value()))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Was_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .And(A_file.Exists(directory.Value()[..^1]))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Was_in_error(Predicate.Contains_the_text(Error_messages.Partial_cannot_create_exception(directory.Value()[..^1]))))
                  .And(The_file_system.Contains_a_file(directory.Value()[..^1]))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      var sub_directory = directory.Append(DirectoryComponent.Create("SubDir"));

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Creates_a_directory(sub_directory))
                  .THEN(The_return_value.Was_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .And(The_file_system.Contains_a_directory(sub_directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .And(A_file.Exists(directory.Value()[..^1]))
                  .WHEN(The_client.Creates_a_directory(sub_directory))
                  .THEN(The_return_value.Was_in_error(Predicate.Contains_the_text(Error_messages.Partial_cannot_create_exception(directory.Value()[..^1]))))
                  .And(The_file_system.Contains_a_file(directory.Value()[..^1]))
                  .And(The_file_system.Does_not_contains_a_directory(sub_directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}