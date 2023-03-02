using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString()
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
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Failure ({content})",
                         actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}