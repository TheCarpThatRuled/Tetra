using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.DirectoryComponentTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.DirectoryComponent)]
public class Validate
{
   /* ------------------------------------------------------------ */

   private sealed class TestComponent : DirectoryComponent
   {
      /* ------------------------------------------------------------ */
      // Functions
      /* ------------------------------------------------------------ */

      public static IError TestValidate(string potentialComponent,
                                       string componentType)
         => Validate(potentialComponent,
                     componentType);

      /* ------------------------------------------------------------ */
      // Constructor
      /* ------------------------------------------------------------ */

      private TestComponent()
         : base("") { }

      /* ------------------------------------------------------------ */
   }

   /* ------------------------------------------------------------ */
   // protected static Result<DirectoryComponent> Validate(string potentialComponent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //Validate
   //THEN
   //a_none_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_Validate_THEN_a_none_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = TestComponent.TestValidate(value,
                                                 nameof(TestComponent));

         //Assert
         return IsANone(AssertMessages.ReturnValue,
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
   //Validate
   //THEN
   //a_some_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_character_WHEN_Validate_THEN_a_some_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = TestComponent.TestValidate(value,
                                                 nameof(TestComponent));

         //Assert
         return IsASome(AssertMessages.ReturnValue,
                        Message.Create(Messages.IsNotValidBecauseAComponentMayNotContainTheCharacters(value,
                                                                                                      nameof(TestComponent))),
                        actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}