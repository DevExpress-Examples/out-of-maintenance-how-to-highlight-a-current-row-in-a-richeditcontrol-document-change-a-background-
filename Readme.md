<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml.cs](./CS/WpfApplication1/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication1/MainWindow.xaml.vb))
<!-- default file list end -->
# How to highlight a current row in a RichEditControl document (change a background color)


<p>The main idea of this approach is to get a document range that corresponds to the current document row and change a background color of this range.<br />To get this document range, we use the approach demonstrated in the following example: <br /><a href="https://www.devexpress.com/Support/Center/p/E3487">How to select a current line in the RichEditControl</a><br />Once a corresponding range is obtained, we change character properties of this range in the <strong>RichEditControl.SelectionChanged</strong> event handler.</p>

<br/>


