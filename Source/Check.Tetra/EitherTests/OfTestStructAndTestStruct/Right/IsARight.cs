using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Right_IsARight
{
   /* ------------------------------------------------------------ */
   // public bool IsARight()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestStruct
   //WHEN
   //IsARight
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestStruct_WHEN_IsARight_THEN_true_is_returned()
   {
      static Property Property(Either<TestStruct, TestStruct> either)
      {
         //Arrange
         //Act
         var actual = either.IsARight();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.RightEitherOfTestStructAndTestStruct>();

      Prop.ForAll<Either<TestStruct, TestStruct>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}