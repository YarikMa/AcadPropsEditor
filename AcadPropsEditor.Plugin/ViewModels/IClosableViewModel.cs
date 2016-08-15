using System;

namespace AcadPropsEditor.Plugin.ViewModels
{
    public interface IClosableViewModel
    {
        EventHandler ClosingRequest { get; set; }
    }
}
