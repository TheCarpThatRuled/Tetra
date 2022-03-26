﻿using System.Diagnostics;
using FsCheck;

namespace Tetra.Testing;

public static partial class Generators
{
   /* ------------------------------------------------------------ */
   // Functions
   /* ------------------------------------------------------------ */

   public static Gen<uint> UInt32()
      => Arb
        .Default
        .UInt32()
        .Generator;

   /* ------------------------------------------------------------ */
}