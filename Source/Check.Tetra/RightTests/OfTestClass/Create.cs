using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Right)]
// ReSharper disable once InconsistentNaming
public class Create
{
   /* ------------------------------------------------------------ */
   // public static Right<T> Create(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestClass
   //WHEN
   //Right_of_TestClass_Create
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestClass_WHEN_Right_of_TestClass_Create_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var right = Right<TestClass>.Create(content);

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}