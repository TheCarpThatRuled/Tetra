using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_left;

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

      var content = FakeLeft.Create("content");

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(null))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeNewLeft, FakeRight>.Left(FakeNewLeft.Create(content.Characterisation))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */
      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Right(FakeRight.Create(content.Characterisation))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with("Left"))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(FakeLeft.Create("Left")))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Left(FakeLeft.Create("Left"))))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeNewRight>.Left(content)))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(content.Characterisation))
                  .THEN(the_return_value.is_false())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(content))
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Equals_with(Either<FakeLeft, FakeRight>.Left(content)))
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
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