using System.Drawing.Text;

namespace Proyecto_menustrip;

public partial class Form1 : Form
{
    Panel mainPanel;
    public Form1()
    {
        InitializeComponent();
        MenuStrip menuStrip = new MenuStrip();
        Controls.Add(menuStrip);

        mainPanel = new Panel();
        mainPanel.Dock = DockStyle.Fill;

        ToolStripMenuItem inicio = new ToolStripMenuItem("Inicio");
        // inicio.BackColor = Color.Red;
        ToolStripMenuItem clientes = new ToolStripMenuItem("Clientes");
        ToolStripMenuItem productos = new ToolStripMenuItem("Productos");
        ToolStripMenuItem empleados = new ToolStripMenuItem("Empleados");

        menuStrip.Items.AddRange(inicio,clientes,productos,empleados);
        clientes.Click += PutaFuncion;

    }
    private Form? formularioActivo = null;
    private void PutaFuncion(object? sender, EventArgs e)
    {
        AbriFormulario(new FrmClientes());
    }
    private void AbriFormulario(Form form)
    {
        if(formularioActivo != null)
        formularioActivo.Close();

        formularioActivo = form;
        form.TopLevel = false;

        mainPanel.Controls.Clear();
        mainPanel.Controls.Add(form);

        form.Show();
    }
}
