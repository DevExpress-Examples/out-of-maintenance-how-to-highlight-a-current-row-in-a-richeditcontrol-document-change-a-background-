<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128607753/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T213081)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml.cs](./CS/WpfApplication1/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication1/MainWindow.xaml.vb))
<!-- default file list end -->
# How to highlight a current row in a RichEditControl document (change a background color)


<p>The main idea of this approach is to get a document range that corresponds to the current document row and change a background color of this range.<br />To get this document range, we use the approach demonstrated in the following example: <br /><a href="https://www.devexpress.com/Support/Center/p/E3487">How to select a current line in the RichEditControl</a><br />Once a corresponding range is obtained, we change character properties of this range in the <strong>RichEditControl.SelectionChanged</strong> event handler.</p>

<br/>


