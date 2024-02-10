using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.EitherEnvironment.Steps;

namespace Check;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class GIVEN_the_client_has_not_created_an_either : AAATestSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [GIVEN_the_client_has_not_created_an_either]
   public void Run
   (
      AAA_test test
   )
   {
      using var given = test.Create();
      var       when  = given.Arrange();
      var       then  = when.Act();
      then.Assert();
   }

   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   protected override IEnumerable<AAA_test> GetTests()
   {
      /* ------------------------------------------------------------ */
      // None
      /* ------------------------------------------------------------ */

      var leftContent = FakeLeft.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_not_created_an_either())
                  .WHEN(the_Client.calls_Either_Left_with(leftContent))
                  .THEN(the_return_value.is_a_left_containing<FakeLeft, FakeRight>(leftContent))
                  .Crystallise();

      /* ------------------------------------------------------------ */
      // Some
      /* ------------------------------------------------------------ */

      var rightContent = FakeRight.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_not_created_an_either())
                  .WHEN(the_Client.calls_Either_Right_with(rightContent))
                  .THEN(the_return_value.is_a_right_containing<FakeLeft, FakeRight>(rightContent))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}