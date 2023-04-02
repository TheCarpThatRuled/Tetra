namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class CompoundArrange<TInitialArranges, TMiddleArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TMiddleArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static CompoundArrange<TInitialArranges, TMiddleArranges, TNextArranges> Create(IArrange<TInitialArranges, TMiddleArranges> first,
                                                                                             IArrange<TMiddleArranges, TNextArranges>    second)
         => new(first,
                second);

      /* ------------------------------------------------------------ */
      // IArrangeAction<TArranges> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser)
      {
         _first.AddBriefCharacterisation(characteriser);
         _second.AddBriefCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser)
      {
         _first.AddFullCharacterisation(characteriser);
         _second.AddFullCharacterisation(characteriser);
      }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TInitialArranges environment)
         => _second
           .Arrange(_first.Arrange(environment));

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TInitialArranges, TMiddleArranges> _first;
      private readonly IArrange<TMiddleArranges, TNextArranges>    _second;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private CompoundArrange(IArrange<TInitialArranges, TMiddleArranges> first,
                              IArrange<TMiddleArranges, TNextArranges>    second)
      {
         _first  = first;
         _second = second;
      }

      /* ------------------------------------------------------------ */
   }
}