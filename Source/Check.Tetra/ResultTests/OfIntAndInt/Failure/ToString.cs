using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

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
   //Failure_of_int
   //WHEN
   //ToString
   //THEN
   //Failure_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_int_WHEN_ToString_THEN_Failure_brackets_the_content_to_string_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result<int, int>.Failure(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Failure ({content})",
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}