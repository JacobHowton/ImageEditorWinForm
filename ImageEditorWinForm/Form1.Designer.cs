namespace ImageEditorWinForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pbColorWheel = new System.Windows.Forms.PictureBox();
            this.btn_pen = new System.Windows.Forms.Button();
            this.btn_square = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_fill = new System.Windows.Forms.Button();
            this.tb_drawWidth = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txbx_saveLocation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorWheel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(18, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(681, 401);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(750, 53);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(776, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DrawSize";
            // 
            // pbColorWheel
            // 
            this.pbColorWheel.Image = ((System.Drawing.Image)(resources.GetObject("pbColorWheel.Image")));
            this.pbColorWheel.Location = new System.Drawing.Point(705, 250);
            this.pbColorWheel.Name = "pbColorWheel";
            this.pbColorWheel.Size = new System.Drawing.Size(196, 164);
            this.pbColorWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbColorWheel.TabIndex = 3;
            this.pbColorWheel.TabStop = false;
            this.pbColorWheel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbColorWheel_MouseClick);
            // 
            // btn_pen
            // 
            this.btn_pen.Location = new System.Drawing.Point(779, 108);
            this.btn_pen.Margin = new System.Windows.Forms.Padding(2);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(56, 19);
            this.btn_pen.TabIndex = 4;
            this.btn_pen.Text = "Pen";
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // btn_square
            // 
            this.btn_square.Location = new System.Drawing.Point(779, 132);
            this.btn_square.Margin = new System.Windows.Forms.Padding(2);
            this.btn_square.Name = "btn_square";
            this.btn_square.Size = new System.Drawing.Size(56, 19);
            this.btn_square.TabIndex = 5;
            this.btn_square.Text = "Square";
            this.btn_square.UseVisualStyleBackColor = true;
            this.btn_square.Click += new System.EventHandler(this.btn_square_Click);
            // 
            // btn_circle
            // 
            this.btn_circle.BackColor = System.Drawing.SystemColors.Control;
            this.btn_circle.Location = new System.Drawing.Point(779, 156);
            this.btn_circle.Margin = new System.Windows.Forms.Padding(2);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(56, 19);
            this.btn_circle.TabIndex = 6;
            this.btn_circle.Text = "Circle";
            this.btn_circle.UseVisualStyleBackColor = false;
            this.btn_circle.Click += new System.EventHandler(this.btn_circle_Click);
            // 
            // btn_fill
            // 
            this.btn_fill.BackColor = System.Drawing.SystemColors.Control;
            this.btn_fill.Location = new System.Drawing.Point(779, 179);
            this.btn_fill.Margin = new System.Windows.Forms.Padding(2);
            this.btn_fill.Name = "btn_fill";
            this.btn_fill.Size = new System.Drawing.Size(56, 19);
            this.btn_fill.TabIndex = 7;
            this.btn_fill.Text = "Fill";
            this.btn_fill.UseVisualStyleBackColor = false;
            this.btn_fill.Click += new System.EventHandler(this.btn_fill_Click);
            // 
            // tb_drawWidth
            // 
            this.tb_drawWidth.Location = new System.Drawing.Point(724, 53);
            this.tb_drawWidth.Name = "tb_drawWidth";
            this.tb_drawWidth.Size = new System.Drawing.Size(20, 20);
            this.tb_drawWidth.TabIndex = 8;
            this.tb_drawWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_drawWidth.TextChanged += new System.EventHandler(this.tb_drawWidth_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(770, 221);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 9;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txbx_saveLocation
            // 
            this.txbx_saveLocation.Location = new System.Drawing.Point(754, 199);
            this.txbx_saveLocation.Name = "txbx_saveLocation";
            this.txbx_saveLocation.Size = new System.Drawing.Size(100, 20);
            this.txbx_saveLocation.TabIndex = 10;
            this.txbx_saveLocation.Text = "image.jpg";
            this.txbx_saveLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 450);
            this.Controls.Add(this.txbx_saveLocation);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_drawWidth);
            this.Controls.Add(this.btn_fill);
            this.Controls.Add(this.btn_circle);
            this.Controls.Add(this.btn_square);
            this.Controls.Add(this.btn_pen);
            this.Controls.Add(this.pbColorWheel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Image Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorWheel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pbColorWheel;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.Button btn_square;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_fill;
        private System.Windows.Forms.TextBox tb_drawWidth;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txbx_saveLocation;
    }
}

