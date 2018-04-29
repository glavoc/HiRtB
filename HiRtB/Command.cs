using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.DesignScript.Geometry;

namespace HiRtB
{
    /// <remarks>
    /// The external command to intiate WPF window and 
    /// populate it with selected Property Line Segments
    /// </remarks>
    [Autodesk.Revit.Attributes.Transaction(
        Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static UIApplication app { get; set; }
        public static UIDocument uidoc { get; set; }
        public static Document doc { get; set; }
        public static Selection selection { get; set; }

        ICollection<PropertyLineSegment> propertyLine;

        private ICollection<PropertyLineSegment> propertySegment;
        Window1 window1;

        // The main Execute method (inherited from IExternalCommand) must be public
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {

            window1 = new Window1();
            //populate WPF list with selected property lines
            try
            {
                //Revit Document and App
                app = commandData.Application;
                uidoc = app.ActiveUIDocument;
                doc = uidoc.Document;
                //get selection
                selection = uidoc.Selection;
                ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
                //get the first or last, doesn't matter 'cause it'll 
                //break if the selectedIds list is longer than 1
                Element elementType = doc.GetElement(selectedIds.First());

                // Check if SINGLE Property Lines is selected
                if (1 == selectedIds.Count && elementType is PropertyLine)
                {
                    TaskDialog.Show(
                        "Revit",
                        "Single property boundary lines selected."
                        );

                    //get property line segments and populate list with them
                    PopulateWindowList(elementType);

                }
                else
                {
                    TaskDialog.Show(
                        "Revit",
                        "Please select single property boundary lines."
                        );
                }
                window1.Show();
            }

            catch (Exception e)
            {
                message = e.Message;
                return Autodesk.Revit.UI.Result.Failed;
            }

            return Autodesk.Revit.UI.Result.Succeeded;
        }

        private void PopulateWindowList(Element propLines)
        {
            GeometryElement geomElem = propLines.get_Geometry(new Options());
            foreach (GeometryObject obj in geomElem)
            {
                obj.GetType();

            }
        }
    }
}

