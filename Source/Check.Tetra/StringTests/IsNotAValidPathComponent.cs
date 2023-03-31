using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.StringTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.String)]
public class IsNotAValidPathComponent
{
   /* ------------------------------------------------------------ */
   // public bool IsNotAValidPathComponent()
   /* ------------------------------------------------------------ */

   //GIVEN
   //a_valid_string
   //WHEN
   //IsNotAValidPathComponent
   //THEN
   //False_is_returned

   [TestMethod]
   public void GIVEN_a_valid_string_WHEN_IsNotAValidPathComponent_THEN_false_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsNotAValidPathComponent();

         //Assert
         return IsFalse(AssertMessages.ReturnValue,
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
   //IsNotAValidPathComponent
   //THEN
   //true_is_returned

   [TestMethod]
   public void GIVEN_a_string_containing_an_invalid_character_WHEN_IsNotAValidPathComponent_THEN_true_is_returned()
   {
      static Property Property(string value)
      {
         //Act
         var actual = value.IsNotAValidPathComponent();
         
         //Assert
         return IsTrue(AssertMessages.ReturnValue,
                       actual);
      }

      Arb.Register<Libraries.InvalidPathComponent>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}