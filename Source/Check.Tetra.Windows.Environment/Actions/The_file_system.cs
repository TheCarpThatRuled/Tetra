// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class The_file_system
{
   /* ------------------------------------------------------------ */
   // Arrange Functions
   /* ------------------------------------------------------------ */

   public static IArrange<Arranges,Arranges> Creates_a_sandbox(string directory)
      => AtomicArrange<Arranges, Arranges>
        .Create(environment => environment.The_file_system_creates_a_sandbox(directory),
                $"{nameof(The_file_system)}.{nameof(Creates_a_sandbox)}: <{directory}>");

   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static IAssert<Asserts, Asserts> Contains_a_directory(string expected)
      => AtomicAssert<Asserts, Asserts>
        .Create(environment => environment.The_file_system_contains_a_directory(expected),
                $"{nameof(The_file_system)}.{nameof(Contains_a_directory)}: <{expected}>");

   /* ------------------------------------------------------------ */

   public static IAssert<Asserts, Asserts> Contains_a_file(string expected)
      => AtomicAssert<Asserts, Asserts>
        .Create(environment => environment.The_file_system_contains_a_file(expected),
                $"{nameof(The_file_system)}.{nameof(Contains_a_file)}: <{expected}>");

   /* ------------------------------------------------------------ */

   public static IAssert<Asserts, Asserts> Does_not_contains_a_directory(string expected)
      => AtomicAssert<Asserts, Asserts>
        .Create(environment => environment.The_file_system_does_not_contain_a_directory(expected),
                $"{nameof(The_file_system)}.{nameof(Does_not_contains_a_directory)}: <{expected}>");

   /* ------------------------------------------------------------ */

   public static IAssert<Asserts, Asserts> Does_not_contains_a_file(string expected)
      => AtomicAssert<Asserts, Asserts>
        .Create(environment => environment.The_file_system_does_not_contain_a_file(expected),
                $"{nameof(The_file_system)}.{nameof(Does_not_contains_a_file)}: <{expected}>");

   /* ------------------------------------------------------------ */

   public static IAssert<Asserts, Asserts> Has_a_current_directory_of(string expected)
      => AtomicAssert<Asserts, Asserts>
        .Create(environment => environment.The_file_system_has_a_current_directory_of(expected),
                $"{nameof(The_file_system)}.{nameof(Has_a_current_directory_of)}: <{expected}>");

   /* ------------------------------------------------------------ */
}