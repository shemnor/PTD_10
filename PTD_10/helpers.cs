using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PS = PTD_10.Properties.Settings;
using System.Configuration;
using System.Windows.Forms;
using System.IO;


using System.Reflection;

using System.ComponentModel;

using System.Drawing;
using System.Drawing.Text;

using Tekla.Structures;
using Tekla.Structures.DrawingInternal;
using TSDrg = Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;

namespace PTD_10
{
    public static class Helpers
    {
        public enum DialogType
        {
            bar = 1,
            coupler = 2
        }

        public static void ApplyUserProperties(DataTable userSettings)
        {
            foreach (DataRow row in userSettings.Rows)
            {
                switch (PS.Default[row[0].ToString()])
                {
                    case String t1:
                        PS.Default[row[0].ToString()] = row.Field<String>(1);
                        break;
                    case Double t2:
                        PS.Default[row[0].ToString()] = Double.Parse(row[1].ToString());
                        break;
                    case int t3:
                        PS.Default[row[0].ToString()] = (row.Field<int>(1));
                        break;
                }
            }
            PS.Default.Save();
        }

        public static void ReadUserProperties(ref DataTable userSettings)
        {
            foreach (SettingsProperty property in PS.Default.Properties)
            {
                DataRow row = userSettings.NewRow();
                row[0] = property.Name;
                row[1] = PS.Default[property.Name].ToString();

                userSettings.Rows.Add(row);
            }
        }

        public static Tuple<List<string>, List<string>> Parse2valueCSV(string path)
        {
            using (var reader = new StreamReader(path))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
                return new Tuple<List<string>, List<string>>(listA, listB);
            }

        }

        public static Tuple<List<string>, List<string>> SplitCsvFromString(string text, char delimeter)
        {
            var lines = text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None);
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            for (int i = 0; i < lines.Length - 1; i++)
            {
                var values = lines[i].Split(delimeter);
                listA.Add(values[0]);
                listB.Add(values[1]);
            }
            return new Tuple<List<string>, List<string>>(listA, listB);
        }

        public static List<DrawingObject> getDwgObjectsFromSelection(Type filterType)
        {
            TSDrg.DrawingHandler drawingHandler = new TSDrg.DrawingHandler();
            TSDrg.DrawingObjectEnumerator dwgObjectEnumerator;
            List<DrawingObject> dwgObjs = new List<DrawingObject>();

            dwgObjectEnumerator = drawingHandler.GetDrawingObjectSelector().GetSelected();

            if (dwgObjectEnumerator.GetSize() == 0)
            {
                return null;
            }
            foreach (DrawingObject drawingObject in dwgObjectEnumerator)
            {
                if (drawingObject != null && drawingObject.GetType().IsSubclassOf(filterType))
                {
                    dwgObjs.Add(drawingObject);
                }
            }
            return dwgObjs;
        }

        public static List<TSM.ModelObject> getMdlObjectsFromSelection(Type filterType1, Type filterType2 = null, Type filterType3 = null)
        {
            TSM.UI.ModelObjectSelector modelSelector = new TSM.UI.ModelObjectSelector();
            TSM.ModelObjectEnumerator modelObjEnum;
            List<TSM.ModelObject> mdlObjs = new List<TSM.ModelObject>();

            modelObjEnum = modelSelector.GetSelectedObjects();

            if (modelObjEnum.GetSize() == 0)
            {
                return null;
            }
            foreach (TSM.ModelObject modelObject in modelObjEnum)
            {
                if (modelObject != null && (modelObject.GetType() == filterType1 | modelObject.GetType().IsSubclassOf(filterType1)))
                {
                    mdlObjs.Add(modelObject);
                }

                if (filterType2 != null)
                {
                    if (modelObject != null && (modelObject.GetType() == filterType2 | modelObject.GetType().IsSubclassOf(filterType2)))
                    {
                        mdlObjs.Add(modelObject);
                    }
                }

                if (filterType3 != null)
                {
                    if (modelObject != null && (modelObject.GetType() == filterType3 | modelObject.GetType().IsSubclassOf(filterType3)))
                    {
                        mdlObjs.Add(modelObject);
                    }
                }
            }
            return mdlObjs;
        }
    }
}
