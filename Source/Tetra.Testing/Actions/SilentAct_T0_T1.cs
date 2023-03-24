namespace Tetra.Testing;

public sealed class SilentAct<TArranges, TAsserts> : IAct<TArranges, TAsserts>
   where TArranges : IArranges
   where TAsserts : IAsserts
{
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static SilentAct<TArranges, TAsserts> Create(IAct<TArranges, TAsserts> act)
      => new(act);

   /* ------------------------------------------------------------ */

   public static SilentAct<TArranges, TAsserts> Create(Func<TArranges, TAsserts> act)
      => new(AtomicAct<TArranges, TAsserts>.Create(act,
                                                   ""));

   /* ------------------------------------------------------------ */
   // IAct<TArranges, TAsserts> Methods
   /* ------------------------------------------------------------ */

   public void AddBriefCharacterisation(AAA_test.WhenCharacteriser characteriser) { }

   /* ------------------------------------------------------------ */

   public void AddFullCharacterisation(AAA_test.WhenCharacteriser characteriser) { }

   /* ------------------------------------------------------------ */

   public TAsserts Act(TArranges environment)
      => _act
        .Act(environment);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly IAct<TArranges, TAsserts> _act;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private SilentAct(IAct<TArranges, TAsserts> act)
      => _act = act;

   /* ------------------------------------------------------------ */
}