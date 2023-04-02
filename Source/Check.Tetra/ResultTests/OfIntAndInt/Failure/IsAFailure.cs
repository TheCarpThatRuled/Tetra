using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_IsAFailure
{
   /* ------------------------------------------------------------ */
   // bool IsAFailure();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //IsAFailure
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_IsAFailure_THEN_true_is_returned()
   {
      static Property Property(IResult<int, int> result)
      {
         //Arrange
         //Act
         var actual = result.IsAFailure();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.FailureResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}