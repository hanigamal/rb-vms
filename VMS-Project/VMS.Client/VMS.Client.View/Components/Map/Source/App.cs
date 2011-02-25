using System;
using System.Windows;
using GMap.NET;

namespace VMS.Client.View.Component.Map.Source
{
   public partial class App : Application
   {
      [STAThread()]
      static void Main()
      {
         // Create the application.
         //Application app = new Application();

         // Create the main window.
         //MapsView win = new MapsView();

         // Launch the application and show the main window.
         //app.Run(win);
      }
   }

   public class Dummy
   {

   }

   public struct PointAndInfo
   {
      public PointLatLng Point;
      public string Info;

      public PointAndInfo(PointLatLng point, string info)
      {
         Point = point;
         Info = info;
      }
   }
}
