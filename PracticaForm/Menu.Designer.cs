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
            cursoCToolStripMenuItem = new ToolStripMenuItem();
            cursoCToolStripMenuItem1 = new ToolStripMenuItem();
            cursoJavascriptToolStripMenuItem = new ToolStripMenuItem();
            serializaciónJsonToolStripMenuItem = new ToolStripMenuItem();
            cursoCToolStripMenuItem2 = new ToolStripMenuItem();
            cursoCToolStripMenuItem3 = new ToolStripMenuItem();
            cursoJavascriptToolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, exportacionesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoRegistroToolStripMenuItem, modificarEliminarRegistroToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevoRegistroToolStripMenuItem
            // 
            nuevoRegistroToolStripMenuItem.Name = "nuevoRegistroToolStripMenuItem";
            nuevoRegistroToolStripMenuItem.Size = new Size(222, 22);
            nuevoRegistroToolStripMenuItem.Text = "Nuevo registro";
            nuevoRegistroToolStripMenuItem.Click += nuevoRegistroToolStripMenuItem_Click;
            // 
            // modificarEliminarRegistroToolStripMenuItem
            // 
            modificarEliminarRegistroToolStripMenuItem.Name = "modificarEliminarRegistroToolStripMenuItem";
            modificarEliminarRegistroToolStripMenuItem.Size = new Size(222, 22);
            modificarEliminarRegistroToolStripMenuItem.Text = "Modificar / Eliminar registro";
            // 
            // exportacionesToolStripMenuItem
            // 
            exportacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { serializaciónXMLToolStripMenuItem, serializaciónJsonToolStripMenuItem });
            exportacionesToolStripMenuItem.Name = "exportacionesToolStripMenuItem";
            exportacionesToolStripMenuItem.Size = new Size(93, 20);
            exportacionesToolStripMenuItem.Text = "Exportaciones";
            // 
            // serializaciónXMLToolStripMenuItem
            // 
            serializaciónXMLToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cursoCToolStripMenuItem, cursoCToolStripMenuItem1, cursoJavascriptToolStripMenuItem });
            serializaciónXMLToolStripMenuItem.Name = "serializaciónXMLToolStripMenuItem";
            serializaciónXMLToolStripMenuItem.Size = new Size(180, 22);
            serializaciónXMLToolStripMenuItem.Text = "Serialización XML";
            // 
            // cursoCToolStripMenuItem
            // 
            cursoCToolStripMenuItem.Name = "cursoCToolStripMenuItem";
            cursoCToolStripMenuItem.Size = new Size(180, 22);
            cursoCToolStripMenuItem.Text = "Curso C#";
            cursoCToolStripMenuItem.Click += cursoCToolStripMenuItem_Click;
            // 
            // cursoCToolStripMenuItem1
            // 
            cursoCToolStripMenuItem1.Name = "cursoCToolStripMenuItem1";
            cursoCToolStripMenuItem1.Size = new Size(180, 22);
            cursoCToolStripMenuItem1.Text = "Curso C++";
            cursoCToolStripMenuItem1.Click += cursoCToolStripMenuItem1_Click;
            // 
            // cursoJavascriptToolStripMenuItem
            // 
            cursoJavascriptToolStripMenuItem.Name = "cursoJavascriptToolStripMenuItem";
            cursoJavascriptToolStripMenuItem.Size = new Size(180, 22);
            cursoJavascriptToolStripMenuItem.Text = "Curso Javascript";
            cursoJavascriptToolStripMenuItem.Click += cursoJavascriptToolStripMenuItem_Click;
            // 
            // serializaciónJsonToolStripMenuItem
            // 
            serializaciónJsonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cursoCToolStripMenuItem2, cursoCToolStripMenuItem3, cursoJavascriptToolStripMenuItem1 });
            serializaciónJsonToolStripMenuItem.Name = "serializaciónJsonToolStripMenuItem";
            serializaciónJsonToolStripMenuItem.Size = new Size(180, 22);
            serializaciónJsonToolStripMenuItem.Text = "Serialización Json";
            // 
            // cursoCToolStripMenuItem2
            // 
            cursoCToolStripMenuItem2.Name = "cursoCToolStripMenuItem2";
            cursoCToolStripMenuItem2.Size = new Size(180, 22);
            cursoCToolStripMenuItem2.Text = "Curso C#";
            cursoCToolStripMenuItem2.Click += cursoCToolStripMenuItem2_Click;
            // 
            // cursoCToolStripMenuItem3
            // 
            cursoCToolStripMenuItem3.Name = "cursoCToolStripMenuItem3";
            cursoCToolStripMenuItem3.Size = new Size(180, 22);
            cursoCToolStripMenuItem3.Text = "Curso C++";
            cursoCToolStripMenuItem3.Click += cursoCToolStripMenuItem3_Click;
            // 
            // cursoJavascriptToolStripMenuItem1
            // 
            cursoJavascriptToolStripMenuItem1.Name = "cursoJavascriptToolStripMenuItem1";
            cursoJavascriptToolStripMenuItem1.Size = new Size(180, 22);
            cursoJavascriptToolStripMenuItem1.Text = "Curso Javascript";
            cursoJavascriptToolStripMenuItem1.Click += cursoJavascriptToolStripMenuItem1_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
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
        private ToolStripMenuItem cursoCToolStripMenuItem;
        private ToolStripMenuItem cursoCToolStripMenuItem1;
        private ToolStripMenuItem cursoJavascriptToolStripMenuItem;
        private ToolStripMenuItem cursoCToolStripMenuItem2;
        private ToolStripMenuItem cursoCToolStripMenuItem3;
        private ToolStripMenuItem cursoJavascriptToolStripMenuItem1;
    }
}