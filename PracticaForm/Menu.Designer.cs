namespace PracticaForm
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            nuevoRegistroToolStripMenuItem = new ToolStripMenuItem();
            modificarEliminarRegistroToolStripMenuItem = new ToolStripMenuItem();
            exportacionesToolStripMenuItem = new ToolStripMenuItem();
            serializaciónXMLToolStripMenuItem = new ToolStripMenuItem();
            serializaciónJsonToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, exportacionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoRegistroToolStripMenuItem, modificarEliminarRegistroToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(59, 24);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevoRegistroToolStripMenuItem
            // 
            nuevoRegistroToolStripMenuItem.Name = "nuevoRegistroToolStripMenuItem";
            nuevoRegistroToolStripMenuItem.Size = new Size(279, 26);
            nuevoRegistroToolStripMenuItem.Text = "Nuevo registro";
            nuevoRegistroToolStripMenuItem.Click += nuevoRegistroToolStripMenuItem_Click;
            // 
            // modificarEliminarRegistroToolStripMenuItem
            // 
            modificarEliminarRegistroToolStripMenuItem.Name = "modificarEliminarRegistroToolStripMenuItem";
            modificarEliminarRegistroToolStripMenuItem.Size = new Size(279, 26);
            modificarEliminarRegistroToolStripMenuItem.Text = "Modificar / Eliminar registro";
            // 
            // exportacionesToolStripMenuItem
            // 
            exportacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { serializaciónXMLToolStripMenuItem, serializaciónJsonToolStripMenuItem });
            exportacionesToolStripMenuItem.Name = "exportacionesToolStripMenuItem";
            exportacionesToolStripMenuItem.Size = new Size(116, 24);
            exportacionesToolStripMenuItem.Text = "Exportaciones";
            // 
            // serializaciónXMLToolStripMenuItem
            // 
            serializaciónXMLToolStripMenuItem.Name = "serializaciónXMLToolStripMenuItem";
            serializaciónXMLToolStripMenuItem.Size = new Size(209, 26);
            serializaciónXMLToolStripMenuItem.Text = "Serialización XML";
            // 
            // serializaciónJsonToolStripMenuItem
            // 
            serializaciónJsonToolStripMenuItem.Name = "serializaciónJsonToolStripMenuItem";
            serializaciónJsonToolStripMenuItem.Size = new Size(209, 26);
            serializaciónJsonToolStripMenuItem.Text = "Serialización Json";
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Inicio";
            Text = "Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem nuevoRegistroToolStripMenuItem;
        private ToolStripMenuItem modificarEliminarRegistroToolStripMenuItem;
        private ToolStripMenuItem exportacionesToolStripMenuItem;
        private ToolStripMenuItem serializaciónXMLToolStripMenuItem;
        private ToolStripMenuItem serializaciónJsonToolStripMenuItem;
    }
}