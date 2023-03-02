using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Left)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Left<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_int
   //WHEN
   //Left_of_int_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_Left_of_int_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         Left<int> left = content;

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // implicit operator Left<T>(Right<T> content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Right_of_int
   //WHEN
   //Left_of_int_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Right_of_int_WHEN_Left_of_int_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         Left<int> left = Right<int>.Create(content);

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}