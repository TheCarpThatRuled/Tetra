using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Right_IsARight
{
   /* ------------------------------------------------------------ */
   // bool IsARight()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass
   //WHEN
   //IsARight
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestClass_WHEN_IsARight_THEN_true_is_returned()
   {
      static Property Property(Either<TestClass, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.IsARight();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.RightEitherOfTestClassAndTestClass>();

      Prop.ForAll<Either<TestClass, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}