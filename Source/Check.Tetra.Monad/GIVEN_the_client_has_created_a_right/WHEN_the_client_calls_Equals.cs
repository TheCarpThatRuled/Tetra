using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_right;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Equals : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Equals]
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

      var content = FakeRight.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(null))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeNewRight>.Right(FakeNewRight.Create(content.Characterisation))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */
      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Left(FakeLeft.Create(content.Characterisation))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with("Right"))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(FakeRight.Create("Right")))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Right(FakeRight.Create("Right"))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeNewLeft, FakeRight>.Right(content)))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(content.Characterisation))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(content))
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Right(content)))
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with_self())
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}