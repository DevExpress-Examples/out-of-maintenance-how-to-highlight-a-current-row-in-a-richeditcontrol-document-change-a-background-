using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Commands;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            richEditControl1.LoadDocument(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WpfApplication1.Documents.testDocument.docx"), DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
            lineRange = richEditControl1.Document.CreateRange(0, 1);
        }

        DocumentRange lineRange = null;
        bool isSelectionLocked = false;
        private void richEditControl1_SelectionChanged(object sender, EventArgs e) {
            if(isSelectionLocked) return;
            if(!lineRange.Contains(richEditControl1.Document.CaretPosition)) {
                SetLineRangeFormatting(lineRange, System.Drawing.Color.Transparent);
                lineRange = GetNewLineRange(richEditControl1.Document.CaretPosition);
                SetLineRangeFormatting(lineRange, System.Drawing.Color.LightGray);
            }            
        }

        void SetLineRangeFormatting(DocumentRange currentLineRange, System.Drawing.Color rangeColor) {
            CharacterProperties cp = richEditControl1.Document.BeginUpdateCharacters(currentLineRange);
            cp.BackColor = rangeColor;
            richEditControl1.Document.EndUpdateCharacters(cp);        
        }

        DocumentRange GetNewLineRange(DocumentPosition caret) {
            isSelectionLocked = true;
            DocumentPosition currentPosition = richEditControl1.Document.CaretPosition;

            StartOfLineCommand startOfLineCommand = new StartOfLineCommand(richEditControl1);
            EndOfLineCommand endOfLineCommand = new EndOfLineCommand(richEditControl1);

            startOfLineCommand.Execute();

            int start = richEditControl1.Document.CaretPosition.ToInt();

            endOfLineCommand.Execute();

            int length = richEditControl1.Document.CaretPosition.ToInt() - start;

            DocumentRange range = richEditControl1.Document.CreateRange(start, length);
            DocumentRange range2 = richEditControl1.Document.CreateRange(start, length + 1);

            string text = richEditControl1.Document.GetText(range2);

            richEditControl1.Document.CaretPosition = currentPosition;
            isSelectionLocked = false;
            if(text.EndsWith(Environment.NewLine))
                return range2;
            else
                return range;            
        }
    }
}
