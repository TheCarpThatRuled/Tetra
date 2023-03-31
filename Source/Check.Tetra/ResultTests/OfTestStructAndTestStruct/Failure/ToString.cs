using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStructAndTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //ToString
   //THEN
   //Failure_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestStruct_WHEN_ToString_THEN_Failure_brackets_the_content_to_string_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Result<TestStruct, TestStruct>.Failure(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Failure ({content})",
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}