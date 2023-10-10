using System.Text;
using FsCheck;
using static Tetra.Testing.Properties;

namespace Check.IReadOnlyListTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.IReadOnlyList)]
public class ToDelimitedStringWithTrailingDelimiter
{
   /* ------------------------------------------------------------ */
   // public string ToDelimitedStringWithTrailingDelimiter<T>(char delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_IReadOnlyList_of_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_IReadOnlyList_of_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_empty_string_is_returned()
   {
      static Property Property
      (
         char delimiter
      )
      {
         //Arrange
         var array = Array.Empty<string>();

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         string.Empty,
                         actual);
      }

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_IReadOnlyList_with_one_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_item_plus_delimiter_is_returned

   [TestMethod]
   public void GIVEN_a_IReadOnlyList_with_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_item_plus_delimiter_is_returned()
   {
      static Property Property
      (
         string value,
         char   delimiter
      )
      {
         //Arrange
         var array = new[] {value,};

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"{value}{delimiter}",
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string, char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_IReadOnlyList_with_more_than_one_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void
      GIVEN_a_IReadOnlyList_with_more_than_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property
      (
         string[] array,
         char     delimiter
      )
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in array)
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ArrayOfAtLeastTwoStrings>();

      Prop.ForAll<string[], char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public string ToDelimitedStringWithTrailingDelimiter<T>(string delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_IReadOnlyList_of_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_IReadOnlyList_of_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_empty_string_is_returned()
   {
      static Property Property
      (
         string delimiter
      )
      {
         //Arrange
         var array = Array.Empty<string>();

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         string.Empty,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_IReadOnlyList_with_one_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_item_plus_delimiter_is_returned

   [TestMethod]
   public void GIVEN_a_IReadOnlyList_with_one_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_item_plus_delimiter_is_returned()
   {
      static Property Property
      (
         string value,
         string delimiter
      )
      {
         //Arrange
         var array = new[] {value,};

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         $"{value}{delimiter}",
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //a_IReadOnlyList_with_more_than_one_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void GIVEN_a_IReadOnlyList_with_more_than_one_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property
      (
         string[] array,
         string   delimiter
      )
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in array)
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         //Act
         var actual = array.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ArrayOfAtLeastTwoStrings>();
      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string[], string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}