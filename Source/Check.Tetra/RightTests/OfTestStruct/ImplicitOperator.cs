using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Right<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Right_of_TestStruct_implicit_operator
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Right_of_TestStruct_implicit_operator_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         Right<TestStruct> right = content;

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // implicit operator Right<T>(Left<T> content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Left_of_TestStruct
   //WHEN
   //Right_of_TestStruct_implicit_operator
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Left_of_TestStruct_WHEN_Right_of_TestStruct_implicit_operator_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         Right<TestStruct> right = Left<TestStruct>.Create(content);

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}