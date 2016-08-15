// (C) Copyright 2016 by  
//

using AcadPropsEditor.Plugin;
using AcadPropsEditor.Plugin.Views;
using Autodesk.AutoCAD.Runtime;
using AutocadApp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

// This line is not mandatory, but improves loading performances
[assembly: CommandClass(typeof(Commands))]

namespace AcadPropsEditor.Plugin
{

    // This class is instantiated by AutoCAD for each document when
    // a command is called by the user the first time in the context
    // of a given document. In other words, non static data in this class
    // is implicitly per-document!
    public class Commands
    {
        // The CommandMethod attribute can be applied to any public  member 
        // function of any public class.
        // The function should take no arguments and return nothing.
        // If the method is an intance member then the enclosing class is 
        // intantiated for each document. If the member is a static member then
        // the enclosing class is NOT intantiated.
        //
        // NOTE: CommandMethod has overloads where you can provide helpid and
        // context menu.

        // Modal Command with localized name
        [CommandMethod("EDITOBJECTS", CommandFlags.Modal)]
        public void EditObjectsCommand() // This method can have any name
        {
            AutocadApp.ShowModalWindow(new ObjectsProps());
        }
    }

}
