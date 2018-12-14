using System.Collections.Generic;
using InnergyTask.Models;

namespace InnergyTask.OutputPresentation
{
    public interface IPresentable
    {
        void Display(IEnumerable<Material> materials);
    }
}