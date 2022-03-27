using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.OptionTests.OfInt;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.Option)]
// ReSharper disable once InconsistentNaming
public class Some
{
   /* ------------------------------------------------------------ */
   // Option<T> Some(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option_of_int
   //WHEN
   //Some
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_of_int_WHEN_Some_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Option<int>.Some(value);

         //Assert
         return IsASome(value,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // Option<T> Some<T>(T content)
   /* ------------------------------------------------------------ */

   //GIVEN
   //Option
   //WHEN
   //Some_of_int
   //THEN
   //a_some_containing_content_is_returned

   [TestMethod]
   public void GIVEN_Option_WHEN_Some_of_int_THEN_a_some_containing_content_is_returned()
   {
      static Property Property(int value)
      {
         //Act
         var actual = Option.Some(value);

         //Assert
         return IsASome(value,
                        actual);
      }

      Prop.ForAll<int>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}