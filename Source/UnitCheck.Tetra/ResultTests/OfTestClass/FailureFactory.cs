using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class FailureFactory
{
   /* ------------------------------------------------------------ */
   // Result<T> Failure()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Result_of_TestClass
   //WHEN
   //Failure
   //THEN
   //a_failure_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_Result_of_TestClass_WHEN_Failure_THEN_a_failure_containing_the_content_is_returned()
   {
      static Property Property(Message content)
      {
         //Act
         var actual = Result<TestClass>.Failure(content);

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