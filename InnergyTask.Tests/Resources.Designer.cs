﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InnergyTask.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("InnergyTask.Tests.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to # Material inventory initial state as of Jan 01 2018
        ///# New materials
        ///Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10
        ///Maple Dovetail Drawerbox;COM-124047;WH-A,15
        ///Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2
        ///Yankee Hardware 110 Deg. Hinge;COM-123908;WH-A,10|WH-B,11
        ///# Existing materials, restocked
        ///Hdw Accuride CB0115-CASSRC - Locking Handle Kit - Black;CB0115-CASSRC;WH-C,10|WH-B,5|WH-C,3
        ///Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm - Paper Back;3M-Cherry-10mm;WH-A,10 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string data {
            get {
                return ResourceManager.GetString("data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to warhouse2 (total 21)
        ///m1: 20
        ///m3: 1
        ///
        ///warhouse3 (total 5)
        ///m2: 2
        ///m2: 3
        ///
        ///warhouse1 (total 5)
        ///m1: 2
        ///m3: 3
        ///
        ///
        ///.
        /// </summary>
        internal static string expectedResultForStandardConsoleOuput_2WarhouseWithTheSameAmount_CheckOrder {
            get {
                return ResourceManager.GetString("expectedResultForStandardConsoleOuput_2WarhouseWithTheSameAmount_CheckOrder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to warhouse2 (total 23)
        ///m1: 20
        ///m2: 3
        ///
        ///warhouse1 (total 12)
        ///m1: 10
        ///m2: 2
        ///
        ///.
        /// </summary>
        internal static string expectedResultForStandardConsoleOutput_2material_2warehouses {
            get {
                return ResourceManager.GetString("expectedResultForStandardConsoleOutput_2material_2warehouses", resourceCulture);
            }
        }
    }
}
