namespace Proyecto_menustrip;

public partial class FrmClientes : Form
{
    public FrmClientes()
    {
        FormBorderStyle = FormBorderStyle.None;

        Label lbl = new Label();
        lbl.Text = "holaaa";
        lbl.AutoSize = true;
        lbl.Location = new Point(300,300);
        Controls.Add(lbl);
    }
}
