using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.FileComponentTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.FileComponent)]
public class Create
{
   /* ------------------------------------------------------------ */
   // FileComponent Create(string potentialComponent)
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //Create
   //THEN
   //a_FileComponent_with_the_string_is_returned

   [TestMethod]
   public void GIVEN_an_ASCII_letter_WHEN_Create_THEN_a_FileComponent_with_the_string_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = FileComponent.Create(value);

         //Assert
         return AreEqual(value,
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
      static Property Property(string value)
      {
         //Arrange
         var exception = Option<Exception>.None();

         //Act
         try
         {
            FileComponent.Create(value);
         }
         catch (Exception e)
         {
            exception = e;
         }

         //Assert
         return AnArgumentExceptionWasThrown(exception,
                                             Messages.IsNotAValidComponent(value,
                                                                           "file component")
                                           + " (Parameter 'potentialComponent')");
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}