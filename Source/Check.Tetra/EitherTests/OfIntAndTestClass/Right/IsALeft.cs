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
public class Right_IsALeft
{
   /* ------------------------------------------------------------ */
   // public bool IsALeft()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Right_of_TestClass
   //WHEN
   //IsALeft
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Right_of_TestClass_WHEN_IsALeft_THEN_false_is_returned()
   {
      static Property Property(Either<int, TestClass> either)
      {
         //Arrange
         //Act
         var actual = either.IsALeft();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.RightEitherOfInt32AndTestClass>();

      Prop.ForAll<Either<int, TestClass>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}