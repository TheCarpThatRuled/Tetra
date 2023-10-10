using System.Text;

namespace Tetra;

// ReSharper disable once InconsistentNaming
public static class IReadOnlyList_Extensions
{
   /* ------------------------------------------------------------ */
   // Extensions
   /* ------------------------------------------------------------ */

   public static string ToDelimitedString<T>
   (
      this IReadOnlyList<T> sequence,
      char                  delimiter
   )
      where T : notnull
      => sequence
        .ToDelimitedString(delimiter.ToString());

   /* ------------------------------------------------------------ */

   public static string ToDelimitedString<T>
   (
      this IReadOnlyList<T> sequence,
      string                delimiter
   )
      where T : notnull
   {
      if (!sequence.Any())
      {
         return string.Empty;
      }

      if (sequence.Count == 1)
      {
         return sequence[0]
           .ToString()!;
      }

      var concatenation = new StringBuilder();
      foreach (var item in sequence.Take(sequence.Count - 1))
      {
         concatenation.Append(item);
         concatenation.Append(delimiter);
      }

      concatenation.Append(sequence[^1]);

      return concatenation.ToString();
   }

   /* ------------------------------------------------------------ */

   public static string ToDelimitedStringWithTrailingDelimiter<T>
   (
      this IReadOnlyList<T> sequence,
      char                  delimiter
   )
      where T : notnull
      => sequence
        .ToDelimitedStringWithTrailingDelimiter(delimiter.ToString());

   /* ------------------------------------------------------------ */

   public static string ToDelimitedStringWithTrailingDelimiter<T>
   (
      this IReadOnlyList<T> sequence,
      string                delimiter
   )
      where T : notnull
   {
      var concatenation = new StringBuilder();

      foreach (var item in sequence)
      {
         concatenation.Append(item);
         concatenation.Append(delimiter);
      }

      return concatenation.ToString();
   }

   /* ------------------------------------------------------------ */
}