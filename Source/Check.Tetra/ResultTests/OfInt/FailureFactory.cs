using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class FailureFactory
{
   /* ------------------------------------------------------------ */
   // static Result<T> Failure(T content);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_int
   //WHEN
   //Failure
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_int_WHEN_Failure_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Result<int>.Failure(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // static Result<T> Failure<T>(T content);
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result
   //WHEN
   //Failure_of_int
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_WHEN_Failure_of_int_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Tetra.Result.Failure(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}