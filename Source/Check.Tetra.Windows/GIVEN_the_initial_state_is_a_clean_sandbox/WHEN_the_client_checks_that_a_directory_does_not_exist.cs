// ReSharper disable InconsistentNaming

namespace Check.GIVEN_the_initial_state_is_a_clean_sandbox;

[TestClass]
public class WHEN_the_client_checks_that_a_directory_does_not_exist : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_checks_that_a_directory_does_not_exist]
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
                  .WHEN(The_client.Checks_that_a_directory_does_not_exist(Constants.Path_to_the_test_sandbox))
                  .THEN(The_return_value.Was(false))
                  .Crystallise();


      /* ------------------------------------------------------------ */
      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .WHEN(The_client.Checks_that_a_directory_does_not_exist(directory))
                  .THEN(The_return_value.Was(true))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .And(A_directory.Exists(directory.Value()))
                  .WHEN(The_client.Checks_that_a_directory_does_not_exist(directory))
                  .THEN(The_return_value.Was(false))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.Path_to_the_test_sandbox.Value()))
                  .And(A_file.Exists(directory.Value()[..^1]))
                  .WHEN(The_client.Checks_that_a_directory_does_not_exist(directory))
                  .THEN(The_return_value.Was(true))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}