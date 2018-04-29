using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using Revit.GeometryConversion;
using Revit.GeometryReferences;

namespace HiRtB
{
    /// <summary>
    /// Class of Property Line Segment
    /// </summary>
    /// <remarks>
    /// Property Line Segments can be of type Line and Arc.
    /// </remarks>
    class PropertyLineSegment
    {
        public Arc SegmentArc { get; set; }
        public Line SegmentLine { get; set; }
        public double OrientToN { get; set; }
        public double VerOffset { get; set; }

        private PropertyLineSegment(Element el)
        {
        }

        private PropertyLineSegment(Line segmentLine)
        {
            SegmentLine = segmentLine;
        }
        
    }
}
