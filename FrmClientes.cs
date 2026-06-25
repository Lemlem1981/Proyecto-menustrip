using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using MySqlConnector;

namespace Proyecto_menustrip;

public partial class FrmClientes : Form
{
    MySqlConnection? connection;
    public FrmClientes()
    {
        int txtBoxWidth = 300;

        Panel datosCliente = new Panel();
        datosCliente.Location = new Point(20,40);
        datosCliente.AutoSize = true;
        Controls.Add(datosCliente);

        Panel mostrarDatosCliente = new Panel();
        mostrarDatosCliente.Location = new Point(370,60);
        mostrarDatosCliente.AutoSize = true;
        Controls.Add(mostrarDatosCliente);
        // datosCliente.SendToBack();
        // datosCliente.Paint += (sender, e) =>
        // {
        //     using Pen lapiz = new Pen(Color.Black);
        //     lapiz.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

        //     e.Graphics.DrawRectangle(
        //         lapiz,
        //         0,
        //         0,
        //         datosCliente.Width - 1,
        //         datosCliente.Height - 1
        //     );
        // };

        Label lblDatosCliente = new Label();
        lblDatosCliente.AutoSize = true;
        lblDatosCliente.Text = "Datos del cliente";
        lblDatosCliente.Location = new Point(20,0);

        Label lblIdCliente = new Label();
        lblIdCliente.AutoSize = true;
        lblIdCliente.Text = "ID del cliente";
        lblIdCliente.Location = new Point(0,30);

        TextBox txtIdCliente = new TextBox();
        txtIdCliente.Width = txtBoxWidth;
        txtIdCliente.Location = new Point(0,50);
        txtIdCliente.Enabled = false;
        txtIdCliente.ReadOnly = true;

        Label lblNombreCliente = new Label();
        lblNombreCliente.AutoSize = true;
        lblNombreCliente.Text = "Nombre del cliente";
        lblNombreCliente.Location = new Point(0,80);
        Label lblNombreAdv = new Label();
        lblNombreAdv.AutoSize = true;
        lblNombreAdv.Text = "Obligatorio";
        lblNombreAdv.ForeColor = Color.Red;
        lblNombreAdv.Location = new Point(lblNombreCliente.Location.X+lblNombreCliente.PreferredWidth,lblNombreCliente.Location.Y);

        TextBox txtNombreCliente = new TextBox();
        txtNombreCliente.Width = txtBoxWidth;
        txtNombreCliente.Location = new Point(0,100);
        txtNombreCliente.TextChanged += (s,e) =>
        {
            if(txtNombreCliente.Text == string.Empty)
            lblNombreAdv.Text = "Obligatorio";
            else if(txtNombreCliente.TextLength < 3)
            lblNombreAdv.Text = "Debe contener almenos 3 caracteres";
            else
            lblNombreAdv.Text = string.Empty;
        };

        Label lblTelefono = new Label();
        lblTelefono.AutoSize = true;
        lblTelefono.Text = "Numero de telefono";
        lblTelefono.Location = new Point(0,130);
        Label lblTelefonoAdv = new Label();
        lblTelefonoAdv.AutoSize = true;
        lblTelefonoAdv.Text = "(Formato: xxxxxxxx)";
        lblTelefonoAdv.ForeColor = Color.Red;
        lblTelefonoAdv.Location = new Point(lblTelefono.Location.X+lblTelefono.PreferredWidth,lblTelefono.Location.Y);

        TextBox txtTelefono = new TextBox();
        txtTelefono.Width = txtBoxWidth;
        txtTelefono.Location = new Point(0,150);

        Label lblCorreo = new Label();
        lblCorreo.AutoSize = true;
        lblCorreo.Text = "Correo electronico";
        lblCorreo.Location = new Point(0,180);
        Label lblCorreoAdv = new Label();
        lblCorreoAdv.AutoSize = true;
        lblCorreoAdv.Text = "(Formato: usuario@dominio.com)";
        lblCorreoAdv.ForeColor = Color.Red;
        lblCorreoAdv.Location = new Point(lblCorreo.Location.X+lblCorreo.PreferredWidth,lblCorreo.Location.Y);

        TextBox txtCorreo = new TextBox();
        txtCorreo.Width = txtBoxWidth;
        txtCorreo.Location = new Point(0,200);

        Label lblDireccion = new Label();
        lblDireccion.AutoSize = true;
        lblDireccion.Text = "Direccion";
        lblDireccion.Location = new Point(0,230);

        TextBox txtDireccion = new TextBox();
        txtDireccion.Width = txtBoxWidth;
        txtDireccion.Location = new Point(0,250);

        DataGridView dtClientes = new DataGridView();
        dtClientes.Size = new Size(400,300);
        dtClientes.Location = new Point(0,30);

        Button btnBuscar = new Button();
        btnBuscar.AutoSize = true;
        btnBuscar.Text = "Buscar";

        TextBox txtBuscar = new TextBox();
        txtBuscar.Width = dtClientes.Width-btnBuscar.PreferredSize.Width;
        btnBuscar.Location = new Point(txtBuscar.Width,0);
        txtBuscar.Location = new Point(0,0);

        Button btnGuardar = new Button();
        btnGuardar.Location = new Point(0,290);
        btnGuardar.Text = "Guardar";
        btnGuardar.Font = new Font("",11,FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.BackColor = Color.Green;
        btnGuardar.Size = new Size(80,30);
        btnGuardar.Click += (s,e) =>
        {
            try
            {
                // connection = SqlConnect.miConexion();
                // connection.Open();

                // MySqlDataAdapter adapter = new MySqlDataAdapter();
                // DataTable dt = new DataTable();

                // adapter.SelectCommand?.Parameters.AddWithValue($"@buscar", "%hola%");
                // adapter.Fill(dt);

                // dtClientes.DataSource = dt;

                // connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        };

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

        datosCliente.Controls.AddRange(
            lblDatosCliente,
            lblIdCliente,
            txtIdCliente,
            lblNombreCliente,
            lblNombreAdv,
            txtNombreCliente,
            lblTelefono,
            lblTelefonoAdv,
            txtTelefono,
            lblCorreo,
            lblCorreoAdv,
            txtCorreo,
            lblDireccion,
            txtDireccion,
            btnGuardar,
            btnEditar,
            btnEliminar
        );
        mostrarDatosCliente.Controls.AddRange(
            dtClientes,
            txtBuscar,
            btnBuscar
        );
    }
}
