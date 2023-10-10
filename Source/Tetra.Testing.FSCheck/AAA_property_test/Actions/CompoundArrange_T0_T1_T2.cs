namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class CompoundArrange<TInitialArranges, TNextArranges> : IArrange<TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TInitialArranges>                _first;
      private readonly IArrange<TInitialArranges, TNextArranges> _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundArrange
      (
         IArrange<TInitialArranges>                first,
         IArrange<TInitialArranges, TNextArranges> second
      )
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
      // IArrangeAction<TState, TArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         GivenCharacteriser characteriser
      )
      {
         _first.AddBriefCharacterisation(characteriser);
         _second.AddBriefCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         GivenCharacteriser characteriser
      )
      {
         _first.AddFullCharacterisation(characteriser);
         _second.AddFullCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         Disposables disposables,
         TState      state
      )
         => _second
           .Arrange(state,
                    _first.Arrange(disposables,
                                   state));
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundArrange<TInitialArranges, TNextArranges> Create
      (
         IArrange<TInitialArranges>                first,
         IArrange<TInitialArranges, TNextArranges> second
      )
         => new(first,
                second);

      /* ------------------------------------------------------------ */
   }
}