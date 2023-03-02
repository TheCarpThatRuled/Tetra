using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.StringTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.String)]
public class IsAValidPathComponent
{
   /* ------------------------------------------------------------ */
   // public bool IsAValidPathComponent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //IsAValidPathComponent
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_IsAValidPathComponent_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsAValidPathComponent();

         //Assert
         return IsTrue(AssertMessages.ReturnValue,
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
   //IsAValidPathComponent
   //THEN
   //false_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_character_WHEN_IsAValidPathComponent_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsAValidPathComponent();
         
         //Assert
         return IsFalse(AssertMessages.ReturnValue,
                        actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}