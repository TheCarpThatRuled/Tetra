namespace Tetra.Testing;

public sealed class CompoundArrange<TInitialArranges, TNextArranges> : IArrange<TNextArranges>
   where TInitialArranges : IArranges
   where TNextArranges : IArranges
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static CompoundArrange<TInitialArranges, TNextArranges> Create(IArrange<TInitialArranges>                first,
                                                                         IArrange<TInitialArranges, TNextArranges> second)
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

   public TNextArranges Arrange(AAA_test.Disposables disposables)
      => _second
        .Arrange(_first.Arrange(disposables));

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IArrange<TInitialArranges>                _first;
   private readonly IArrange<TInitialArranges, TNextArranges> _second;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private CompoundArrange(IArrange<TInitialArranges>                first,
                           IArrange<TInitialArranges, TNextArranges> second)
   {
      _first  = first;
      _second = second;
   }

   /* ------------------------------------------------------------ */
}