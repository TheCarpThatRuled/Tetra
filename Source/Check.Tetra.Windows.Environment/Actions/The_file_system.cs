// ReSharper disable InconsistentNaming

using Tetra.Testing;

namespace Check;

public static class The_file_system
{
   /* ------------------------------------------------------------ */
   // Arrange Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrange<Arranges, Arranges> Creates_a_sandbox(string directory)
      => AAA_test
        .AtomicArrange<Arranges, Arranges>
        .Create($"{nameof(The_file_system)}.{nameof(Creates_a_sandbox)}: <{directory}>",
                environment => environment.The_file_system_creates_a_sandbox(directory));

   /* ------------------------------------------------------------ */
   // Assert Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<Asserts, Asserts> Contains_a_directory(string expected)
      => AAA_test
        .AtomicAssert<Asserts, Asserts>
        .Create($"{nameof(The_file_system)}.{nameof(Contains_a_directory)}: <{expected}>",
                environment => environment.The_file_system_contains_a_directory(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<Asserts, Asserts> Contains_a_file(string expected)
      => AAA_test
        .AtomicAssert<Asserts, Asserts>
        .Create($"{nameof(The_file_system)}.{nameof(Contains_a_file)}: <{expected}>",
                environment => environment.The_file_system_contains_a_file(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<Asserts, Asserts> Does_not_contains_a_directory(string expected)
      => AAA_test
        .AtomicAssert<Asserts, Asserts>
        .Create($"{nameof(The_file_system)}.{nameof(Does_not_contains_a_directory)}: <{expected}>",
                environment => environment.The_file_system_does_not_contain_a_directory(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<Asserts, Asserts> Does_not_contains_a_file(string expected)
      => AAA_test
        .AtomicAssert<Asserts, Asserts>
        .Create($"{nameof(The_file_system)}.{nameof(Does_not_contains_a_file)}: <{expected}>",
                environment => environment.The_file_system_does_not_contain_a_file(expected));

   /* ------------------------------------------------------------ */

   public static AAA_test.IAssert<Asserts, Asserts> Has_a_current_directory_of(string expected)
      => AAA_test
        .AtomicAssert<Asserts, Asserts>
        .Create($"{nameof(The_file_system)}.{nameof(Has_a_current_directory_of)}: <{expected}>",
                environment => environment.The_file_system_has_a_current_directory_of(expected));

   /* ------------------------------------------------------------ */
}