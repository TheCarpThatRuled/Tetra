using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // Result<T> Success(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Success
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Success_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Act
         var actual = Result<TestClass>.Success(content);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> Success<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result
   //WHEN
   //Success_of_TestClass
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_WHEN_Success_of_TestClass_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Act
         var actual = Result.Success(content);

         //Assert
         return IsASuccess(content,
                           actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}