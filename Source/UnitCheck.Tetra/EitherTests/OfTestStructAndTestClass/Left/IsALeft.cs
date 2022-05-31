using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_IsALeft
{
   /* ------------------------------------------------------------ */
   // bool IsALeft()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //IsALeft
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestStruct_WHEN_IsALeft_THEN_true_is_returned()
   {
      static Property Property(Either<TestStruct, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.IsALeft();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.LeftEitherOfTestStructAndTestClass>();

      Prop.ForAll<Either<TestStruct, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}