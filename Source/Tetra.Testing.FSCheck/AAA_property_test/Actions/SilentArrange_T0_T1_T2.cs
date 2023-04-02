﻿namespace Tetra.Testing;

// ReSharper disable once InconsistentNaming
partial class AAA_property_test<TState>
{
   public sealed class SilentArrange<TInitialArranges, TNextArranges> : IArrange<TInitialArranges, TNextArranges>
      where TInitialArranges : IArranges
      where TNextArranges : IArranges
   {
      /* ------------------------------------------------------------ */
      // Factory Functions
      /* ------------------------------------------------------------ */

      public static SilentArrange<TInitialArranges, TNextArranges> Create(IArrange<TInitialArranges, TNextArranges> arrange)
         => new(arrange);

      /* ------------------------------------------------------------ */

      public static SilentArrange<TInitialArranges, TNextArranges> Create(Func<TState, TInitialArranges, TNextArranges> arrange)
         => new(AtomicArrange<TInitialArranges, TNextArranges>.Create(arrange,
                                                                      ""));

      /* ------------------------------------------------------------ */
      // IArrange<TState, TArranges, TAsserts> Methods
      /* ------------------------------------------------------------ */

      public void AddBriefCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public void AddFullCharacterisation(GivenCharacteriser characteriser) { }

      /* ------------------------------------------------------------ */

      public TNextArranges Arrange(TState           state,
                                   TInitialArranges environment)
         => _arrange
           .Arrange(state,
                    environment);

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly IArrange<TInitialArranges, TNextArranges> _arrange;

      /* ------------------------------------------------------------ */
      // Private Constructors
      /* ------------------------------------------------------------ */

      private SilentArrange(IArrange<TInitialArranges, TNextArranges> arrange)
         => _arrange = arrange;

      /* ------------------------------------------------------------ */
   }
}