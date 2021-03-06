using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.EitherTests.OfIntAndTestStruct;

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
   //Left_of_int
   //WHEN
   //ToString
   //THEN
   //Left_brackets_the_content_to_string_is_returned

   [TestMethod]
   public void GIVEN_Left_of_int_WHEN_ToString_THEN_Left_brackets_the_content_to_string_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var result = Either<int, TestStruct>.Left(content);

         //Act
         var actual = result.ToString();

         //Assert
         return AreEqual($"Left ({content})",
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}