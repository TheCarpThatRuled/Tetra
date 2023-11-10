using Tetra;
using Tetra.Testing;

namespace Check.Check_Button;

public abstract partial class Actions : ITestEnvironment<Asserts>
{
    /* ------------------------------------------------------------ */
    // Internal Factory Functions
    /* ------------------------------------------------------------ */

    internal static Actions Start
    (
       AAA_test1.Disposables _
    )
       => new HasNotBeenCreated();

    /* ------------------------------------------------------------ */
    // ITestEnvironment<Asserts> Methods
    /* ------------------------------------------------------------ */

    public abstract Asserts Asserts();

    /* ------------------------------------------------------------ */

    public abstract void FinishArrange();

    /* ------------------------------------------------------------ */
    // Properties
    /* ------------------------------------------------------------ */

   public abstract ButtonActions<Actions> Button { get; }

   /* ------------------------------------------------------------ */

   public abstract TwoWayBindingActions<bool, Actions> IsEnabled { get; }

   /* ------------------------------------------------------------ */

   public abstract TwoWayBindingActions<Visibility, Actions> Visibility { get; }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract Actions CreateButton
    (
       The_UI_creates_a_button args
    );

    /* ------------------------------------------------------------ */
}