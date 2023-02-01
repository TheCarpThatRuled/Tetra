using System.Text;

namespace Tetra.Testing;

partial class AAATest
{
   public sealed class Characteriser
   {
      /* ------------------------------------------------------------ */
      // Methods
      /* ------------------------------------------------------------ */

      public string GenerateCharacterisation()
      {
         var builder = new StringBuilder();

         builder.Append("GIVEN ");

         foreach (var (clause, index) in _givenCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _givenCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         builder.Append(" WHEN ");

         foreach (var (clause, index) in _whenCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _whenCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         builder.Append(" THEN ");

         foreach (var (clause, index) in _thenCharacterisation.WithIndices())
         {
            builder.Append(clause);

            if (index != _thenCharacterisation.Length() - 1)
            {
               builder.Append(" AND ");
            }
         }

         return builder.ToString();
      }

      /* ------------------------------------------------------------ */

      public string GenerateFullCharacterisation()
      {
         var builder = new StringBuilder();

         builder.AppendLine("GIVEN");

         foreach (var (clause, index) in _givenCharacterisation.WithIndices())
         {
            builder.AppendLine(clause);

            if (index != _givenCharacterisation.Length() - 1)
            {
               builder.AppendLine("AND");
            }
         }

         builder.AppendLine("WHEN");

         foreach (var (clause, index) in _whenCharacterisation.WithIndices())
         {
            builder.AppendLine(clause);

            if (index != _whenCharacterisation.Length() - 1)
            {
               builder.AppendLine("AND");
            }
         }

         builder.AppendLine("THEN");

         foreach (var (clause, index) in _thenCharacterisation.WithIndices())
         {
            if (index != _thenCharacterisation.Length() - 1)
            {
               builder.AppendLine(clause);
               builder.AppendLine("AND");
            }
            else
            {
               builder.Append(clause);
            }
         }


         return builder.ToString();
      }

      /* ------------------------------------------------------------ */
      // Properties
      /* ------------------------------------------------------------ */

      public ISequence<string> GivenCharacterisation()
         => _givenCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> WhenCharacterisation()
         => _whenCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> ThenCharacterisation()
         => _thenCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> GivenFullCharacterisation()
         => _givenFullCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> WhenFullCharacterisation()
         => _whenFullCharacterisation;

      /* ------------------------------------------------------------ */

      public ISequence<string> ThenFullCharacterisation()
         => _thenFullCharacterisation;

      /* ------------------------------------------------------------ */
      // Internal Constructors
      /* ------------------------------------------------------------ */

      internal Characteriser(ISequence<string> givenCharacterisation,
                             ISequence<string> whenCharacterisation,
                             ISequence<string> thenCharacterisation,
                             ISequence<string> givenFullCharacterisation,
                             ISequence<string> whenFullCharacterisation,
                             ISequence<string> thenFullCharacterisation)
      {
         _givenCharacterisation     = givenCharacterisation;
         _givenFullCharacterisation = givenFullCharacterisation;
         _whenCharacterisation      = whenCharacterisation;
         _whenFullCharacterisation  = whenFullCharacterisation;
         _thenCharacterisation      = thenCharacterisation;
         _thenFullCharacterisation  = thenFullCharacterisation;
      }

      /* ------------------------------------------------------------ */
      // Private Fields
      /* ------------------------------------------------------------ */

      private readonly ISequence<string> _givenCharacterisation;
      private readonly ISequence<string> _givenFullCharacterisation;
      private readonly ISequence<string> _whenCharacterisation;
      private readonly ISequence<string> _whenFullCharacterisation;
      private readonly ISequence<string> _thenCharacterisation;
      private readonly ISequence<string> _thenFullCharacterisation;

      /* ------------------------------------------------------------ */
   }
}