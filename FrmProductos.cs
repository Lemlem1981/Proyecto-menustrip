namespace Proyecto_menustrip;

public partial class FrmProductos : Form
{
    public FrmProductos()
    {
        FormBorderStyle = FormBorderStyle.None;
        Panel datosProducto = new Panel();

        int txtBoxWidth = 250;
        Label lblDatosProducto = new Label();
        lblDatosProducto.AutoSize = true;
        lblDatosProducto.Text = "Datos del Producto";
        lblDatosProducto.Location = new Point(40,40);

        Label lblIdProducto = new Label();
        lblIdProducto.AutoSize = true;
        lblIdProducto.Text = "ID del Producto";
        lblIdProducto.Location = new Point(20,70);

        TextBox txtIdProducto = new TextBox();
        txtIdProducto.Width = txtBoxWidth;
        txtIdProducto.Location = new Point(20,90);

        Label lblNombreProducto = new Label();
        lblNombreProducto.AutoSize = true;
        lblNombreProducto.Text = "Nombre del Producto";
        lblNombreProducto.Location = new Point(20,120);

        TextBox txtNombreProducto = new TextBox();
        txtNombreProducto.Width = txtBoxWidth;
        txtNombreProducto.Location = new Point(20,140);

        Label lblTelefono = new Label();
        lblTelefono.AutoSize = true;
        lblTelefono.Text = "Categoria";
        lblTelefono.Location = new Point(20,170);

        TextBox txtTelefono = new TextBox();
        txtTelefono.Width = txtBoxWidth;
        txtTelefono.Location = new Point(20,190);

        Label lblCorreo = new Label();
        lblCorreo.AutoSize = true;
        lblCorreo.Text = "Precio de venta";
        lblCorreo.Location = new Point(20,220);

        TextBox txtCorreo = new TextBox();
        txtCorreo.Width = txtBoxWidth;
        txtCorreo.Location = new Point(20,240);

        Label lblDireccion = new Label();
        lblDireccion.AutoSize = true;
        lblDireccion.Text = "Stock actual";
        lblDireccion.Location = new Point(20,270);

        TextBox txtDireccion = new TextBox();
        txtDireccion.Width = txtBoxWidth;
        txtDireccion.Location = new Point(20,290);

        DataGridView dtProductos = new DataGridView();
        dtProductos.Size = new Size(300,300);
        dtProductos.Location = new Point(400,50);


        Controls.AddRange
        (
            lblDatosProducto,
            lblIdProducto,
            txtIdProducto,
            lblNombreProducto,
            txtNombreProducto,
            lblTelefono,
            txtTelefono,
            lblCorreo,
            txtCorreo,
            lblDireccion,
            txtDireccion,
            dtProductos
        );
    }
}
