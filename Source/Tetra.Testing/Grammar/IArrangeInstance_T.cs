// ReSharper disable InconsistentNaming

namespace Tetra.Testing;

public interface IArrangeInstance<out TAct> : IGrammar
   where TAct : IActInstance
{
   /* ------------------------------------------------------------ */
   //Methods
   /* ------------------------------------------------------------ */

   public TAct WHEN();

   /* ------------------------------------------------------------ */
}