namespace PretvornikEnacb;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        ConvertEquation = new Button();
        InsertKey = new Button();
        SuspendLayout();
        // 
        // ConvertEquation
        // 
        ConvertEquation.BackColor = SystemColors.ControlDark;
        ConvertEquation.Cursor = Cursors.Hand;
        ConvertEquation.Enabled = false;
        ConvertEquation.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
        ConvertEquation.Location = new Point(12, 12);
        ConvertEquation.Name = "ConvertEquation";
        ConvertEquation.Size = new Size(360, 120);
        ConvertEquation.TabIndex = 0;
        ConvertEquation.Text = "Pretvori Enačbe";
        ConvertEquation.UseVisualStyleBackColor = false;
        ConvertEquation.Click += ConvertEquation_Click;
        // 
        // InsertKey
        // 
        InsertKey.BackColor = SystemColors.ControlDark;
        InsertKey.Cursor = Cursors.Hand;
        InsertKey.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold);
        InsertKey.Location = new Point(12, 138);
        InsertKey.Name = "InsertKey";
        InsertKey.Size = new Size(360, 120);
        InsertKey.TabIndex = 1;
        InsertKey.Text = "Vnesi Ključ";
        InsertKey.UseVisualStyleBackColor = false;
        InsertKey.Click += InsertKey_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(11F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 271);
        Controls.Add(InsertKey);
        Controls.Add(ConvertEquation);
        Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(5);
        MaximizeBox = false;
        Name = "MainWindow";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Pretvornik Enačb";
        ResumeLayout(false);
    }

    #endregion

    private Button ConvertEquation;
    private Button InsertKey;
}
