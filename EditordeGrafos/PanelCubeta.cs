using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos
{
    public partial class PanelCubeta : Panel
    {
        public PanelCubeta(List<CubetaG> cubetasGraficas)
        {
            Width = 280;
            Dock = DockStyle.Left;
            AutoScroll = true;
            BorderStyle = BorderStyle.FixedSingle;

            cubetasGraficas.Reverse();
            foreach (CubetaG cubetaG in cubetasGraficas)
            {
                cubetaG.Dock = DockStyle.Top;
                Controls.Add(cubetaG);
            }
        }
    }
}
