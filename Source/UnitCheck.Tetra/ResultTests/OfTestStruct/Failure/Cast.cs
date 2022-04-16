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
public class Failure_Cast
{
   /* ------------------------------------------------------------ */
   // Result<TNew> Cast<TNew>()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Cast_to_int
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestStruct_WHEN_Cast_to_int_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Cast<int>();

         //Assert
         return IsAFailure(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Cast_to_TestClass
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestStruct_WHEN_Cast_to_TestClass_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Cast<TestClass>();

         //Assert
         return IsAFailure(content,
                           actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestStruct
   //WHEN
   //Cast_to_TestSubClass
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestStruct_WHEN_Cast_to_TestSubClass_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Arrange
         var result = Result<TestStruct>.Failure(content);

         //Act
         var actual = result.Cast<TestSubClass>();

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