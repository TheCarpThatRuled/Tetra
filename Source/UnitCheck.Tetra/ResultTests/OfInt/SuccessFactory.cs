using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;
using Result = Tetra.Result;

namespace Check.ResultTests.OfInt;

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
   //Result_of_int
   //WHEN
   //Success
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Success_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(int content)
      {
         //Act
         var actual = Result<int>.Success(content);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Result<T> Success<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result
   //WHEN
   //Success_of_int
   //THEN
   //a_success_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_WHEN_Success_of_int_THEN_a_success_containing_content_is_returned()
   {
      static Property Property(int content)
      {
         //Act
         var actual = Result.Success(content);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           content,
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}