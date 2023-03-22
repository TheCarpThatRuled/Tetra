namespace Tetra.Testing;

public sealed class RecharacterisedArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static RecharacterisedArrange<TInitialArranges, TNextArranges> Create(IArrange<TInitialArranges, TNextArranges> arrange,
                                                                                string                                    characterisation)
      => new(arrange,
             characterisation);

   /* ------------------------------------------------------------ */
   // IArrange<TInitialArranges, TNextArranges> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => _arrange
        .AddBriefCharacterisation(characteriser);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.GivenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TNextArranges Arrange(TInitialArranges environment)
      => _arrange
        .Arrange(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IArrange<TInitialArranges, TNextArranges> _arrange;
   private readonly string                                    _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private RecharacterisedArrange(IArrange<TInitialArranges, TNextArranges> arrange,
                                  string                                    characterisation)
   {
      _arrange          = arrange;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}