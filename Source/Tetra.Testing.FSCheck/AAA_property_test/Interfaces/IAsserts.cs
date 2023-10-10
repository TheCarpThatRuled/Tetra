using FsCheck;

namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public interface IAsserts : IGrammar
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public Property ToProperty();

      /* ------------------------------------------------------------ */
   }
}