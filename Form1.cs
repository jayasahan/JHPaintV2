using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace JHPaint
{
    public partial class Form1 : Form
    {
        private enum Tool
        {
            Selector, Pen, Eraser, Rectangle, Circle, Triangle
        }

        private Tool _currentTool = Tool.Pen;
        private bool _isDrawing = false;
        private Point _startPoint;
        private List<Shape> _shapes = new List<Shape>();
        private Shape? _tempShape;
        private Shape? _selectedShape;
        private Stack<Shape> _redoStack = new Stack<Shape>();
        private Color _borderColor = Color.Black;
        private Color _fillColor = Color.DodgerBlue;
        private float _currentPenWidth = 2f;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
            SetupUI();
            WireUpEvents();
            // NEW: Set the initial tool to Pen visually
            UpdateToolSelection(penButton);
        }

        private void SetupForm()
        {
            this.Text = "JHPaint";
            this.DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, this.canvasPanel, new object[] { true });
        }

        private void SetupUI()
        {
            if (penWidthUpDown.Control is NumericUpDown nud)
            {
                nud.Value = (decimal)_currentPenWidth;
                nud.Minimum = 1;
                nud.Maximum = 50;
            }
            UpdateUndoRedoButtons();
        }

        private void WireUpEvents()
        {
            canvasPanel.MouseDown += canvasPanel_MouseDown;
            canvasPanel.MouseMove += canvasPanel_MouseMove;
            canvasPanel.MouseUp += canvasPanel_MouseUp;
            canvasPanel.Paint += canvasPanel_Paint;

            // NEW: All tool buttons now point to a single handler
            selectorButton.Click += ToolButton_Click;
            penButton.Click += ToolButton_Click;
            rectangleButton.Click += ToolButton_Click;
            circleButton.Click += ToolButton_Click;
            triangleButton.Click += ToolButton_Click;
            eraserButton.Click += ToolButton_Click;

            borderColorButton.Click += borderColorButton_Click;
            fillColorButton.Click += fillColorButton_Click;
            if (penWidthUpDown.Control is NumericUpDown nud)
            {
                nud.ValueChanged += penWidthUpDown_ValueChanged;
            }
            undoButton.Click += undoButton_Click;
            redoButton.Click += redoButton_Click;
            saveButton.Click += saveButton_Click;
        }

        // NEW: A single event handler to manage tool selection UI
        private void ToolButton_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripButton clickedButton)
            {
                UpdateToolSelection(clickedButton);
            }
        }

        // NEW: This method handles the logic for changing tools
        private void UpdateToolSelection(ToolStripButton selectedButton)
        {
            // Uncheck all tool buttons
            selectorButton.Checked = false;
            penButton.Checked = false;
            rectangleButton.Checked = false;
            circleButton.Checked = false;
            triangleButton.Checked = false;
            eraserButton.Checked = false;

            // Check the selected one
            selectedButton.Checked = true;

            // Update the current tool state and cursor
            if (selectedButton == selectorButton)
            {
                _currentTool = Tool.Selector;
                canvasPanel.Cursor = Cursors.Default;
            }
            else if (selectedButton == penButton)
            {
                _currentTool = Tool.Pen;
                canvasPanel.Cursor = Cursors.Cross;
            }
            else if (selectedButton == rectangleButton)
            {
                _currentTool = Tool.Rectangle;
                canvasPanel.Cursor = Cursors.Cross;
            }
            else if (selectedButton == circleButton)
            {
                _currentTool = Tool.Circle;
                canvasPanel.Cursor = Cursors.Cross;
            }
            else if (selectedButton == triangleButton)
            {
                _currentTool = Tool.Triangle;
                canvasPanel.Cursor = Cursors.Cross;
            }
            else if (selectedButton == eraserButton)
            {
                _currentTool = Tool.Eraser;
                canvasPanel.Cursor = Cursors.Cross; // Could use a custom eraser cursor here too
            }
        }


        // --- Event Handlers (MouseDown, MouseMove, etc. remain the same) ---
        // (No changes needed in the drawing logic below this point)

        private void canvasPanel_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            _startPoint = e.Location;
            _isDrawing = true;

            if (_currentTool == Tool.Selector)
            {
                _selectedShape = _shapes.LastOrDefault(shape => shape.Contains(e.Location));
                canvasPanel.Invalidate();
                return;
            }

            _selectedShape = null;
            Color penColor = (_currentTool == Tool.Eraser) ? canvasPanel.BackColor : _borderColor;
            float penWidth = (_currentTool == Tool.Eraser) ? 20f : _currentPenWidth;
            Color fillColor = (_currentTool == Tool.Eraser) ? canvasPanel.BackColor : _fillColor;

            switch (_currentTool)
            {
                case Tool.Pen:
                case Tool.Eraser:
                    _tempShape = new PenStroke(_startPoint, penColor, penWidth);
                    _shapes.Add(_tempShape);
                    break;
                case Tool.Rectangle:
                    _tempShape = new RectangleShape(_startPoint, fillColor, penColor, penWidth);
                    break;
                case Tool.Circle:
                    _tempShape = new EllipseShape(_startPoint, fillColor, penColor, penWidth);
                    break;
                case Tool.Triangle:
                    _tempShape = new TriangleShape(_startPoint, fillColor, penColor, penWidth);
                    break;
            }
        }

        private void canvasPanel_MouseMove(object? sender, MouseEventArgs e)
        {
            if (cursorLocationLabel != null)
            {
                cursorLocationLabel.Text = $"X: {e.X}, Y: {e.Y}";
            }

            if (!_isDrawing || _tempShape == null) return;

            if (_tempShape is PenStroke stroke)
            {
                stroke.AddPoint(e.Location);
            }
            else
            {
                _tempShape.EndPoint = e.Location;
            }
            canvasPanel.Invalidate();
        }

        private void canvasPanel_MouseUp(object? sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _isDrawing = false;
                if (_tempShape != null && !(_tempShape is PenStroke))
                {
                    _tempShape.EndPoint = e.Location;
                    _shapes.Add(_tempShape);
                }

                if (_tempShape != null)
                {
                    _redoStack.Clear();
                }

                _tempShape = null;
                UpdateUndoRedoButtons();
                canvasPanel.Invalidate();
            }
        }

        private void canvasPanel_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var shape in _shapes)
            {
                shape.Draw(e.Graphics);
            }

            if (_isDrawing && _tempShape != null && !(_tempShape is PenStroke))
            {
                _tempShape.Draw(e.Graphics);
            }

            if (_selectedShape != null)
            {
                using (Pen highlightPen = new Pen(Color.Cyan, 2))
                {
                    highlightPen.DashStyle = DashStyle.Dash;
                    Rectangle inflatedRect = _selectedShape.Bounds;
                    inflatedRect.Inflate(5, 5);
                    e.Graphics.DrawRectangle(highlightPen, inflatedRect);
                }
            }
        }

        private void borderColorButton_Click(object? sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _borderColor = colorDialog1.Color;
                borderColorButton.BackColor = _borderColor;
                borderColorButton.ForeColor = (_borderColor.GetBrightness() < 0.5) ? Color.White : Color.Black; // NEW: Make text readable

                if (_selectedShape != null)
                {
                    _selectedShape.BorderColor = _borderColor;
                    canvasPanel.Invalidate();
                }
            }
        }

        private void fillColorButton_Click(object? sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _fillColor = colorDialog1.Color;
                fillColorButton.BackColor = _fillColor;
                fillColorButton.ForeColor = (_fillColor.GetBrightness() < 0.5) ? Color.White : Color.Black; // NEW: Make text readable

                if (_selectedShape != null)
                {
                    _selectedShape.FillColor = _fillColor;
                    canvasPanel.Invalidate();
                }
            }
        }

        private void penWidthUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (sender is NumericUpDown nud)
            {
                _currentPenWidth = (float)nud.Value;
                if (_selectedShape != null)
                {
                    _selectedShape.BorderWidth = _currentPenWidth;
                    canvasPanel.Invalidate();
                }
            }
        }

        private void undoButton_Click(object? sender, EventArgs e)
        {
            if (_shapes.Count > 0)
            {
                Shape lastShape = _shapes.Last();
                _shapes.Remove(lastShape);
                _redoStack.Push(lastShape);
                _selectedShape = null;
                UpdateUndoRedoButtons();
                canvasPanel.Invalidate();
            }
        }

        private void redoButton_Click(object? sender, EventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                Shape shapeToRedo = _redoStack.Pop();
                _shapes.Add(shapeToRedo);
                UpdateUndoRedoButtons();
                canvasPanel.Invalidate();
            }
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "Save an Image File";
                sfd.FileName = "MyDrawing.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(canvasPanel.Width, canvasPanel.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(canvasPanel.BackColor);
                            g.SmoothingMode = SmoothingMode.AntiAlias;
                            foreach (var shape in _shapes)
                            {
                                shape.Draw(g);
                            }
                        }
                        ImageFormat format = ImageFormat.Png;
                        if (sfd.FilterIndex == 2) format = ImageFormat.Jpeg;
                        else if (sfd.FilterIndex == 3) format = ImageFormat.Bmp;
                        bmp.Save(sfd.FileName, format);
                    }
                }
            }
        }

        private void UpdateUndoRedoButtons()
        {
            undoButton.Enabled = _shapes.Count > 0;
            redoButton.Enabled = _redoStack.Count > 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}