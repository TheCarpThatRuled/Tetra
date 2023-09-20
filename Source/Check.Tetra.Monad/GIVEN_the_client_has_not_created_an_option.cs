using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Check.Steps;

namespace Check;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class GIVEN_the_client_has_not_created_an_option : AAATestDataSource
{
   /* ------------------------------------------------------------ */
   // Test
   /* ------------------------------------------------------------ */

   [TestMethod]
   [GIVEN_the_client_has_not_created_an_option]
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
      // None
      /* ------------------------------------------------------------ */

      yield return AAA_test
                  .GIVEN(the_Client.has_not_created_an_option())
                  .WHEN(the_Client.calls_Option_T_None())
                  .THEN(the_return_value.for_a_factory.is_a_none())
                  .Crystallise();

      /* ------------------------------------------------------------ */
      // Some
      /* ------------------------------------------------------------ */

      var content = FakeType.Create("content");

      foreach (var act in new[]
               {
                  the_Client.calls_Option_T_Some_with(content),
                  the_Client.calls_Option_Some_T_with(content),
               })
      {
         /* ------------------------------------------------------------ */

         yield return AAA_test
                     .GIVEN(the_Client.has_not_created_an_option())
                     .WHEN(act)
                     .THEN(the_return_value.for_a_factory.is_a_some_containing(content))
                     .Crystallise();

         /* ------------------------------------------------------------ */
      }

      /* ------------------------------------------------------------ */

      // ReSharper disable once RedundantJumpStatement
      yield break;

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
}