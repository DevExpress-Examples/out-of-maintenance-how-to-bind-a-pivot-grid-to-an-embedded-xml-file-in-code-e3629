Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Windows.Controls
Imports System.Xml.Serialization
Imports DevExpress.Xpf.PivotGrid

Namespace DXPivotGrid_BindingToEmbeddedXMLInCode
	Partial Public Class MainPage
		Inherits UserControl
        Private dataFileName As String = "nwind.xml"
		Public Sub New()
			InitializeComponent()

			' Parses an XML file and creates a collection of data items.
            Dim assembly As System.Reflection.Assembly = _
                System.Reflection.Assembly.GetExecutingAssembly()
            Dim stream As Stream = assembly.GetManifestResourceStream(dataFileName)
			Dim s As New XmlSerializer(GetType(OrderData))
			Dim dataSource As Object = s.Deserialize(stream)

			' Binds a pivot grid to this collection.
			pivotGridControl1.DataSource = dataSource

			' Creates four pivot grid fields and maps them to corresponding
			' data item fields.
            pivotGridControl1.Fields.Add(New PivotGridField() With {
                                         .FieldName = "ShipName",
                                         .Caption = "Customer",
                                         .Area = FieldArea.RowArea
                                     })
            pivotGridControl1.Fields.Add(New PivotGridField() With {
                                         .FieldName = "ShippedDate",
                                         .GroupInterval = FieldGroupInterval.DateQuarter,
                                         .Caption = "Quarter",
                                         .Area = FieldArea.ColumnArea,
                                         .ValueFormat = "Qtr {0}"
                                     })
            pivotGridControl1.Fields.Add(New PivotGridField() With {
                                         .FieldName = "ShippedDate",
                                         .GroupInterval = FieldGroupInterval.DateMonth,
                                         .Caption = "Month",
                                         .Area = FieldArea.ColumnArea
                                     })
            pivotGridControl1.Fields.Add(New PivotGridField() With {
                                         .FieldName = "Freight",
                                         .Area = FieldArea.DataArea
                                     })
		End Sub
	End Class
End Namespace