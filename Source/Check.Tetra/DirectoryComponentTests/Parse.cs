using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Parse
{
   /* ------------------------------------------------------------ */
   // public static Result<DirectoryComponent> Parse(string potentialComponent)
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
         return IsASuccessAnd(AssertMessages.ReturnValue,
                              (description,
                               actualDirectoryComponent) => AreEqual(description,
                                                                     value,
                                                                     actualDirectoryComponent.Value()),
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
         return IsAFailure(AssertMessages.ReturnValue,
                           Message.Create(IsNotValidBecauseAComponentMayNotContainTheCharacters(value,
                                                                                                HumanReadableName.DirectoryComponent)),
                           actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}