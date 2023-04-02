using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_int
   //WHEN
   //IsASuccess
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_IsASuccess_THEN_false_is_returned()
   {
      static Property Property(IResult<int, int> result)
      {
         //Arrange
         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.FailureResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}