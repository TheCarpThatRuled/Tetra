using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestClassAndInt;

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
   //Left_of_TestClass
   //WHEN
   //IsALeft
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestClass_WHEN_IsALeft_THEN_true_is_returned()
   {
      static Property Property(Either<TestClass, int> either)
      {
         //Arrange
         //Act
         var actual = either.IsALeft();

         //Assert
         return IsTrue(actual);
      }

      Arb.Register<Libraries.LeftEitherOfTestClassAndInt32>();

      Prop.ForAll<Either<TestClass, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}