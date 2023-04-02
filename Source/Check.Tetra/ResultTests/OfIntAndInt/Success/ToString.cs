using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Success_ToString
{
   /* ------------------------------------------------------------ */
   // string ToString();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Success_of_int
   //WHEN
   //ToString
   //THEN
   //Success_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Success_of_int_WHEN_ToString_THEN_Success_brackets_the_content_to_string_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Result<int, int>.Success(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"Success ({content})",
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}