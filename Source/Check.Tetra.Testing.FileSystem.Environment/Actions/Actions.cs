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

    public FileSystemActions<Actions> TestFileSystem
       => _actions
         .TestFileSystem;

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public Actions Create
   (
      AbsoluteDirectoryPath path
   )
   {
      _actions.Create(path);

      return this;
   }

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

   public Actions Exists
   (
      AbsoluteDirectoryPath path
   )
   {
      _actions.Exists(path);

      return this;
   }

   /* ------------------------------------------------------------ */

   public Actions SetCurrentDirectory
   (
      AbsoluteDirectoryPath path
   )
   {
      _actions.SetCurrentDirectory(path);

      return this;
   }

   /* ------------------------------------------------------------ */
}