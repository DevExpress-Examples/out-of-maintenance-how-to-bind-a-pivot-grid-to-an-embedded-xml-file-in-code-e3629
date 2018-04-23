using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Xml.Serialization;
using DevExpress.Xpf.PivotGrid;

namespace DXPivotGrid_BindingToEmbeddedXMLInCode {
    public partial class MainPage : UserControl {
        string dataFileName = "DXPivotGrid_BindingToEmbeddedXMLInCode.nwind.xml";
        public MainPage() {
            InitializeComponent();

            // Parses an XML file and creates a collection of data items.
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(dataFileName);
            XmlSerializer s = new XmlSerializer(typeof(OrderData));
            object dataSource = s.Deserialize(stream);

            // Binds a pivot grid to this collection.
            pivotGridControl1.DataSource = dataSource;

            // Creates four pivot grid fields and maps them to corresponding
            // data item fields.
            pivotGridControl1.Fields.Add(new PivotGridField() {
                FieldName = "ShipName",
                Caption = "Customer",
                Area = FieldArea.RowArea
            });
            pivotGridControl1.Fields.Add(new PivotGridField() {
                FieldName = "ShippedDate",
                GroupInterval = FieldGroupInterval.DateQuarter,
                Caption = "Quarter",
                Area = FieldArea.ColumnArea,
                ValueFormat = "Qtr {0}"
            });
            pivotGridControl1.Fields.Add(new PivotGridField() {
                FieldName = "ShippedDate",
                GroupInterval = FieldGroupInterval.DateMonth,
                Caption = "Month",
                Area = FieldArea.ColumnArea
            });
            pivotGridControl1.Fields.Add(new PivotGridField() {
                FieldName = "Freight",
                Area = FieldArea.DataArea
            });
        }
    }
}