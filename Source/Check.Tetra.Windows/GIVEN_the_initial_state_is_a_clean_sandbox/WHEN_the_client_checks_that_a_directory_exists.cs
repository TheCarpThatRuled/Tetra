// ReSharper disable InconsistentNaming

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

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.PathToTheTestSandbox.Value()))
                  .WHEN(The_client.Checks_that_a_directory_exists(Constants.PathToTheTestSandbox))
                  .THEN(The_return_value.Was(true))
                  .Crystallise();


      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(The_initial_state.Is_a_clean_sandbox(Constants.PathToTheTestSandbox.Value()))
                  .WHEN(The_client.Checks_that_a_directory_exists(Constants.PathToTheTestSandbox.Append(DirectoryComponent.Create("Non-existent"))))
                  .THEN(The_return_value.Was(false))
                  .Crystallise();


      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}