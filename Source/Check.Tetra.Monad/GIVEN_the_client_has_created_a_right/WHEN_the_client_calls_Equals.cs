using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.EitherEnvironment.Steps;

namespace Check.GIVEN_the_client_has_created_a_right;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class WHEN_the_client_calls_Equals : AAATestDataSource1
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [WHEN_the_client_calls_Equals]
   public void Run
   (
      AAA_test1 test
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

   protected override IEnumerable<AAA_test1> GetTests()
   {
      /* ------------------------------------------------------------ */

      var content = FakeRight.Create("content");

      /* ------------------------------------------------------------ */

      foreach (var notEquals in new object?[]
               {
                  null,
                  content.Characterisation,
                  Either<FakeLeft, FakeNewRight>.Right(FakeNewRight.Create(content.Characterisation)),
                  Either<FakeLeft, FakeRight>.Left(FakeLeft.Create(content.Characterisation)),
                  "Right",
                  FakeRight.Create("Right"),
                  Either<FakeLeft, FakeRight>.Right(FakeRight.Create("Right")),
                  Either<FakeNewLeft, FakeRight>.Right(content),
               })
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test1
                     .GIVEN(the_Client.has_created_a_right_from(content))
                     .WHEN(the_Client.calls_Equals_with(notEquals))
                     .THEN(the_return_value.is_false())
                     .Crystallise();

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */

      foreach (var equals in new object?[]
               {
                  content,
                  Either<FakeLeft, FakeRight>.Right(content)
               })
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test1
                     .GIVEN(the_Client.has_created_a_right_from(content))
                     .WHEN(the_Client.calls_Equals_with(equals))
                     .THEN(the_return_value.is_true())
                     .Crystallise();

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */

      yield return AAA_test1
                  .GIVEN(the_Client.has_created_a_right_from(content))
                  .WHEN(the_Client.calls_Equals_with_self())
                  .THEN(the_return_value.is_true())
                  .Crystallise();

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}