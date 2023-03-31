using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

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
   //Failure_of_TestClass
   //WHEN
   //IsASuccess
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestClass_WHEN_IsASuccess_THEN_false_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.IsASuccess();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}