// ReSharper disable InconsistentNaming

using static Check.Constants;
using static Check.Steps;

namespace Check.GIVEN_the_initial_state_is_a_clean_sandbox;

[TestClass]
public class WHEN_the_client_gets_the_current_directory : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_gets_the_current_directory]
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

      yield return AAA_test
                  .GIVEN(the_initial_state.Is_a_clean_sandbox(Path_to_the_test_sandbox.Value()))
                  .WHEN(the_client.Gets_the_current_directory())
                  .THEN(the_return_value.Is(Path_to_the_test_sandbox))
                  .Crystallise();


      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}