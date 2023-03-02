using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_IsARight
{
   /* ------------------------------------------------------------ */
   // public bool IsARight()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //IsARight
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestStruct_WHEN_IsARight_THEN_false_is_returned()
   {
      static Property Property(Either<TestStruct, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.IsARight();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.LeftEitherOfTestStructAndTestClass>();

      Prop.ForAll<Either<TestStruct, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}