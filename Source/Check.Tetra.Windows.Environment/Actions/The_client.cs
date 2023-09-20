// ReSharper disable InconsistentNaming

using Tetra;
using Tetra.Testing;

namespace Check;

public static class The_client
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ObjectAsserts<bool, Asserts>> Checks_that_a_directory_does_not_exist(AbsoluteDirectoryPath path)
      => AAA_test
        .AtomicAct<Arranges, ObjectAsserts<bool, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Checks_that_a_directory_does_not_exist)}: {path}",
                environment => environment.WHEN()
                                          .The_client_checks_that_a_directory_does_not_exist(path)
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ObjectAsserts<bool, Asserts>> Checks_that_a_directory_exists(AbsoluteDirectoryPath path)
      => AAA_test
        .AtomicAct<Arranges, ObjectAsserts<bool, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Checks_that_a_directory_exists)}: {path}",
                environment => environment.WHEN()
                                          .The_client_checks_that_a_directory_exists(path)
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ObjectAsserts<bool, Asserts>> Checks_that_a_file_does_not_exist(AbsoluteFilePath path)
      => AAA_test
        .AtomicAct<Arranges, ObjectAsserts<bool, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Checks_that_a_file_does_not_exist)}: {path}",
                environment => environment.WHEN()
                                          .The_client_checks_that_a_file_does_not_exist(path)
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ObjectAsserts<bool, Asserts>> Checks_that_a_file_exists(AbsoluteFilePath path)
      => AAA_test
        .AtomicAct<Arranges, ObjectAsserts<bool, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Checks_that_a_file_exists)}: {path}",
                environment => environment.WHEN()
                                          .The_client_checks_that_a_file_exists(path)
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ResultAsserts<Message, Asserts>> Creates_a_directory(AbsoluteDirectoryPath path)
      => AAA_test
        .AtomicAct<Arranges, ResultAsserts<Message, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Creates_a_directory)}: {path}",
                environment => environment.WHEN()
                                          .The_client_creates_a_directory(path)
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ObjectAsserts<AbsoluteDirectoryPath, Asserts>> Gets_the_current_directory()
      => AAA_test
        .AtomicAct<Arranges, ObjectAsserts<AbsoluteDirectoryPath, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Gets_the_current_directory)}",
                environment => environment.WHEN()
                                          .The_client_gets_the_current_directory()
                                          .THEN());

   /* ------------------------------------------------------------ */

   public static AAA_test.IAct<Arranges, ResultAsserts<Message, Asserts>> Sets_the_current_directory(AbsoluteDirectoryPath path)
      => AAA_test
        .AtomicAct<Arranges, ResultAsserts<Message, Asserts>>
        .Create($"{nameof(The_client)}.{nameof(Sets_the_current_directory)}: {path}",
                environment => environment.WHEN()
                                          .The_client_sets_the_current_directory(path)
                                          .THEN());

   /* ------------------------------------------------------------ */
}