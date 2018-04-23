Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Commands

Namespace WpfApplication1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
            richEditControl1.LoadDocument(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("testDocument.docx"), DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
			lineRange = richEditControl1.Document.CreateRange(0, 1)
		End Sub

		Private lineRange As DocumentRange = Nothing
		Private isSelectionLocked As Boolean = False
		Private Sub richEditControl1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			If isSelectionLocked Then
				Return
			End If
			If (Not lineRange.Contains(richEditControl1.Document.CaretPosition)) Then
				SetLineRangeFormatting(lineRange, System.Drawing.Color.Transparent)
				lineRange = GetNewLineRange(richEditControl1.Document.CaretPosition)
				SetLineRangeFormatting(lineRange, System.Drawing.Color.LightGray)
			End If
		End Sub

		Private Sub SetLineRangeFormatting(ByVal currentLineRange As DocumentRange, ByVal rangeColor As System.Drawing.Color)
			Dim cp As CharacterProperties = richEditControl1.Document.BeginUpdateCharacters(currentLineRange)
			cp.BackColor = rangeColor
			richEditControl1.Document.EndUpdateCharacters(cp)
		End Sub

		Private Function GetNewLineRange(ByVal caret As DocumentPosition) As DocumentRange
			isSelectionLocked = True
			Dim currentPosition As DocumentPosition = richEditControl1.Document.CaretPosition

			Dim startOfLineCommand As New StartOfLineCommand(richEditControl1)
			Dim endOfLineCommand As New EndOfLineCommand(richEditControl1)

			startOfLineCommand.Execute()

			Dim start As Integer = richEditControl1.Document.CaretPosition.ToInt()

			endOfLineCommand.Execute()

			Dim length As Integer = richEditControl1.Document.CaretPosition.ToInt() - start

			Dim range As DocumentRange = richEditControl1.Document.CreateRange(start, length)
			Dim range2 As DocumentRange = richEditControl1.Document.CreateRange(start, length + 1)

			Dim text As String = richEditControl1.Document.GetText(range2)

			richEditControl1.Document.CaretPosition = currentPosition
			isSelectionLocked = False
			If text.EndsWith(Environment.NewLine) Then
				Return range2
			Else
				Return range
			End If
		End Function
	End Class
End Namespace
