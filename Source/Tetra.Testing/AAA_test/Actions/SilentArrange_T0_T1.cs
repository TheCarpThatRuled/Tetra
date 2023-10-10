namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_test
{
   public sealed class SilentArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TInitialArranges, TNextArranges> _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrange
      (
         IArrange<TInitialArranges, TNextArranges> arrange
      )
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
      // IArrange<TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation
      (
         GivenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation
      (
         GivenCharacteriser characteriser
      ) { }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange
      (
         TInitialArranges environment
      )
         => _arrange
           .Arrange(environment);
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrange<TInitialArranges, TNextArranges> Create
      (
         IArrange<TInitialArranges, TNextArranges> arrange
      )
         => new(arrange);

      /* ------------------------------------------------------------ */

      public static SilentArrange<TInitialArranges, TNextArranges> Create
      (
         Func<TInitialArranges, TNextArranges> arrange
      )
         => new(AtomicArrange<TInitialArranges, TNextArranges>.Create("",
                                                                      arrange));

      /* ------------------------------------------------------------ */
   }
}