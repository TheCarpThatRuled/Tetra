namespace Tetra;

public sealed class Characterisation
{
   /* ------------------------------------------------------------ */
   // Implicit Operators
   /* ------------------------------------------------------------ */

   public static implicit operator Characterisation(string characterisation)
      => Create(characterisation);

   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static Characterisation Create(string characterisation)
      => new(builder => builder.AppendWithoutIndent(characterisation),
             builder => builder.AppendWithoutIndent(characterisation));

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public IndentingStringBuilder AppendBrief(IndentingStringBuilder builder)
      => _appendBrief(builder);

   /* ------------------------------------------------------------ */

   public IndentingStringBuilder AppendFull(IndentingStringBuilder builder)
      => _appendFull(builder);

   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly Func<IndentingStringBuilder, IndentingStringBuilder> _appendBrief;
   private readonly Func<IndentingStringBuilder, IndentingStringBuilder> _appendFull;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private Characterisation(Func<IndentingStringBuilder, IndentingStringBuilder> appendBrief,
                            Func<IndentingStringBuilder, IndentingStringBuilder> appendFull)
   {
      _appendBrief = appendBrief;
      _appendFull  = appendFull;
   }

   /* ------------------------------------------------------------ */
}