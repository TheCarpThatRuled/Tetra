using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.RightTests.OfInt;

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
   //an_int
   //WHEN
   //Right_of_int_Create
   //THEN
   //a_Right_containing_the_content_is_returned

   [TestMethod]
   public void GIVEN_an_int_WHEN_Right_of_int_Create_THEN_a_Right_containing_the_content_is_returned()
   {
      static Property Property(int content)
      {
         //Arrange
         var right = Right<int>.Create(content);

         //Act
         var actual = right.Content();

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         content,
                         actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}