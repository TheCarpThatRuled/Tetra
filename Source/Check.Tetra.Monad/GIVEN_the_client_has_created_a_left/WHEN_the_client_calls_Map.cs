using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Steps;

namespace Check.GIVEN_the_client_has_created_a_left;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Map : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Map]
   public void Run(AAA_test test)
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

      var content       = FakeLeft.Create("content");
      var externalState = FakeExternalState.Create();

      var whenLeft        = FakeNewLeft.Create("whenLeft Value");
      var whenLeftAsRight = FakeNewRight.Create("whenLeft value");
      var whenRight       = FakeNewRight.Create("whenRight value");

      var whenLeftReturnsLeft   = Either<FakeNewLeft, FakeNewRight>.Left(whenLeft);
      var whenLeftReturnsRight  = Either<FakeNewLeft, FakeNewRight>.Right(whenLeftAsRight);
      var whenRightReturnsRight = Either<FakeNewLeft, FakeNewRight>.Right(whenRight);

      /* ------------------------------------------------------------ */
      // Map TLeft, TRight => TNewLeft, TNewRight
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(whenLeft,
                                                                whenRight))
                  .THEN(the_whenLeft.for_Map.was_invoked_once_with(content))
                  .And(the_whenRight.for_Map.was_not_invoked())
                  .And(the_return_value.for_either.Map.is_a_left_containing(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(externalState,
                                                                whenLeft,
                                                                whenRight))
                  .THEN(the_whenLeft.for_Map_with_externalState.was_invoked_once_with(externalState,
                                                                                      content))
                  .And(the_whenRight.for_Map_with_externalState.was_not_invoked())
                  .And(the_return_value.for_either.Map_with_externalState.is_a_left_containing(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */
      // Map TLeft, TRight => IEither<TNewLeft, TNewRight>
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(whenLeftReturnsLeft,
                                                                whenRightReturnsRight))
                  .THEN(the_whenLeft.for_Map_with_funcs_to_IEither.was_invoked_once_with(content))
                  .And(the_whenRight.for_Map_with_funcs_to_IEither.was_not_invoked())
                  .And(the_return_value.for_either.Map_with_funcs_to_IEither.is_a_left_containing(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(whenLeftReturnsRight,
                                                                whenRightReturnsRight))
                  .THEN(the_whenLeft.for_Map_with_funcs_to_IEither.was_invoked_once_with(content))
                  .And(the_whenRight.for_Map_with_funcs_to_IEither.was_not_invoked())
                  .And(the_return_value.for_either.Map_with_funcs_to_IEither.is_a_right_containing(whenLeftAsRight))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(externalState,
                                                                whenLeftReturnsLeft,
                                                                whenRightReturnsRight))
                  .THEN(the_whenLeft.for_Map_with_funcs_to_IEither_and_externalState.was_invoked_once_with(externalState,
                                                                                                           content))
                  .And(the_whenRight.for_Map_with_funcs_to_IEither_and_externalState.was_not_invoked())
                  .And(the_return_value.for_either.Map_with_funcs_to_IEither_and_externalState.is_a_left_containing(whenLeft))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_created_a_left_from(content))
                  .WHEN(the_Client.on_the_either.calls_Map_with(externalState,
                                                                whenLeftReturnsRight,
                                                                whenRightReturnsRight))
                  .THEN(the_whenLeft.for_Map_with_funcs_to_IEither_and_externalState.was_invoked_once_with(externalState,
                                                                                                           content))
                  .And(the_whenRight.for_Map_with_funcs_to_IEither_and_externalState.was_not_invoked())
                  .And(the_return_value.for_either.Map_with_funcs_to_IEither_and_externalState.is_a_right_containing(whenLeftAsRight))
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}