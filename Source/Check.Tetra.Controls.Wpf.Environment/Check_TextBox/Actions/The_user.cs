using Tetra.Testing;

namespace Check.Check_TextBox;

// ReSharper disable once InconsistentNaming
public static class The_user
{
   /* ------------------------------------------------------------ */
   // ArrangeAct Functions
   /* ------------------------------------------------------------ */

   public static AAA_test.IArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts> Enters_text(string text)
      => AAA_test
        .AtomicArrangeAct<TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Arranges, TheTextBoxHasBeenCreated.Asserts>
        .Create($@"{nameof(The_user)}.{nameof(Enters_text)}: ""{text}""",
                environment => environment.The_user_enters_text(text),
                environment => environment
                              .WHEN()
                              .The_user_enters_text(text)
                              .THEN());

   /* ------------------------------------------------------------ */
}