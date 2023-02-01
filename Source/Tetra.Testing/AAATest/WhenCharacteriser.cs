namespace Tetra.Testing;

partial class AAATest
{
   public sealed class WhenCharacteriser
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public WhenCharacteriser AddClauseToCharacterisation(string clause)
      {
         _characterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */

      public WhenCharacteriser AddClauseToFullCharacterisation(string clause)
      {
         _fullCharacterisation.Add(clause);

         return this;
      }

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal WhenCharacteriser(ISequence<string> givenCharacterisation,
                                 ISequence<string> givenFullCharacterisation)
      {
         _givenCharacterisation     = givenCharacterisation;
         _givenFullCharacterisation = givenFullCharacterisation;
      }

      /* ------------------------------------------------------------ */
      // Internal Methods
      /* ------------------------------------------------------------ */

      internal ThenCharacteriser Then()
         => new(_givenCharacterisation,
                _characterisation.Materialise(),
                _givenFullCharacterisation,
                _fullCharacterisation.Materialise());

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly List<string> _characterisation     = new();
      private readonly List<string> _fullCharacterisation = new();

      private readonly ISequence<string> _givenCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;

      /* ------------------------------------------------------------ */
   }
}