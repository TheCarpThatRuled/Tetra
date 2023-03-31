using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

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
   //Success_of_TestStruct
   //WHEN
   //IsASuccess
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_IsASuccess_THEN_true_is_returned()
   {
      static Property Property(IResult<TestStruct, TestStruct> result)
      {
         //Arrange
         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.SuccessResultOfTestStructAndTestStruct>();

      Prop.ForAll<IResult<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}