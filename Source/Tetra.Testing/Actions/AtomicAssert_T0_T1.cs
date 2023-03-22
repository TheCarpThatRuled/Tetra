namespace Tetra.Testing;

public sealed class AtomicAssert<TInitialAsserts, TNextAsserts> : IAssert<TInitialAsserts, TNextAsserts>
   where TInitialAsserts : IAsserts
   where TNextAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static AtomicAssert<TInitialAsserts, TNextAsserts> Create(Func<TInitialAsserts, TNextAsserts> arrange,
                                                                    string                              characterisation)
      => new(arrange,
             characterisation);

   /* ------------------------------------------------------------ */
   // IAssert<TInitialAsserts, TNextAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => characteriser
        .AddClauseToBriefCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.ThenCharacteriser characteriser)
      => characteriser
        .AddClauseToFullCharacterisation(_characterisation);

   /* ------------------------------------------------------------ */

   public TNextAsserts Assert(TInitialAsserts environment)
      => _assert(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<TInitialAsserts, TNextAsserts> _assert;
   private readonly string                              _characterisation;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private AtomicAssert(Func<TInitialAsserts, TNextAsserts> assert,
                        string                              characterisation)
   {
      _assert           = assert;
      _characterisation = characterisation;
   }

   /* ------------------------------------------------------------ */
}