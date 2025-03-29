using System;
using System.Windows.Forms;

namespace RadPanoramaEjemplo.Pages
{
    public partial class usrCategorias : UserControl, Interfaces.IPreparable
    {
        private Label lbl;

        public usrCategorias()
        {
            lbl = new Label { Text = "(esperando carga)", Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            Controls.Add(lbl);
        }

        public void PrepararControl()
        {
            lbl.Text = "Categorías cargadas: " + DateTime.Now.ToLongTimeString();
        }
    }
}
