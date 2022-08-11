using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Error)]
// ReSharper disable once InconsistentNaming
public class Some_IsASome
{
   /* ------------------------------------------------------------ */
   // public bool IsASome()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //IsASome
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_Some_WHEN_IsASome_THEN_true_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var error = Error.Some(value);

         //Act
         var actual = error.IsASome();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}