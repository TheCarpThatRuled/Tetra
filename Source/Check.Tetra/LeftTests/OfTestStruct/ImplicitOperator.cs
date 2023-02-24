using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Left)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Left<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Left_of_TestStruct_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Left_of_TestStruct_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         Left<TestStruct> left = content;

         //Act
         var actual = left.Content();

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
   // implicit operator Left<T>(Right<T> content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Right_of_TestStruct
   //WHEN
   //Left_of_TestStruct_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Right_of_TestStruct_WHEN_Left_of_TestStruct_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         Left<TestStruct> left = Right<TestStruct>.Create(content);

         //Act
         var actual = left.Content();

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