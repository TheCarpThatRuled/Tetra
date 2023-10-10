using FsCheck;
using static Check.Messages;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Create
{
   /* ------------------------------------------------------------ */
   // public static DirectoryComponent Create(string potentialComponent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //Create
   //THEN
   //a_DirectoryComponent_with_the_string_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_Create_THEN_a_DirectoryComponent_with_the_string_is_returned()
   {
      static Property Property
      (
         string value
      )
      {
         //Act
         var actual = DirectoryComponent.Create(value);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value,
                         actual.Value());
      }

      Arb.Register<Libraries.ValidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_string_containing_an_invalid_character
   //WHEN
   //Create
   //THEN
   //an_argument_exception_is_thrown

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_character_WHEN_Create_THEN_an_argument_exception_is_thrown()
   {
      static Property Property
      (
         string value
      )
         => AnArgumentExceptionWasThrown(() => DirectoryComponent.Create(value),
                                         IsNotValidBecauseAComponentMayNotContainTheCharacters(value,
                                                                                               HumanReadableName.DirectoryComponent),
                                         "potentialComponent");

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}