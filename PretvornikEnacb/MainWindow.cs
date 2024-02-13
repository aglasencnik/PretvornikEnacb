using Microsoft.VisualBasic;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Licensing;
using System.Text.RegularExpressions;

namespace PretvornikEnacb;

/// <summary>
/// Main window of the application.
/// </summary>
public partial class MainWindow : Form
{
    private string _apiKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        _apiKey = RegistryUtil.RetrieveApiKey();
        if (!string.IsNullOrWhiteSpace(_apiKey))
            ConvertEquation.Enabled = true;
    }

    /// <summary>
    /// Inserts the API Key.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">EventArgs object.</param>
    private void InsertKey_Click(object sender, EventArgs e)
    {
        try
        {
            _apiKey = Interaction.InputBox("Vnesite API kljuè", DefaultResponse: _apiKey) ?? string.Empty;
            RegistryUtil.StoreApiKey(_apiKey);

            if (string.IsNullOrWhiteSpace(_apiKey))
                ConvertEquation.Enabled = false;
            else
                ConvertEquation.Enabled = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Converts the Equations.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">EventArgs object.</param>
    private void ConvertEquation_Click(object sender, EventArgs e)
    {
        try
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Word Datoteka|*.docx",
                Title = "Izberite datoteke z enaèbami",
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            if (ofd.FileNames.Length == 0)
                return;

            SyncfusionLicenseProvider.RegisterLicense(_apiKey);

            foreach (var fileName in ofd.FileNames)
            {
                var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                var document = new WordDocument(fileStream, FormatType.Docx);

                var equationSelections = document.FindAll(new Regex(@"\$.*?\$"));
                foreach (var selection in equationSelections ?? Array.Empty<TextSelection>())
                {
                    var textRange = selection.GetAsOneRange();
                    var equation = textRange.Text.Replace("$", string.Empty).Trim();
                    textRange.Text = string.Empty;
                    textRange.OwnerParagraph.AppendMath(equation);
                }

                var stream = new FileStream(fileName.Replace(".docx", "-pretvorjeno.docx"), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                document.Save(stream, FormatType.Docx);
                document.Close();
                stream.Close();
                fileStream.Close();
            }

            MessageBox.Show("Enaèbe so bile uspešno pretvorjene.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Napaka", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
