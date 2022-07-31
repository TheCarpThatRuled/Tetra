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
public class ImplicitOperator
{
   /* ------------------------------------------------------------ */
   // implicit operator Error(Message content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_Message
   //WHEN
   //Error_implicit_operator
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_a_Message_WHEN_Error_implicit_operator_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(Message value)
      {
         //Act
         Error actual = value;

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