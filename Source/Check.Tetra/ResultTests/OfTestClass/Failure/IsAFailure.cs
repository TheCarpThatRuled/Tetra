using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

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
   //Failure_of_TestClass
   //WHEN
   //IsAFailure
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestClass_WHEN_IsAFailure_THEN_true_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.IsAFailure();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}