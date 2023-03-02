using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ErrorTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some_IsANone
{
   /* ------------------------------------------------------------ */
   // public bool IsANone()
   /* ------------------------------------------------------------ */

   //GIVEN
   //Some
   //WHEN
   //IsANone
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_Some_WHEN_IsANone_THEN_false_is_returned()
   {
      static Property Property(Message value)
      {
         //Arrange
         var error = Error.Some(value);

         //Act
         var actual = error.IsANone();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}