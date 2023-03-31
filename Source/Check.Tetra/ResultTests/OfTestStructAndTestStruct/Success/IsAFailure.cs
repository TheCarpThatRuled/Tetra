using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_IsAFailure
{
   /* ------------------------------------------------------------ */
   // public bool IsAFailure()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_TestStruct
   //WHEN
   //IsAFailure
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Success_of_TestStruct_WHEN_IsAFailure_THEN_false_is_returned()
   {
      static Property Property(IResult<TestStruct, TestStruct> result)
      {
         //Arrange
         //Act
         var actual = result.IsAFailure();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.SuccessResultOfTestStructAndTestStruct>();

      Prop.ForAll<IResult<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}