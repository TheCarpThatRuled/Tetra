using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Result<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Result_of_TestStruct_implicit_operator
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Result_of_TestStruct_implicit_operator_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Act
         Result<TestStruct> actual = content;

         //Assert
         return IsASuccess(content,
                        actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // implicit operator Result<T>(Message content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Message
   //WHEN
   //Result_of_TestStruct_implicit_operator
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_a_Message_WHEN_Result_of_TestStruct_implicit_operator_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Act
         Result<TestStruct> actual = content;

         //Assert
         return IsAFailure(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}