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
        Controls.Add(mainPanel);

        ToolStripMenuItem inicio = new ToolStripMenuItem("Inicio");
        ToolStripMenuItem clientes = new ToolStripMenuItem("Clientes");
        clientes.Click += (s,e) => 
        {
            AbriFormulario(new FrmClientes());
        };
        ToolStripMenuItem productos = new ToolStripMenuItem("Productos");
        ToolStripMenuItem empleados = new ToolStripMenuItem("Empleados");

        menuStrip.Items.AddRange(inicio,clientes,productos,empleados);

    }
    private Form? formularioActivo = null;
    private void AbriFormulario(Form form)
    {
        if(formularioActivo != null)
        formularioActivo.Close();

        formularioActivo = form;
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;

        mainPanel.Controls.Clear();
        mainPanel.Controls.Add(form);

        form.Show();
    }
}
