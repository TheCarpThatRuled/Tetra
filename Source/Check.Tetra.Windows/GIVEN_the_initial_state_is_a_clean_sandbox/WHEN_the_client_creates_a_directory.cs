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

      var directory = Constants.PathToTheTestSandbox.Append(DirectoryComponent.Create("Dir"));

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.PathToTheTestSandbox.Value()))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Was_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.PathToTheTestSandbox.Value()))
                  .And(A_directory.Exists(directory.Value()))
                  .WHEN(The_client.Creates_a_directory(directory))
                  .THEN(The_return_value.Was_not_in_error())
                  .And(The_file_system.Contains_a_directory(directory.Value()))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}