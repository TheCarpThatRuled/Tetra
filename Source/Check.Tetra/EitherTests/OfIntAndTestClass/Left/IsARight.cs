using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndTestClass;

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
   //Left_of_int
   //WHEN
   //IsARight
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Left_of_int_WHEN_IsARight_THEN_false_is_returned()
   {
      static Property Property(Either<int, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.IsARight();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.LeftEitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}