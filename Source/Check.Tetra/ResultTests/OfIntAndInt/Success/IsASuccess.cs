using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsASuccess
{
   /* ------------------------------------------------------------ */
   // bool IsASuccess();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_IsASuccess_THEN_true_is_returned()
   {
      static Property Property(IResult<int, int> result)
      {
         //Arrange
         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.SuccessResultOfInt32AndInt32>();

      Prop.ForAll<IResult<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}