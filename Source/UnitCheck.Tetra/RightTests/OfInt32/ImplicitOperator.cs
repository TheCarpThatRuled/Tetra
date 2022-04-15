using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfInt32;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Right<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_int
   //WHEN
   //Right_of_int_implicit_operator
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_Right_of_int_implicit_operator_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         Right<int> right = content;

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // implicit operator Right<T>(Left<T> content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Left_of_int
   //WHEN
   //Right_of_int_implicit_operator
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Left_of_int_WHEN_Right_of_int_implicit_operator_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         Right<int> right = Left<int>.Create(content);

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}