<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128623297/17.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T590943)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [CustomPictureEdit.cs](./CS/DXApplication7/CustomPictureEdit.cs) (VB: [CustomPictureEdit.vb](./VB/DXApplication7/CustomPictureEdit.vb))
* [Main.cs](./CS/DXApplication7/Main.cs) (VB: [Main.vb](./VB/DXApplication7/Main.vb))
* [Program.cs](./CS/DXApplication7/Program.cs) (VB: [Program.vb](./VB/DXApplication7/Program.vb))
<!-- default file list end -->
# PictureEdit - How to highlight and mark nested figures shown within an image 


Imagine that your image shows a set of different figures like a diagram and you need to highlight a figure located under the mouse position or mark it with a predefined color by clicking it in the currently shown image. This example illustrates how to do this. The key point here is to specify rectangles associated with these nested figures and pass them to a custom <strong>PictureEdit</strong>, so that it can recognize them. Do this by using the <strong>CustomPictureEdit.NestedFigures</strong> collection. To specify your own colors used for highlighting the figures, use the <strong>CustomPictureEdit.Properties.HighlightFigureColor</strong> and <strong>CustomPictureEdit.Properties.ActiveFigureColor</strong> properties. <br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/pictureedit-how-to-highlight-and-mark-nested-figures-shown-within-an-image-t590943/17.2.4+/media/6df4f3b7-0bd2-4eb9-9bfa-aab6d4cfea76.png">

<br/>


