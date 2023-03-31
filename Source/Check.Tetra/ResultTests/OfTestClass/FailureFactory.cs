using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

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
   //Result_of_TestClass
   //WHEN
   //Failure
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Failure_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Result<TestClass>.Failure(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public static Result<T> Failure<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result
   //WHEN
   //Failure_of_TestClass
   //THEN
   //a_failure_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Result_WHEN_Failure_of_TestClass_THEN_a_failure_containing_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Act
         var actual = Tetra.Result.Failure(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}