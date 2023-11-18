using Tetra;
using Tetra.Testing;

namespace Check.Check_Label;

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

   public abstract TwoWayBindingActions<object, Actions> Content { get; }

   /* ------------------------------------------------------------ */

   public abstract TwoWayBindingActions<Visibility, Actions> Visibility { get; }

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public abstract Actions CreateLabel
    (
       The_UI_creates_a_label args
    );

    /* ------------------------------------------------------------ */
}