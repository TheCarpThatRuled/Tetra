using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
   /* ------------------------------------------------------------ */

   //GIVEN
   //TestStruct
   //WHEN
   //ToString
   //THEN
   //Success_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_TestStruct_WHEN_ToString_THEN_Success_brackets_the_content_to_string_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var result = Result.Success(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Success ({content})",
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}