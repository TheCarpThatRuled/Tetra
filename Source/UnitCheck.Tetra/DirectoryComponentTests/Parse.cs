using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // Result<DirectoryComponent> Parse(string potentialComponent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //Parse
   //THEN
   //a_success_containing_a_DirectoryComponent_with_the_string_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_Parse_THEN_a_success_containing_a_DirectoryComponent_with_the_string_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = DirectoryComponent.Parse(value);

         //Assert
         return IsASuccessAnd(actualDirectoryComponent => value
                                                       == actualDirectoryComponent
                                                         .Content()
                                                         .Value(),
                              actual);
      }

      Arb.Register<Libraries.ValidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_character
   //WHEN
   //Parse
   //THEN
   //a_failure_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_character_WHEN_Parse_THEN_a_failure_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = DirectoryComponent.Parse(value);

         //Assert
         return IsAFailure(Message.Create(IsNotAValidComponent(value,
                                                               HumanReadableName.DirectoryComponent)),
                           actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}