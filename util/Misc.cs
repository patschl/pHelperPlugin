namespace Turbo.Plugins.Patrick.util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public static class Misc
    {
        public static bool AreYouSureDialogConfirmed(string text)
        {
            return MessageBox.Show(text, "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public static List<Type> GetAllSubTypesFromType(Type baseType)
        {
            return Assembly.GetAssembly(baseType).GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(baseType))
                .ToList();
        }
    }
}