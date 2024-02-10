using Tetra;
using Tetra.Testing;

namespace Check;

public sealed partial class Actions : TestEnvironment<Actions, Asserts>
{
    /* ------------------------------------------------------------ */
    // Fields
    /* ------------------------------------------------------------ */

    /* ------------------------------------------------------------ */
    // Private Fields
    /* ------------------------------------------------------------ */

    private IActions _actions;

    /* ------------------------------------------------------------ */
    // Private Constructor
    /* ------------------------------------------------------------ */

    private Actions()
       => _actions = HasNotBeenCreated.Create(actions => _actions = actions,
                                              this);

    /* ------------------------------------------------------------ */
    // Factory Functions
    /* ------------------------------------------------------------ */

    public static Actions Create
    (
       AAA_property_test.Disposables _
    )
       => new();

    /* ------------------------------------------------------------ */
    // Protected Overridden TestEnvironment<Actions, Asserts> Methods
    /* ------------------------------------------------------------ */

    protected override Asserts CreateAsserts()
       => _actions
         .Asserts();

    /* ------------------------------------------------------------ */

    protected override Actions PerformFinalise()
       => this;

   /* ------------------------------------------------------------ */
   // Properties
   /* ------------------------------------------------------------ */

   public FileSystemApiActions<Actions> Api
      => _actions
        .Api;

   /* ------------------------------------------------------------ */

   public FileSystemActions<Actions> TestApi
       => _actions
         .ConfigurationApi;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions CreateFileSystem
    (
       AbsoluteDirectoryPath currentDirectory
    )
    {
       _actions.CreateFileSystem(currentDirectory);

       return this;
   }

   /* ------------------------------------------------------------ */
}