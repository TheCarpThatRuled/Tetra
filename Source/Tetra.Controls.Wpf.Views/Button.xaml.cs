﻿namespace Tetra;

public partial class Button
{
   /* ------------------------------------------------------------ */
   // Constructors
   /* ------------------------------------------------------------ */

   public Button()
      => InitializeComponent();

   /* ------------------------------------------------------------ */
   // UserControl Hidden Properties
   /* ------------------------------------------------------------ */

   public object InternalContent
   {
      get => Internal.Content;
      set => Internal.Content = value;
   }

   /* ------------------------------------------------------------ */
}