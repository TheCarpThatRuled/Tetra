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
public class Left_ToString
{
   /* ------------------------------------------------------------ */
   // public string ToString()
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
         var result = Either<TestStruct, TestStruct>.Left(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Left ({content})",
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}