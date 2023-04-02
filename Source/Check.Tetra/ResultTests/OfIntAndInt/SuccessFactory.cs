using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfIntAndInt;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class SuccessFactory
{
   /* ------------------------------------------------------------ */
   // static IResult<TSuccess, TFailure> Success(TSuccess content)
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
      static Property Property(int value)
      {
         //Act
         var actual = Result<int, int>.Success(value);

         //Assert
         return IsASuccess(AssertMessages.ReturnValue,
                           value,
                           actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}