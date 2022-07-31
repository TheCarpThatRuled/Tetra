using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfTestClass;

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
   //a_TestClass
   //WHEN
   //Left_of_TestClass_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestClass_WHEN_Left_of_TestClass_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         Left<TestClass> left = content;

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // implicit operator Left<T>(Right<T> content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Right_of_TestClass
   //WHEN
   //Left_of_TestClass_implicit_operator
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_Right_of_TestClass_WHEN_Left_of_TestClass_implicit_operator_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         Left<TestClass> left = Right<TestClass>.Create(content);

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}