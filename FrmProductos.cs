namespace Proyecto_menustrip;

public partial class FrmProductos : Form
{
    public FrmProductos()
    {
        int txtBoxWidth = 300;

        Panel datosProducto = new Panel();
        datosProducto.Location = new Point(20, 40);
        datosProducto.AutoSize = true;
        Controls.Add(datosProducto);

        Panel mostrarDatosProducto = new Panel();
        mostrarDatosProducto.Location = new Point(370, 60);
        mostrarDatosProducto.AutoSize = true;
        Controls.Add(mostrarDatosProducto);

        Label lblDatosProducto = new Label();
        lblDatosProducto.AutoSize = true;
        lblDatosProducto.Text = "Datos del producto";
        lblDatosProducto.Location = new Point(20, 0);

        Label lblIdProducto = new Label();
        lblIdProducto.AutoSize = true;
        lblIdProducto.Text = "ID del producto";
        lblIdProducto.Location = new Point(0, 30);

        TextBox txtIdProducto = new TextBox();
        txtIdProducto.Width = txtBoxWidth;
        txtIdProducto.Location = new Point(0, 50);
        txtIdProducto.Enabled = false;

        Label lblNombreProducto = new Label();
        lblNombreProducto.AutoSize = true;
        lblNombreProducto.Text = "Nombre del producto";
        lblNombreProducto.Location = new Point(0, 80);

        TextBox txtNombreProducto = new TextBox();
        txtNombreProducto.Width = txtBoxWidth;
        txtNombreProducto.Location = new Point(0, 100);

        Label lblCategoria = new Label();
        lblCategoria.AutoSize = true;
        lblCategoria.Text = "Categoría";
        lblCategoria.Location = new Point(0, 130);

        TextBox txtCategoria = new TextBox();
        txtCategoria.Width = txtBoxWidth;
        txtCategoria.Location = new Point(0, 150);

        Label lblPrecioVenta = new Label();
        lblPrecioVenta.AutoSize = true;
        lblPrecioVenta.Text = "Precio de venta";
        lblPrecioVenta.Location = new Point(0, 180);

        TextBox txtPrecioVenta = new TextBox();
        txtPrecioVenta.Width = txtBoxWidth;
        txtPrecioVenta.Location = new Point(0, 200);

        Label lblPrecioAdv = new Label();
        lblPrecioAdv.AutoSize = true;
        lblPrecioAdv.Text = "(Formato: 0.00)";
        lblPrecioAdv.ForeColor = Color.Red;
        lblPrecioAdv.Location = new Point(lblPrecioVenta.Location.X + lblPrecioVenta.PreferredWidth, lblPrecioVenta.Location.Y);

        Label lblStockActual = new Label();
        lblStockActual.AutoSize = true;
        lblStockActual.Text = "Stock actual";
        lblStockActual.Location = new Point(0, 230);

        TextBox txtStockActual = new TextBox();
        txtStockActual.Width = txtBoxWidth;
        txtStockActual.Location = new Point(0, 250);

        Label lblStockAdv = new Label();
        lblStockAdv.AutoSize = true;
        lblStockAdv.Text = "(Solo números)";
        lblStockAdv.ForeColor = Color.Red;
        lblStockAdv.Location = new Point(lblStockActual.Location.X + lblStockActual.PreferredWidth, lblStockActual.Location.Y);

        DataGridView dtClientes = new DataGridView();
        dtClientes.Size = new Size(400,300);
        dtClientes.Location = new Point(0,30);

        Button btnBuscar = new Button();
        btnBuscar.AutoSize = true;
        btnBuscar.Text = "Buscar";

        TextBox txtBuscar = new TextBox();
        txtBuscar.Width = dtClientes.Width-btnBuscar.PreferredSize.Width;
        btnBuscar.Location = new Point(0+txtBuscar.Width,0);
        txtBuscar.Location = new Point(0,0);

        Button btnGuardar = new Button();
        btnGuardar.Location = new Point(0,290);
        btnGuardar.Text = "Guardar";
        btnGuardar.Font = new Font("",11,FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.BackColor = Color.Green;
        btnGuardar.Size = new Size(80,30);

        Button btnEditar = new Button();
        btnEditar.Location = new Point(85,290);
        btnEditar.Text = "Editar";
        btnEditar.Font = new Font("",11,FontStyle.Bold);
        btnEditar.ForeColor = Color.White;
        btnEditar.BackColor = Color.Orange;
        btnEditar.Size = new Size(80,30);

        Button btnEliminar = new Button();
        btnEliminar.Location = new Point(170,290);
        btnEliminar.Text = "Eliminar";
        btnEliminar.Font = new Font("",11,FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.BackColor = Color.Red;
        btnEliminar.Size = new Size(80,30);

        datosProducto.Controls.AddRange(
            lblDatosProducto,
            lblIdProducto,
            txtIdProducto,
            lblNombreProducto,
            txtNombreProducto,
            lblCategoria,
            txtCategoria,
            lblPrecioVenta,
            lblPrecioAdv,
            txtPrecioVenta,
            lblStockActual,
            lblStockAdv,
            txtStockActual,
            btnGuardar,
            btnEditar,
            btnEliminar
        );

        mostrarDatosProducto.Controls.AddRange(
            dtClientes,
            txtBuscar,
            btnBuscar
        );
    }
}
