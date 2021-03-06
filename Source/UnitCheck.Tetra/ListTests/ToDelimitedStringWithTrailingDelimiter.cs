using System.Text;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ListTests;

[TestClass]
[TestCategory(GlobalCategories.UnitCheck)]
[TestCategory(LocalCategories.List)]
public class ToDelimitedStringWithTrailingDelimiter
{
   /* ------------------------------------------------------------ */
   // string ToDelimitedStringWithTrailingDelimiter<T>(this IReadOnlyList<T> sequence,
   //                                                  char delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_List_of_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_List_of_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_empty_string_is_returned()
   {
      static Property Property(char delimiter)
      {
         //Arrange
         var list = new List<string>();

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(string.Empty,
                         actual);
      }

      Prop.ForAll<char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_with_one_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_item_plus_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_item_plus_delimiter_is_returned()
   {
      static Property Property(string value,
                               char delimiter)
      {
         //Arrange
         var list = new List<string> { value, };

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual($"{value}{delimiter}",
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string, char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_with_more_than_one_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_more_than_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property(List<string> list,
                               char delimiter)
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in list)
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ListOfAtLeastTwoStrings>();

      Prop.ForAll<List<string>, char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // string ToDelimitedStringWithTrailingDelimiter<T>(this IReadOnlyList<T> sequence,
   //                                                  string delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_List_of_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_List_of_string_AND_delimiter_is_a_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_empty_string_is_returned()
   {
      static Property Property(string delimiter)
      {
         //Arrange
         var list = new List<string>();

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(string.Empty,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_with_one_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_item_plus_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_one_string_AND_delimiter_is_a_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_item_plus_delimiter_is_returned()
   {
      static Property Property(string value,
                               string delimiter)
      {
         //Arrange
         var list = new List<string> { value,};

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);
         
         //Assert
         return AreEqual($"{value}{delimiter}",
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string,string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_with_more_than_one_string
   //WHEN
   //ToDelimitedStringWithTrailingDelimiter
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_more_than_one_string_AND_delimiter_is_a_string_WHEN_ToDelimitedStringWithTrailingDelimiter_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property(List<string> list,
                               string       delimiter)
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in list)
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         //Act
         var actual = list.ToDelimitedStringWithTrailingDelimiter(delimiter);

         //Assert
         return AreEqual(expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ListOfAtLeastTwoStrings>();
      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<List<string>, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}