using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Right_IsALeft
{
   /* ------------------------------------------------------------ */
   // bool IsALeft()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestStruct
   //WHEN
   //IsALeft
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_WHEN_IsALeft_THEN_false_is_returned()
   {
      static Property Property(Either<TestClass, TestStruct> either)
      {
         //Arrange
         //Act
         var actual = either.IsALeft();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.RightEitherOfTestClassAndTestStruct>();

      Prop.ForAll<Either<TestClass, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}