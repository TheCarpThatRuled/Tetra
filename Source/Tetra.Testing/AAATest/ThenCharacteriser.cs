namespace Tetra.Testing;

partial class AAATest
{
   public sealed class ThenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public ThenCharacteriser AddClauseToCharacterisation(string clause)
      {
         _characterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public ThenCharacteriser AddClauseToFullCharacterisation(string clause)
      {
         _fullCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal ThenCharacteriser(ISequence<string> givenCharacterisation,
                                 ISequence<string> whenCharacterisation,
                                 ISequence<string> givenFullCharacterisation,
                                 ISequence<string> whenFullCharacterisation)
      {
         _givenCharacterisation     = givenCharacterisation;
         _givenFullCharacterisation = givenFullCharacterisation;
         _whenCharacterisation      = whenCharacterisation;
         _whenFullCharacterisation  = whenFullCharacterisation;
      }

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal Characteriser Finish()
         => new(_givenCharacterisation,
                _whenCharacterisation,
                _characterisation.Materialise(),
                _givenFullCharacterisation,
                _whenFullCharacterisation,
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _characterisation     = new();
      private readonly List<string> _fullCharacterisation = new();

      private readonly ISequence<string> _givenCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;
      private readonly ISequence<string> _whenCharacterisation;
      private readonly ISequence<string> _whenFullCharacterisation;

      /* ------------------------------------------------------------ */
   }
}