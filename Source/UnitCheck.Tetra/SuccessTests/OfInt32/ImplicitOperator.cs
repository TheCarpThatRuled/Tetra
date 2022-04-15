using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.SuccessTests.OfInt32;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Success)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Success<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_int
   //WHEN
   //Success_of_int_implicit_operator
   //THEN
   //a_Success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_Success_of_int_implicit_operator_THEN_a_Success_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         Success<int> success = content;

         //Act
         var actual = success.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}