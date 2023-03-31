using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.ResultTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Result)]
// ReSharper disable once InconsistentNaming
public class Failure_GetHashCode
{
   /* ------------------------------------------------------------ */
   // int GetHashCode();
   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_TestClass
   //WHEN
   //GetHashCode
   //THEN
   //the_hash_code_of_the_content_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_TestClass_WHEN_GetHashCode_THEN_the_hash_code_of_the_content_is_returned()
   {
      static Property Property(TestClass value)
      {
         //Arrange
         var result = Tetra.Result.Failure(value);

         //Act
         var actual = result.GetHashCode();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value.GetHashCode(),
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //Failure_of_null
   //WHEN
   //GetHashCode
   //THEN
   //zero_is_returned

   [TestMethod]
   public void GIVEN_Failure_of_null_WHEN_GetHashCode_THEN_zero_is_returned()
   {
      //Arrange
      var result = Tetra.Result.Failure(default(TestClass));

      //Act
      var actual = result.GetHashCode();

      //Assert
      Assert.That
            .AreEqual(AssertMessages.ReturnValue,
                      0,
                      actual);
   }

   /* ------------------------------------------------------------ */
}