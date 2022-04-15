using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.SuccessTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Success)]
// ReSharper disable once InconsistentNaming
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Success<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Success_of_TestStruct_implicit_operator
   //THEN
   //a_Success_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Success_of_TestStruct_implicit_operator_THEN_a_Success_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         Success<TestStruct> success = content;

         //Act
         var actual = success.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}