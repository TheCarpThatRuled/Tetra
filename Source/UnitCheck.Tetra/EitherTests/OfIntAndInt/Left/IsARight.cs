using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_IsARight
{
   /* ------------------------------------------------------------ */
   // bool IsARight()
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
      static Property Property(Either<int, int> either)
      {
         //Arrange
         //Act
         var actual = either.IsARight();

         //Assert
         return IsFalse(actual);
      }

      Arb.Register<Libraries.LeftEitherOfInt32AndInt32>();

      Prop.ForAll<Either<int, int>>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}