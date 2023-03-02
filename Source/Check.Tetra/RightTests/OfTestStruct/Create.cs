using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfTestStruct;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class Create
{
   /* ------------------------------------------------------------ */
   // public static Right<T> Create(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestStruct
   //WHEN
   //Right_of_TestStruct_Create
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestStruct_WHEN_Right_of_TestStruct_Create_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(TestStruct content)
      {
         //Arrange
         var right = Right<TestStruct>.Create(content);

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestStruct>();

      Prop.ForAll<TestStruct>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}