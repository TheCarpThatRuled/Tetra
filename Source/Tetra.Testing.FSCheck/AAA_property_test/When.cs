using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class When
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly Func<Func<Property>> _act;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal When
      (
         Func<Func<Property>> act
      )
         => _act = act;
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Then Act()
         => new(_act());

      /* ------------------------------------------------------------ */
   }
}