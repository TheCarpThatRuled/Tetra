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
public class Left_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Left_of_TestStruct
   //WHEN
   //ToString
   //THEN
   //Left_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Left_of_TestStruct_WHEN_ToString_THEN_Left_brackets_the_content_to_string_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Either<TestStruct, TestClass>.Left(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual($"Left ({content})",
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}