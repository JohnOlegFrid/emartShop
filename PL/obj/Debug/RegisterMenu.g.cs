﻿#pragma checksum "..\..\RegisterMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0EF2456441448E5648CC9ADDFE60A301"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PL {
    
    
    /// <summary>
    /// RegisterMenu
    /// </summary>
    public partial class RegisterMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeB;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button maximaizeB;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button minimaizeB;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox firstNametxt;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastNametxt;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\RegisterMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDtxt;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PL;component/registermenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.closeB = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\RegisterMenu.xaml"
            this.closeB.Click += new System.Windows.RoutedEventHandler(this.closeClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.maximaizeB = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\RegisterMenu.xaml"
            this.maximaizeB.Click += new System.Windows.RoutedEventHandler(this.maximaizeB_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.minimaizeB = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\RegisterMenu.xaml"
            this.minimaizeB.Click += new System.Windows.RoutedEventHandler(this.minimaizeClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.firstNametxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.lastNametxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.IDtxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 52 "..\..\RegisterMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

