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
public class SomeFactory
{
   /* ------------------------------------------------------------ */
   // public static Error Some(Message content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Error
   //WHEN
   //Some
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Error_WHEN_Some_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(Message value)
      {
         //Act
         var actual = Error.Some(value);

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        value,
                        actual);
      }

      Arb.Register<Libraries.Message>();

      Prop.ForAll<Message>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}