using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfTestStructAndInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Either)]
// ReSharper disable once InconsistentNaming
public class Left_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_the_content_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestStruct_WHEN_GetHashCode_THEN_the_hash_code_of_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Either<TestStruct, int>.Left(content);

         //Act
         var actual = result.GetHashCode();

         //Assert
         return AreEqual(content.GetHashCode(),
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}