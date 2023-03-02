using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // Result<T> Success(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestStruct
   //WHEN
   //Success
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestStruct_WHEN_Success_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Act
         var actual = Result<TestStruct>.Success(content);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> Success<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result
   //WHEN
   //TestStruct
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_WHEN_TestStruct_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Act
         var actual = Result.Success(content);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}