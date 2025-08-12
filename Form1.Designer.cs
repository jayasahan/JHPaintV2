namespace JHPaint
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cursorLocationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.springLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.authorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectorButton = new System.Windows.Forms.ToolStripButton();
            this.penButton = new System.Windows.Forms.ToolStripButton();
            this.rectangleButton = new System.Windows.Forms.ToolStripButton();
            this.circleButton = new System.Windows.Forms.ToolStripButton();
            this.triangleButton = new System.Windows.Forms.ToolStripButton();
            this.eraserButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.borderColorButton = new System.Windows.Forms.ToolStripButton();
            this.fillColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.penWidthUpDown = new System.Windows.Forms.ToolStripControlHost(new System.Windows.Forms.NumericUpDown());
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.canvasPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthUpDown.Control)).BeginInit();
            this.SuspendLayout();
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Controls.Add(this.statusStrip1);
            this.canvasPanel.Controls.Add(this.toolStrip1);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 0);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(982, 553);
            this.canvasPanel.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cursorLocationLabel,
            this.springLabel,
            this.authorLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cursorLocationLabel
            // 
            this.cursorLocationLabel.Name = "cursorLocationLabel";
            this.cursorLocationLabel.Size = new System.Drawing.Size(58, 17);
            this.cursorLocationLabel.Text = "X: 0, Y: 0";
            // 
            // springLabel
            // 
            this.springLabel.Name = "springLabel";
            this.springLabel.Size = new System.Drawing.Size(748, 17);
            this.springLabel.Spring = true;
            // 
            // authorLabel
            // 
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(161, 17);
            this.authorLabel.Text = "Jayasahan Hansana (EG235624)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectorButton,
            this.penButton,
            this.rectangleButton,
            this.circleButton,
            this.triangleButton,
            this.eraserButton,
            this.toolStripSeparator1,
            this.borderColorButton,
            this.fillColorButton,
            this.toolStripLabel1,
            this.penWidthUpDown,
            this.toolStripSeparator2,
            this.undoButton,
            this.redoButton,
            this.toolStripSeparator3,
            this.saveButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(982, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectorButton
            // 
            this.selectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectorButton.Image = global::JHPaint.Properties.Resources.selector;
            this.selectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectorButton.Name = "selectorButton";
            this.selectorButton.Size = new System.Drawing.Size(36, 36);
            this.selectorButton.Text = "Selector";
            this.selectorButton.ToolTipText = "Select Shape";
            // 
            // penButton
            // 
            this.penButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penButton.Image = global::JHPaint.Properties.Resources.pencil;
            this.penButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penButton.Name = "penButton";
            this.penButton.Size = new System.Drawing.Size(36, 36);
            this.penButton.Text = "Pen";
            this.penButton.ToolTipText = "Pen Tool";
            // 
            // rectangleButton
            // 
            this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleButton.Image = global::JHPaint.Properties.Resources.rectangle;
            this.rectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(36, 36);
            this.rectangleButton.Text = "Rectangle";
            this.rectangleButton.ToolTipText = "Draw Rectangle";
            // 
            // circleButton
            // 
            this.circleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.circleButton.Image = global::JHPaint.Properties.Resources.circle;
            this.circleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(36, 36);
            this.circleButton.Text = "Circle";
            this.circleButton.ToolTipText = "Draw Circle";
            // 
            // triangleButton
            // 
            this.triangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.triangleButton.Image = global::JHPaint.Properties.Resources.triangle;
            this.triangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(36, 36);
            this.triangleButton.Text = "Triangle";
            this.triangleButton.ToolTipText = "Draw Triangle";
            // 
            // eraserButton
            // 
            this.eraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.eraserButton.Image = global::JHPaint.Properties.Resources.eraser;
            this.eraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.eraserButton.Name = "eraserButton";
            this.eraserButton.Size = new System.Drawing.Size(36, 36);
            this.eraserButton.Text = "Eraser";
            this.eraserButton.ToolTipText = "Eraser Tool";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // borderColorButton
            // 
            this.borderColorButton.BackColor = System.Drawing.Color.Black;
            this.borderColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.borderColorButton.ForeColor = System.Drawing.Color.White;
            this.borderColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(79, 36);
            this.borderColorButton.Text = "Border Color";
            // 
            // fillColorButton
            // 
            this.fillColorButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.fillColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(59, 36);
            this.fillColorButton.Text = "Fill Color";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 36);
            this.toolStripLabel1.Text = "Width:";
            // 
            // penWidthUpDown
            // 
            this.penWidthUpDown.Name = "penWidthUpDown";
            this.penWidthUpDown.Size = new System.Drawing.Size(120, 24);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Enabled = false;
            this.undoButton.Image = global::JHPaint.Properties.Resources.undo;
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 36);
            this.undoButton.Text = "Undo";
            this.undoButton.ToolTipText = "Undo Last Action";
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Enabled = false;
            this.redoButton.Image = global::JHPaint.Properties.Resources.redo;
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 36);
            this.redoButton.Text = "Redo";
            this.redoButton.ToolTipText = "Redo Last Action";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = global::JHPaint.Properties.Resources.save;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(36, 36);
            this.saveButton.Text = "Save";
            this.saveButton.ToolTipText = "Save Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.canvasPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.canvasPanel.ResumeLayout(false);
            this.canvasPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.penWidthUpDown.Control)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel cursorLocationLabel;
        private System.Windows.Forms.ToolStripButton penButton;
        private System.Windows.Forms.ToolStripButton circleButton;
        private System.Windows.Forms.ToolStripButton rectangleButton;
        private System.Windows.Forms.ToolStripButton eraserButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton selectorButton;
        private System.Windows.Forms.ToolStripButton triangleButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton borderColorButton;
        private System.Windows.Forms.ToolStripButton fillColorButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripControlHost penWidthUpDown;
        private System.Windows.Forms.ToolStripStatusLabel springLabel;
        private System.Windows.Forms.ToolStripStatusLabel authorLabel;
    }
}