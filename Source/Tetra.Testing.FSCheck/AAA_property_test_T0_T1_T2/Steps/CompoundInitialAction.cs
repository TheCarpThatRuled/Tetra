namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TParameters, TActions, TAsserts>
{
   public sealed class CompoundInitialAction : IInitialAction
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IInitialAction _first;
      private readonly IAction        _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundInitialAction
      (
         IInitialAction first,
         IAction        second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundInitialAction Create
      (
         IInitialAction first,
         IAction        second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IInitialAction Methods
      /* ------------------------------------------------------------ */

      public TActions Run
      (
         TParameters                                parameters,
         AAA_property_test<TParameters>.Disposables disposables
      )
         => _second
           .Run(_first.Run(parameters,
                           disposables));

      /* ------------------------------------------------------------ */
      // ICharacterised Methods
      /* ------------------------------------------------------------ */

      public string Characterisation()
         => And(_first.Characterisation(),
                _second.Characterisation());

      /* ------------------------------------------------------------ */
   }
}