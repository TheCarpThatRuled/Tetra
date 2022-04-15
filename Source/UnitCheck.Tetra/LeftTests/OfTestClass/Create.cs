using System.Runtime.InteropServices.ComTypes;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfTestClass;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Left)]
// ReSharper disable once InconsistentNaming
public class Create
{
   /* ------------------------------------------------------------ */
   // Left<T> Create(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_TestClass
   //WHEN
   //Left_of_TestClass_Create
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_a_TestClass_WHEN_Left_of_TestClass_Create_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(TestClass content)
      {
         //Arrange
         var left = Left<TestClass>.Create(content);

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Arb.Register<Libraries.TestClass>();

      Prop.ForAll<TestClass>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}