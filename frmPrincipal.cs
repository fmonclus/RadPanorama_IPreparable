using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RadPanoramaEjemplo
{
    public partial class frmPrincipal : Form
    {
        private UserControl controlActual;

        public frmPrincipal()
        {
            InitializeComponent();

            Button btnAbrirCategorias = new Button { Text = "Abrir Categorias", Dock = DockStyle.Top };
            btnAbrirCategorias.Click += (s, e) => CargarUserControl(new Pages.usrCategorias());
            Controls.Add(btnAbrirCategorias);
        }


        private void CargarUserControl(UserControl nuevoControl)
        {
            if (controlActual != null)
            {
                Controls.Remove(controlActual);
                controlActual.Dispose();
            }

            controlActual = nuevoControl;
            controlActual.Dock = DockStyle.Fill;
            Controls.Add(controlActual);
            controlActual.BringToFront();

            if (controlActual is Interfaces.IPreparable preparable)
            {
                controlActual.BeginInvoke((MethodInvoker)(() =>
                {
                    preparable.PrepararControl();
                }));
            }
        }
    }
}
