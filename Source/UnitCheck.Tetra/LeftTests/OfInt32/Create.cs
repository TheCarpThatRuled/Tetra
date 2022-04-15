using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.LeftTests.OfInt32;

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
   //an_int
   //WHEN
   //Left_of_int_Create
   //THEN
   //a_Left_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_Left_of_int_Create_THEN_a_Left_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var left = Left<int>.Create(content);

         //Act
         var actual = left.Content();

         //Assert
         return AreEqual(content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}