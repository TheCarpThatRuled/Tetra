using System.Text;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetra;
using Tetra.Testing;
using static Tetra.Testing.Properties;

namespace Check.ListTests;

[TestClass]
[TestCategory(GlobalCategories.Unit)]
[TestCategory(LocalCategories.List)]
public class ToDelimitedString
{
   /* ------------------------------------------------------------ */
   // public string ToDelimitedString<T>(char delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_List_of_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedString
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_List_of_string_AND_delimiter_is_a_char_WHEN_ToDelimitedString_THEN_the_empty_string_is_returned()
   {
      static Property Property(char delimiter)
      {
         //Arrange
         var list = new List<string>();

         //Act
         var actual = list.ToDelimitedString(delimiter);

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
   //an_List_with_one_string_AND_delimiter_is_a_char
   //WHEN
   //ToDelimitedString
   //THEN
   //the_item_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedString_THEN_the_item_is_returned()
   {
      static Property Property(string value,
                               char   delimiter)
      {
         //Arrange
         var list = new List<string> {value,};

         //Act
         var actual = list.ToDelimitedString(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value,
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
   //ToDelimitedString
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_more_than_one_string_AND_delimiter_is_a_char_WHEN_ToDelimitedString_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property(List<string> list,
                               char         delimiter)
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in list.Take(list.Count - 1))
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         expected.Append(list[^1]);

         //Act
         var actual = list.ToDelimitedString(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ListOfAtLeastTwoStrings>();

      Prop.ForAll<List<string>, char>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
   // public string ToDelimitedString<T>(string delimiter)
   /* ------------------------------------------------------------ */

   //GIVEN
   //an_empty_List_of_string
   //WHEN
   //ToDelimitedString
   //THEN
   //the_empty_string_is_returned

   [TestMethod]
   public void GIVEN_an_empty_List_of_string_AND_delimiter_is_a_string_WHEN_ToDelimitedString_THEN_the_empty_string_is_returned()
   {
      static Property Property(string delimiter)
      {
         //Arrange
         var list = new List<string>();

         //Act
         var actual = list.ToDelimitedString(delimiter);

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
   //an_List_with_one_string
   //WHEN
   //ToDelimitedString
   //THEN
   //the_item_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_one_string_AND_delimiter_is_a_string_WHEN_ToDelimitedString_THEN_the_item_is_returned()
   {
      static Property Property(string value,
                               string delimiter)
      {
         //Arrange
         var list = new List<string> {value,};

         //Act
         var actual = list.ToDelimitedString(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         value,
                         actual);
      }

      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<string, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */

   //GIVEN
   //an_List_with_more_than_one_string
   //WHEN
   //ToDelimitedString
   //THEN
   //the_items_concatenated_by_the_delimiter_is_returned

   [TestMethod]
   public void GIVEN_an_List_with_more_than_one_string_AND_delimiter_is_a_string_WHEN_ToDelimitedString_THEN_the_items_concatenated_by_the_delimiter_is_returned()
   {
      static Property Property(List<string> list,
                               string       delimiter)
      {
         //Arrange
         var expected = new StringBuilder();
         foreach (var item in list.Take(list.Count - 1))
         {
            expected.Append(item);
            expected.Append(delimiter);
         }

         expected.Append(list[^1]);

         //Act
         var actual = list.ToDelimitedString(delimiter);

         //Assert
         return AreEqual(AssertMessages.ReturnValue,
                         expected.ToString(),
                         actual);
      }

      Arb.Register<LocalLibraries.ListOfAtLeastTwoStrings>();
      Arb.Register<Libraries.NonNullString>();

      Prop.ForAll<List<string>, string>(Property)
          .QuickCheckThrowOnFailure();
   }

   /* ------------------------------------------------------------ */
}