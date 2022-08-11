using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.FileComponent)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // public static Result<FileComponent> Parse(string potentialComponent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //Parse
   //THEN
   //a_success_containing_a_FileComponent_with_the_string_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_Parse_THEN_a_success_containing_a_FileComponent_with_the_string_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = FileComponent.Parse(value);

         //Assert
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualFileComponent) => AreEqual(description,
                                                                value,
                                                                actualFileComponent.Content()
                                                                                   .Value()),
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
         var actual = FileComponent.Parse(value);

         //Assert
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseAComponentMayNotContainTheCharacters(value,
                                                                                                HumanReadableName.FileComponent)),
                           actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}