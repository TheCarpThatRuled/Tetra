using System.Text;

namespace Tetra;

public sealed class IndentingStringBuilder
{
   /* ------------------------------------------------------------ */
   // Private Fields
   /* ------------------------------------------------------------ */

   private readonly StringBuilder _builder = new();

   private readonly string _indent;
   private readonly int    _maxDepthInclusive;
   private readonly int    _minDepthInclusive;

   //mutable
   private int _indentDepth;

   /* ------------------------------------------------------------ */
   // Private Constructors
   /* ------------------------------------------------------------ */

   private IndentingStringBuilder
   (
      string indent,
      int    minDepthInclusive,
      int    maxDepthInclusive
   )
   {
      _indent            = indent;
      _minDepthInclusive = minDepthInclusive;
      _maxDepthInclusive = maxDepthInclusive;

      _indentDepth = minDepthInclusive;
   }
   /* ------------------------------------------------------------ */
   // Factory Functions
   /* ------------------------------------------------------------ */

   public static IndentingStringBuilder Create()
      => new("   ",
             0,
             int.MaxValue);

   /* ------------------------------------------------------------ */
   // object Overridden Methods
   /* ------------------------------------------------------------ */

   public override string ToString()
      => _builder
        .ToString();

   /* ------------------------------------------------------------ */
   // Methods
   /* ------------------------------------------------------------ */

   public IndentingStringBuilder AppendWithIndent
   (
      string value
   )
   {
      AppendIndent();

      _builder.Append(value);

      return this;
   }

   /* ------------------------------------------------------------ */

   public IndentingStringBuilder AppendWithoutIndent
   (
      string value
   )
   {
      _builder.Append(value);

      return this;
   }

   /* ------------------------------------------------------------ */

   public IndentingStringBuilder AppendLine
   (
      string line
   )
   {
      AppendIndent();

      _builder.AppendLine(line);

      return this;
   }

   /* ------------------------------------------------------------ */

   public void DecreaseIndent()
   {
      if (_indentDepth > _minDepthInclusive)
      {
         --_indentDepth;
      }
   }

   /* ------------------------------------------------------------ */

   public void IncreaseIndent()
   {
      if (_indentDepth < _maxDepthInclusive)
      {
         ++_indentDepth;
      }
   }

   /* ------------------------------------------------------------ */
   // Private Methods
   /* ------------------------------------------------------------ */

   private void AppendIndent()
   {
      for (var i = 0; i < _indentDepth; ++i)
      {
         _builder.Append(_indent);
      }
   }

   /* ------------------------------------------------------------ */
}