using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace Proyecto_menustrip;

public partial class FrmClientes : Form
{
    private bool nombreValido = false, telefonoValido = false;
    private MySqlConnection? connection;
    private DataGridView dtClientes;
    private TextBox txtIdCliente, txtNombreCliente, txtTelefono, txtCorreo, txtDireccion;
    public FrmClientes()
    {
        // CargarClientes();
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

        txtIdCliente = new TextBox();
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

        txtNombreCliente = new TextBox();
        txtNombreCliente.Width = txtBoxWidth;
        txtNombreCliente.Location = new Point(0,100);
        txtNombreCliente.TextChanged += (s,e) =>
        {
            string nombre = txtNombreCliente.Text.Trim();
            if(nombre.Length == 0)
            {
                lblNombreAdv.Text = "Obligatorio";
                nombreValido = false;
            }
            else if(nombre.Length < 3)
            {
                lblNombreAdv.Text = "Debe contener almenos 3 caracteres";
                nombreValido = false;
            }
            else
            {
                lblNombreAdv.Text = string.Empty;
                nombreValido = true;
            }
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

        txtTelefono = new TextBox();
        txtTelefono.Width = txtBoxWidth;
        txtTelefono.Location = new Point(0,150);
        txtTelefono.TextChanged += (s,e) =>
        {
            if(txtTelefono.Text.Any(c => !char.IsDigit(c)))
            {
                lblTelefonoAdv.Text = "Solo se permiten numeros (0-9)";
                telefonoValido = false;
            }
            else if(txtTelefono.TextLength != 8)
            {
                lblTelefonoAdv.Text = "(Formato: xxxxxxxx)";
                telefonoValido = false;
            }
            else
            {
                lblTelefonoAdv.Text = string.Empty;
                telefonoValido = true;
            }
        };

        Label lblCorreo = new Label();
        lblCorreo.AutoSize = true;
        lblCorreo.Text = "Correo electronico";
        lblCorreo.Location = new Point(0,180);
        Label lblCorreoAdv = new Label();
        lblCorreoAdv.AutoSize = true;
        lblCorreoAdv.Text = "(Formato: usuario@dominio.com)";
        lblCorreoAdv.ForeColor = Color.Red;
        lblCorreoAdv.Location = new Point(lblCorreo.Location.X+lblCorreo.PreferredWidth,lblCorreo.Location.Y);

        txtCorreo = new TextBox();
        txtCorreo.Width = txtBoxWidth;
        txtCorreo.Location = new Point(0,200);

        Label lblDireccion = new Label();
        lblDireccion.AutoSize = true;
        lblDireccion.Text = "Direccion";
        lblDireccion.Location = new Point(0,230);

        txtDireccion = new TextBox();
        txtDireccion.Width = txtBoxWidth;
        txtDireccion.Location = new Point(0,250);

        dtClientes = new DataGridView();
        dtClientes.Size = new Size(400,300);
        dtClientes.Location = new Point(0,30);
        dtClientes.DoubleClick += (s,e) =>
		{
			try
			{
        		txtIdCliente?.Text = dtClientes.CurrentRow?.Cells["id"].Value?.ToString();
        		txtNombreCliente?.Text = dtClientes.CurrentRow?.Cells["nombre"].Value?.ToString();
        		txtTelefono?.Text = dtClientes.CurrentRow?.Cells["telefono"].Value?.ToString();
        		txtCorreo?.Text = dtClientes.CurrentRow?.Cells["correo"].Value?.ToString();
        		txtDireccion?.Text = dtClientes.CurrentRow?.Cells["direccion"].Value?.ToString();
			}
			catch
			{
				txtIdCliente.Clear();
                txtNombreCliente.Clear();
                txtTelefono.Clear();
                txtCorreo.Clear();
                txtDireccion.Clear();
			}
        };
        Button btnBuscar = new Button();
        btnBuscar.AutoSize = true;
        btnBuscar.Text = "Buscar";
        btnBuscar.Click += (s,e) => CargarClientes();

        TextBox txtBuscar = new TextBox();
        txtBuscar.Width = dtClientes.Width-btnBuscar.PreferredSize.Width;
        btnBuscar.Location = new Point(txtBuscar.Width,0);
        txtBuscar.Location = new Point(0,0);
        txtBuscar.TextChanged += (s,e) => CargarClientes(txtBuscar.Text);

        Button btnGuardar = new Button();
        btnGuardar.Location = new Point(0,290);
        btnGuardar.Text = "Guardar";
        btnGuardar.Font = new Font("",11,FontStyle.Bold);
        btnGuardar.ForeColor = Color.White;
        btnGuardar.BackColor = Color.Green;
        btnGuardar.Size = new Size(80,30);
        btnGuardar.Click += (s,e) => GuardarDatos();

        Button btnEditar = new Button();
        btnEditar.Location = new Point(85,290);
        btnEditar.Text = "Editar";
        btnEditar.Font = new Font("",11,FontStyle.Bold);
        btnEditar.ForeColor = Color.White;
        btnEditar.BackColor = Color.Orange;
        btnEditar.Size = new Size(80,30);
        btnEditar.Click += (s,e) => ModificarDatos();  

        Button btnEliminar = new Button();
        btnEliminar.Location = new Point(170,290);
        btnEliminar.Text = "Eliminar";
        btnEliminar.Font = new Font("",11,FontStyle.Bold);
        btnEliminar.ForeColor = Color.White;
        btnEliminar.BackColor = Color.Red;
        btnEliminar.Size = new Size(80,30);
        btnEliminar.Click += (s,e) => EliminarDatos();

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

        CargarClientes();
        renombrarHeader("id","ID");
        renombrarHeader("nombre","Nombre");
        renombrarHeader("telefono","Numero Telefonico");
        renombrarHeader("correo","Correo Electronico");
        renombrarHeader("direccion","Direccion");
    }
    private void CargarClientes(string buscar = "")
    {
        try
        {
            using(MySqlConnection conexion = SqlConnect.MiConexion())
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM clientes WHERE nombre LIKE @buscar",
                    conexion
                );

                cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");

                MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adaptador.Fill(dt);

                dtClientes.DataSource = dt;
            }
        }   
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message,"Error");
        }
    }
    private void GuardarDatos()
    {
        try
        {
            if(nombreValido && telefonoValido)
            using(MySqlConnection conexion = SqlConnect.MiConexion())
            {
                conexion.Open();

                string consulta = " INSERT INTO clientes(nombre, telefono, correo, direccion)" + 
                    "VALUES(@nombre, @telefono, @correo, @direccion)";
                using(MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre",txtNombreCliente.Text);
                    cmd.Parameters.AddWithValue("@telefono",txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@correo",txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@direccion",txtDireccion.Text);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente guardado exitosamente");
                        txtNombreCliente.Clear();
                        txtCorreo.Clear();
                        txtTelefono.Clear();
                        txtDireccion.Clear();
                        CargarClientes();
                    }
                }
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message,"Error");
        }
    }
    private void renombrarHeader(string nombreOriginal, string nombreNuevo)
    {
        if (dtClientes.Columns.Contains(nombreOriginal))
        	dtClientes.Columns[nombreOriginal]?.HeaderText = nombreNuevo;
    }
    private void EliminarDatos()
    {
        int idSeleccion = Convert.ToInt32(dtClientes.CurrentRow?.Cells["id"].Value);
        string? nmbSeleccion = Convert.ToString(dtClientes.CurrentRow?.Cells["nombre"].Value);

        using(MySqlConnection conexion = SqlConnect.MiConexion())
        {
            conexion.Open();
            if(MessageBox.Show($"Desea eliminar: \"{nmbSeleccion}\"?", "ELiminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand
                (
                    "DELETE FROM clientes WHERE id = @id",
                    conexion
                );
                cmd.Parameters.AddWithValue("@id", idSeleccion);
                cmd.ExecuteNonQuery();
            }
        }
    }
    private void ModificarDatos()
    {
        string? nmbSeleccion = Convert.ToString(dtClientes.CurrentRow?.Cells["nombre"].Value);
        
        if(nombreValido && telefonoValido)
        using(MySqlConnection conexion = SqlConnect.MiConexion())
        {
            conexion.Open();
            if(MessageBox.Show($"Desea modificar: \"{nmbSeleccion}\"?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand
                (
                    "UPDATE clientes SET nombre=@n, telefono=@t, correo=@c, direccion=@d WHERE id=@id",
                    conexion
                );
                cmd.Parameters.AddWithValue("@n", txtNombreCliente.Text);
                cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@c", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@d", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@id", txtIdCliente.Text);
                cmd.ExecuteNonQuery();
            }
            CargarClientes();
        }
    }
    // private void Buscar(string buscar = "")
    // {
    //     try
    //     {
    //         using(MySqlConnection conexion = SqlConnect.MiConexion())
    //         {
    //             conexion.Open();

    //             MySqlCommand cmd = new MySqlCommand(
    //                 "SELECT * FROM clientes WHERE nombre LIKE @buscar",
    //                 conexion
    //             );

    //             cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");

    //             MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);

    //             DataTable dt = new DataTable();

    //             adaptador.Fill(dt);

    //             dtClientes.DataSource = dt;
    //         }
    //     }   
    //     catch(Exception ex)
    //     {
    //         MessageBox.Show(ex.Message,"Error");
    //     }
    // }
}