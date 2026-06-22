namespace Proyecto_menustrip;

public partial class FrmClientes : Form
{
    public FrmClientes()
    {
        FormBorderStyle = FormBorderStyle.None;
        Panel datosCliente = new Panel();

        int txtBoxWidth = 250;
        Label lblDatosCliente = new Label();
        lblDatosCliente.AutoSize = true;
        lblDatosCliente.Text = "Datos del cliente";
        lblDatosCliente.Location = new Point(40,40);

        Label lblIdCliente = new Label();
        lblIdCliente.AutoSize = true;
        lblIdCliente.Text = "ID del cliente";
        lblIdCliente.Location = new Point(20,70);

        TextBox txtIdCliente = new TextBox();
        txtIdCliente.Width = txtBoxWidth;
        txtIdCliente.Location = new Point(20,90);

        Label lblNombreCliente = new Label();
        lblNombreCliente.AutoSize = true;
        lblNombreCliente.Text = "Nombre del cliente";
        lblNombreCliente.Location = new Point(20,120);

        TextBox txtNombreCliente = new TextBox();
        txtNombreCliente.Width = txtBoxWidth;
        txtNombreCliente.Location = new Point(20,140);

        Label lblTelefono = new Label();
        lblTelefono.AutoSize = true;
        lblTelefono.Text = "Numero de telefono";
        lblTelefono.Location = new Point(20,170);

        TextBox txtTelefono = new TextBox();
        txtTelefono.Width = txtBoxWidth;
        txtTelefono.Location = new Point(20,190);

        Label lblCorreo = new Label();
        lblCorreo.AutoSize = true;
        lblCorreo.Text = "Correo electronico";
        lblCorreo.Location = new Point(20,220);

        TextBox txtCorreo = new TextBox();
        txtCorreo.Width = txtBoxWidth;
        txtCorreo.Location = new Point(20,240);

        Label lblDireccion = new Label();
        lblDireccion.AutoSize = true;
        lblDireccion.Text = "Direccion";
        lblDireccion.Location = new Point(20,270);

        TextBox txtDireccion = new TextBox();
        txtDireccion.Width = txtBoxWidth;
        txtDireccion.Location = new Point(20,290);

        DataGridView dtClientes = new DataGridView();
        dtClientes.Size = new Size(300,300);
        dtClientes.Location = new Point(400,50);


        Controls.AddRange
        (
            lblDatosCliente,
            lblIdCliente,
            txtIdCliente,
            lblNombreCliente,
            txtNombreCliente,
            lblTelefono,
            txtTelefono,
            lblCorreo,
            txtCorreo,
            lblDireccion,
            txtDireccion,
            dtClientes
        );
    }
}
